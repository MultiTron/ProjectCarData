using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PCD.ApplicationServices.Interfaces;
using PCD.ApplicationServices.Messaging.Users.Request;
using PCD.ApplicationServices.Messaging.Users.Response;
using PCD.Data;
using PCD.Data.Entities;
using PCD.Infrastructure.DTOs.Users;

namespace PCD.ApplicationServices.Implementations;

public class UsersManagementService : BaseManagementService, IUsersManagementService
{
    private readonly ApplicationContext _context;

    public UsersManagementService(ApplicationContext context, IMapper mapper, ILogger<UsersManagementService> logger) : base(mapper, logger)
    {
        _context = context;
    }

    public async Task<CreateUserResponse> CreateUser(CreateUserRequest request)
    {
        await _context.Users.AddAsync(_mapper.Map<User>(request.User));
        var status = await _context.SaveChangesAsync();
        if (status > 0)
        {
            return new();
        }
        else
        {
            return new() { StatusCode = Messaging.StatusCode.ClientError };
        }
    }

    public async Task<GetUsersResponse> GetAllUsers()
    {
        var users = new List<UserViewModel>();
        await _context.Users.ForEachAsync(x => users.Add(_mapper.Map<UserViewModel>(x)));
        return new(users);
    }
}
