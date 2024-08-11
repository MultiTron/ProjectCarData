using PCD.Infrastructure.DTOs.Cars;

namespace PCD.ApplicationServices.Messaging.Cars.Response
{
    public class GetCarResponse : BaseResponse
    {
        public CarViewModel? Car { get; set; }
        public GetCarResponse(CarViewModel? car = null)
        {
            Car = car;
        }
    }
}
