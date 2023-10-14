using Microsoft.AspNetCore.Identity;
namespace Core.Models; 

public class AppUser : IdentityUser
{
    public UserRole Role { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
