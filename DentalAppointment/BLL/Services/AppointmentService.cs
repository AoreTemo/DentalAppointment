using BLL.Interface;
using Core.Models;
using DAL.Interfaces;
using DAL.Repositories;

namespace BLL.Services;

public class AppointmentService : GenericService<Appointment>, IAppointmentService
{
    public AppointmentService(IRepository<Appointment> repository) : base(repository)
    {
    }

}

