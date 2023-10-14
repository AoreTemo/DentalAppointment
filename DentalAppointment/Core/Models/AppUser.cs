using Microsoft.AspNetCore.Identity;
namespace Core.Models; 

public class AppUser : IdentityUser
{
    public UserRole Role { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public virtual ICollection<Appointment> Appointments { get; set; }
}
