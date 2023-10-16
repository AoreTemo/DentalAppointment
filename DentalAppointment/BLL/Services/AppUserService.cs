using BLL.Interface;
using Core.Models;
using DAL.Interfaces;
using DAL.Repositories;

namespace BLL.Services;

public class AppUserService : GenericService<AppUser>, IAppUserService
{
    public AppUserService(IRepository<AppUser> repository) : base(repository)
    {
    }
}
