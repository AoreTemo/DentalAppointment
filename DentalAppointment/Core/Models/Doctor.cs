using System.Text.Json.Serialization;

namespace Core.Models;

public class Doctor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; } 
    public string MiddleName { get; set; }
    public int Age { get; set; }
    public string Info { get; set; }
    public string ImageLink { get; set; }

    [JsonIgnore]
    public virtual ICollection<Appointment> Appointments { get; set; }
}
