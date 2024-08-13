using System.ComponentModel.DataAnnotations.Schema;

namespace PCD.Data.Entities;

public class Car : BaseEntity
{
    required public string Brand { get; set; }
    required public string Model { get; set; }
    required public int Year { get; set; }
    required public string CountryOfRegistration { get; set; }
    required public string LicensePlateNumber { get; set; }
    required public string VIN { get; set; }
    [ForeignKey("User")]
    public int? UserId { get; set; }
    public virtual User? User { get; set; }
    required public List<Trip> Trips { get; set; }
    public Trip? LastTrip { get => Trips.LastOrDefault(); }
}
