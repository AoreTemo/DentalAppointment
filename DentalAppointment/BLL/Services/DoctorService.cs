using DAL.Repositories;

namespace BLL.Services;

public class DoctorService : GenericService<Doctor>
{
    protected DoctorService(UnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
}
