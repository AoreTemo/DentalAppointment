using System.Linq.Expressions;
using BLL.Interface;
using Core.Models;
using DAL.Interfaces;
using DAL.Repositories;

namespace BLL.Services;

public class DoctorService : GenericService<Doctor>, IDoctorService
{
    public  DoctorService(IRepository<Doctor> repository) : base(repository)
    {
    }
}
