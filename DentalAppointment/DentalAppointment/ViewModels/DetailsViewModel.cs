using BLL.Services;
using Core.Models;

namespace DentalAppointment.ViewModels;

public class DetailsViewModel
{
    public Doctor Doctor { get; set; }
    public List<Appointment> Appointments { get; set; }
}