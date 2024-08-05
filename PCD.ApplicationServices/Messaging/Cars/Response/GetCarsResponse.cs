using PCD.Infrastructure.DTOs.Cars;

namespace PCD.ApplicationServices.Messaging.Cars.Response
{
    public class GetCarsResponse : BaseResponse
    {
        public List<CarViewModel> Cars { get; set; }

        public GetCarsResponse(List<CarViewModel> cars)
        {
            Cars = cars;
        }
        public GetCarsResponse()
        {
            Cars = new List<CarViewModel>();
        }
    }
}
