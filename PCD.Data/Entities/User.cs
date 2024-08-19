namespace PCD.Data.Entities;

public class User : BaseEntity
{
    required public string FirstName { get; set; }
    required public string LastName { get; set; }
    required public string DriversLicenseNumber { get; set; }
    required public string Email { get; set; }
    required public string Password { get; set; }
    required public List<Car> Cars { get; set; }
}
