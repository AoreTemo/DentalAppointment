using Core.Models;
using DAL.Repositories;

namespace BLL.Services;

public class AppUserService : GenericService<AppUser>
{
    protected AppUserService(UnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
}
