using PCD.Infrastructure.DTOs.Cars;

namespace PCD.ApplicationServices.Messaging.Cars.Request
{
    public class CreateCarRequest : BaseRequest
    {
        public CreateCarRequest(CarAlterModel car)
        {
            Car = car;
        }
        public CarAlterModel Car { get; set; }
    }
}
