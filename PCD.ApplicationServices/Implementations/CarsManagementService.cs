using AutoMapper;
using Microsoft.Extensions.Logging;
using PCD.ApplicationServices.Interfaces;
using PCD.Data;

namespace PCD.ApplicationServices.Implementations
{
    public class CarsManagementService : BaseManagementService, ICarsManagementService
    {
        private readonly ApplicationContext _context;
        public CarsManagementService(ApplicationContext context, IMapper mapper, ILogger<CarsManagementService> logger) : base(mapper, logger)
        {
            _context = context;
        }
    }
}
