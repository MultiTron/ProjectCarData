using PCD.Infrastructure.DTOs.Cars;

namespace PCD.ApplicationServices.Messaging.Cars.Response;

public class CreateCarResponse : BaseResponse
{
    public CarViewModel? Car { get; set; }
    public CreateCarResponse() { }
    public CreateCarResponse(CarViewModel car)
    {
        Car = car;
    }
}
