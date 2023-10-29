using BLL.Services;
using Core.Models;

namespace BLL.Interface;

public interface IAppointmentService : IGenericService<Appointment>
{
    Appointment? GetNearestAppointment(string UserId);
    List<Core.Models.Appointment> GetPlannedAppointments(string UserId);
    List<Appointment>? GetCurrentAppointments(string UserId);
    List<Appointment>? GetFinishedAppointments(string UserId);
}