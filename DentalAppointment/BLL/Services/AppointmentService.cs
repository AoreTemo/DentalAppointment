using Core.Models;
using DAL.Interfaces;
using DAL.Repositories;

namespace BLL.Services;

public class AppointmentService : GenericService<Appointment>
{
    protected AppointmentService(IRepository<Appointment> repository) : base(repository)
    {
    }

}

