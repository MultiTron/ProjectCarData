using PCD.Infrastructure.DTOs.Cars;

namespace PCD.ApplicationServices.Messaging.Cars.Request
{
    public class CreateCarRequest : BaseRequest
    {
        public CreateCarRequest()
        {

        }
        public CreateCarRequest(CarAlterModel car)
        {
            Car = car;
        }
        required public CarAlterModel Car { get; set; }
    }
}
