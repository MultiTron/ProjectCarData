namespace PCD.Infrastructure.DTOs.Users;

public class UserAlterModel : BaseAlterModel
{
    required public string FirstName { get; set; }
    required public string LastName { get; set; }
    required public string DriversLicenseNumber { get; set; }
    required public string Email { get; set; }
    required public string Password { get; set; }
}
