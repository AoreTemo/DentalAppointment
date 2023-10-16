using System.Security.Claims;
using BLL.Services;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

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
    public IActionResult Create(DateTime AppointmentDate, DateTime AppointmentTime, int DoctorId) // изменил имя параметра на DoctorId
    {
        var doctor = _doctorService.GetById(DoctorId);
        if (doctor == null)
        {
            return NotFound();
        }

        // проверяем, что нет других записей на это же время и к этому же доктору
        var existingAppointment = _appointmentService.GetByPredicate(
            a => a.AppointmentDate == AppointmentDate && a.AppointmentTime == DateTime.Parse(AppointmentTime.ToString("HH:mm:ss")).TimeOfDay && a.DoctorId == DoctorId).ToList().FirstOrDefault(); // изменил имя параметра на DoctorId и добавил преобразование строки в DateTime
        if (existingAppointment != null)
        {
            return Conflict();
        }

        // проверяем, что пользователь авторизован и имеет идентификатор
        if (!User.Identity.IsAuthenticated || User.FindFirst(ClaimTypes.NameIdentifier) == null)
        {
            return Unauthorized();
        }

        // создаем новый объект Appointment с данными из параметров и текущим пользователем
        var appointment = new Appointment
        {
            AppointmentDate = AppointmentDate, // новое свойство
            AppointmentTime = AppointmentTime.TimeOfDay, // добавил преобразование строки в DateTime
            DoctorId = DoctorId, // изменил имя параметра на DoctorId
            AppUserId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value
        };

        // добавляем новый объект Appointment в базу данных и сохраняем изменения
        _appointmentService.Add(appointment);

        // возвращаем результат с кодом 200 OK и данными о созданной записи
        return Ok(appointment);
    }
}
