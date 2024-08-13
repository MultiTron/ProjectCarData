using AutoMapper;
using Microsoft.Extensions.Logging;
using PCD.ApplicationServices.Interfaces;
using PCD.ApplicationServices.Messaging.Users.Request;
using PCD.ApplicationServices.Messaging.Users.Response;
using PCD.Data.Entities;
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

    public async Task<CreateUserResponse> CreateUser(CreateUserRequest request)
    {
        var responseCar = await _unitOfWork.Users.Insert(_mapper.Map<User>(request.User));
        var status = await _unitOfWork.SaveChangesAsync();
        if (status > 0)
        {
            return new(_mapper.Map<UserViewModel>(responseCar));
        }
        else
        {
            return new() { StatusCode = Messaging.StatusCode.ClientError };
        }
    }

    public async Task<GetUsersResponse> GetAllUsers()
        => new((await _unitOfWork.Users.GetAll()).Select(_mapper.Map<UserViewModel>).ToList());
}
