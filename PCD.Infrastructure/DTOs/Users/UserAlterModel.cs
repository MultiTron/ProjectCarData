namespace PCD.Infrastructure.DTOs.Users;

public class UserAlterModel : BaseAlterModel
{
    required public string FirstName { get; set; }
    required public string LastName { get; set; }
}
