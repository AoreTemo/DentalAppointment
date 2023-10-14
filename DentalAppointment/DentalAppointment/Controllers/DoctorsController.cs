// using BLL.Services;
// using Microsoft.AspNetCore.Mvc;
//
// namespace DentalAppointment.Controllers;
//
// public class DoctorsController : Controller
// {
//     private readonly DoctorService _doctorService;
//
//     public DoctorsController(DoctorService doctorService)
//     {
//         _doctorService = doctorService;
//     }
//
//     [HttpGet]
//     public ActionResult Index()
//     {
//         var doctors = _doctorService.GetByPredicate();
//         return View(doctors);
//     }
//
//     [HttpGet]
//     [Route("{id}")]
//     public ActionResult Details(int id)
//     {
//         var doctor = _doctorService.GetById(id);
//         return View(doctor);
//     }
// }