using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCD.Data.Entities;

public class User : BaseEntity
{
    [Column("first_name")]
    required public string FirstName { get; set; }
    [Column("last_name")]
    required public string LastName { get; set; }
    [Column("drivers_license_number")]
    [StringLength(9, MinimumLength = 9)]
    required public string DriversLicenseNumber { get; set; }
    [Column("email")]
    [EmailAddress]
    required public string Email { get; set; }
    [Column("password_hash")]
    required public string PasswordHash { get; set; }
    required public virtual List<Car> Cars { get; set; }
}
