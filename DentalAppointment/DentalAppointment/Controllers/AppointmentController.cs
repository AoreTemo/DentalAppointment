using System.Security.Claims;
using BLL.Services;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace DentalAppointment.Controllers;

public class AppointmentController : Controller
{
    private readonly DoctorService _doctorService;
    private readonly AppointmentService _appointmentService;

    public AppointmentController(DoctorService doctorService, AppointmentService appointmentService)
    {
        _doctorService = doctorService;
        _appointmentService = appointmentService;
    }

    // GET
    public IActionResult Index(int id)
    {
        return View();
    }

    // POST: /Appointments/Create
    [HttpPost]
    public IActionResult Create(DateTime appointmentDate, DateTime appointmentTime, int DoctorId)
    {
        var doctor = _doctorService.GetById(DoctorId);
        if (doctor == null)
        {
            return NotFound();
        }

        var existingAppointment = _appointmentService.GetByPredicate(
            a => a.AppointmentDate == appointmentDate && a.AppointmentTime == DateTime.Parse(appointmentTime.ToString("HH:mm:ss")).TimeOfDay && a.DoctorId == DoctorId).ToList().FirstOrDefault(); 
        if (existingAppointment != null)
        {
            return Conflict();
        }

        if (!User.Identity.IsAuthenticated || User.FindFirst(ClaimTypes.NameIdentifier) == null)
        {
            return Unauthorized();
        }

        var appointment = new Appointment
        {
            AppointmentDate = appointmentDate, 
            AppointmentTime = appointmentTime.TimeOfDay, 
            DoctorId = DoctorId, 
            AppUserId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value
        };

        _appointmentService.Add(appointment);

        return RedirectToAction("Info", "Account");
    }
}
