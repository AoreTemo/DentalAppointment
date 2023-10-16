using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Core.Models;
public class Appointment
{
    public int Id { get; set; }
    public DateTime AppointmentDate { get; set; }
    public TimeSpan AppointmentTime { get; set; }

    [ForeignKey("AppUser")]
    public string AppUserId { get; set; }
    [JsonIgnore]
    public virtual AppUser AppUser { get; set; }

    [ForeignKey("Doctor")]
    public int DoctorId { get; set; }
    [JsonIgnore]
    public virtual Doctor Doctor { get; set; }
}
