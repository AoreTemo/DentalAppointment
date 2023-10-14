using Core.Models;
using DAL.Interfaces;
using DAL.Repositories;

namespace BLL.Services;

public class AppUserService : GenericService<AppUser>
{
    protected AppUserService(IRepository<AppUser> repository) : base(repository)
    {
    }
}
