﻿namespace PCD.Infrastructure.DTOs.Cars;

public class CarViewModel : BaseViewModel
{
    required public int Id { get; set; }
    required public string Brand { get; set; }
    required public string Model { get; set; }
    required public int Year { get; set; }
    required public string LicensePlateNumber { get; set; }
    required public string CountryOfRegistration { get; set; }
    required public string VIN { get; set; }
    public int? UserId { get; set; }

}
