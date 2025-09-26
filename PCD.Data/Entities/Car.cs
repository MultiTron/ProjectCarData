using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCD.Data.Entities;

public class Car : BaseEntity
{
    [Column("brand")]
    required public string Brand { get; set; }
    [Column("model")]
    required public string Model { get; set; }
    [Column("year")]
    required public int Year { get; set; }
    [Column("country_of_registartion")]
    required public string CountryOfRegistration { get; set; }
    [Column("license_plate_number")]
    required public string LicensePlateNumber { get; set; }
    [Column("vin")]
    [RegularExpression("\b[(A-H|J-N|P|R-Z|0-9)]{17}\b")]
    required public string VIN { get; set; }
    [Column("user_id")]
    [ForeignKey(nameof(User))]
    public Guid? UserId { get; set; }
    public virtual User? User { get; set; }
    required public virtual List<Trip> Trips { get; set; }
}
