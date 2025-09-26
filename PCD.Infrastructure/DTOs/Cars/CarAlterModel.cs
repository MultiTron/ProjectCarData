namespace PCD.Infrastructure.DTOs.Cars;

public class CarAlterModel : BaseAlterModel
{
    required public string Brand { get; set; }
    required public string Model { get; set; }
    required public int Year { get; set; }
    required public string LicensePlateNumber { get; set; }
    required public string CountryOfRegistration { get; set; }
    required public string VIN { get; set; }
    public Guid? UserId { get; set; }

}
