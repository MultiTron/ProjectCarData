namespace PCD.Infrastructure.DTOs.Users;

public class UserViewModel : BaseViewModel
{
    required public int Id { get; set; }
    required public string FirstName { get; set; }
    required public string LastName { get; set; }
}
