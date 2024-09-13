using AutoMapper;
using Microsoft.Extensions.Logging;
using PCD.Repository.Interfaces;

namespace PCD.ApplicationServices.Implementations;

public class BaseManagementService
{
    internal readonly ILogger<BaseManagementService> _logger;

    internal readonly IUnitOfWork _unitOfWork;
    internal readonly IMapper _mapper;
    public BaseManagementService(IMapper mapper, IUnitOfWork unitOfWork, ILogger<BaseManagementService> logger)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }
}
