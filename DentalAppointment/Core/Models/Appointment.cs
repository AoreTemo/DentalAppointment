using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models;
public class Appointment
{
    public int Id { get; set; }
    public DateTime AppointmentData { get; set; }
    public TimeSpan AppointmentTime { get; set; }
    public bool IsBooked { get; set; }

    [ForeignKey("AppUser")]
    public string AppUserId { get; set; }
    public virtual AppUser AppUser { get; set; }

    [ForeignKey("Doctor")]
    public int DoctorId { get; set; }
    public virtual Doctor Doctor { get; set; }

}
