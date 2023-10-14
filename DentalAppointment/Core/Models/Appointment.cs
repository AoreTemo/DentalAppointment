namespace Core.Models;
public class Appointment
{
    public int Id { get; set; }
    public DateTime AppointmentData { get; set; }
    public TimeSpan AppointmentTime { get; set; }
    public bool IsBooked { get; set; }

}
