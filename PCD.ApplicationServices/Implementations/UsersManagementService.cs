using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PCD.ApplicationServices.Interfaces;
using PCD.Data.Entities;
using PCD.Infrastructure.DTOs.Cars;
using PCD.Infrastructure.DTOs.Users;
using PCD.Infrastructure.Interfaces;
using PCD.Infrastructure.Messaging;
using PCD.Infrastructure.Messaging.Request;
using PCD.Infrastructure.Messaging.Response;
using PCD.Repository.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PCD.ApplicationServices.Implementations;

public class UsersManagementService : BaseManagementService, IUsersManagementService
{
    private readonly IHashGenerator _hasher;
    private readonly string _token;

    public UsersManagementService(IUnitOfWork unitOfWork, IHashGenerator hasher, IOptions<JwtSettings> options, IMapper mapper, ILogger<UsersManagementService> logger) : base(mapper, unitOfWork, logger)
    {
        _hasher = hasher;
        _token = options.Value.Key!;
    }

    public async Task<TokenResponse> Authenticate(string email, string secret)
    {
        var user = (await _unitOfWork.Users.GetAll()).FirstOrDefault(x => x.Email == email && _hasher.Verify(x.PasswordHash, secret));
        if (user == null)
        {
            return new(CustomStatusCode.NotFound);
        }
        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_token);
        SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(
            [
                new(ClaimTypes.Name, email)
            ]),
            Expires = DateTime.UtcNow.AddMinutes(30),
            SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
        };

        var token = handler.CreateToken(tokenDescriptor);
        return new(handler.WriteToken(token), _mapper.Map<UserViewModel>(user));
    }

    public async Task<CreateResponse<UserViewModel>> CreateUser(CreateRequest<UserAlterModel> request)
    {
        request.Content.PasswordHash = _hasher.Hash(request.Content.PasswordHash);
        var item = await _unitOfWork.Users.Insert(_mapper.Map<User>(request.Content));
        var status = await _unitOfWork.SaveChangesAsync();
        if (status > 0)
        {
            return new(_mapper.Map<UserViewModel>(item));
        }
        else
        {
            return new() { StatusCode = CustomStatusCode.ClientError };
        }
    }

    public async Task<BaseResponse> DeleteUser(IdRequest request)
    {
        try
        {
            await Task.Run(() => _unitOfWork.Users.Delete(request.Id));
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception)
        {
            return new(CustomStatusCode.ServerError);
        }
        return new();
    }

    public async Task<ListResponse<UserViewModel>> GetAllUsers()
        => new((await _unitOfWork.Users.GetAll()).Select(_mapper.Map<UserViewModel>).ToList());

    public async Task<ListResponse<CarViewModel>> GetCarsByUser(IdRequest request)
    {
        return new((await _unitOfWork.Cars.GetCarsByUser(request.Id)).Select(_mapper.Map<CarViewModel>).ToList());
    }

    public async Task<GetResponse<UserViewModel>> GetUserById(IdRequest request)
    {
        return new(_mapper.Map<UserViewModel>(await _unitOfWork.Users.GetById(request.Id)));
    }

    public async Task<UpdateResponse<UserViewModel>> UpdateUser(UpdateRequest<UserAlterModel> request)
    {
        var entity = _mapper.Map<User>(request.Content);
        entity.Id = request.Id;
        entity.Cars = new();
        try
        {
            await _unitOfWork.Users.Update(entity, "");
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Update not working...");
            return new(CustomStatusCode.ServerError);
        }
        return new(_mapper.Map<UserViewModel>(entity));
    }
}
