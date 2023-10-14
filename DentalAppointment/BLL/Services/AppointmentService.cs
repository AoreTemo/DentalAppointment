using Core.Models;
using DAL.Repositories;

namespace BLL.Services;

public class AppointmentService : GenericService<Appointment>
{
    protected AppointmentService(UnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

}

