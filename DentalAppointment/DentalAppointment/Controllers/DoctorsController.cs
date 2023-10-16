using BLL.Services;
using DentalAppointment.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DentalAppointment.Controllers;

public class DoctorsController : Controller
{
    private readonly DoctorService _doctorService;
    private readonly AppointmentService _appointmentService;

    public DoctorsController(DoctorService doctorService, AppointmentService appointmentService)
    {
        _doctorService = doctorService;
        _appointmentService = appointmentService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var doctors = _doctorService.GetByPredicate();
        return View(doctors);
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        var doctor = _doctorService.GetById(id)!;
        var appointments = _appointmentService.GetByPredicate(
            a => doctor.Id == a.DoctorId
        );
        var detailsViewModel = new DetailsViewModel
        {
            Doctor = doctor,
            Appointments = appointments
        };
        return View(detailsViewModel);
    }
}