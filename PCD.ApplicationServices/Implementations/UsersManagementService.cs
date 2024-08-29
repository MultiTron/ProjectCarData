using AutoMapper;
using Microsoft.Extensions.Logging;
using PCD.ApplicationServices.Interfaces;
using PCD.ApplicationServices.Messaging;
using PCD.ApplicationServices.Messaging.Request;
using PCD.ApplicationServices.Messaging.Response;
using PCD.Data.Entities;
using PCD.Infrastructure.DTOs.Cars;
using PCD.Infrastructure.DTOs.Users;
using PCD.Repository.Interfaces;

namespace PCD.ApplicationServices.Implementations;

public class UsersManagementService : BaseManagementService, IUsersManagementService
{
    private readonly IUnitOfWork _unitOfWork;

    public UsersManagementService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UsersManagementService> logger) : base(mapper, logger)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateResponse<UserViewModel>> CreateUser(CreateRequest<UserAlterModel> request)
    {
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
            _unitOfWork.Users.Update(entity, "");
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
