using AutoMapper;
using Microsoft.Extensions.Logging;

namespace PCD.ApplicationServices.Implementations
{
    public class BaseManagementService
    {
        internal readonly ILogger<BaseManagementService> _logger;
        internal readonly IMapper _mapper;
        public BaseManagementService(IMapper mapper, ILogger<BaseManagementService> logger)
        {
            _mapper = mapper;
            _logger = logger;
        }
    }
}
