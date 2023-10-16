using System.Linq.Expressions;
using BLL.Interface;
using Core.Models;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services;

public class AppointmentService : GenericService<Appointment>, IAppointmentService
{
    public AppointmentService(IRepository<Appointment> repository) : base(repository)
    {
    }

    public new List<Appointment> GetByPredicate(Expression<Func<Appointment, bool>> filter = null, Expression<Func<IQueryable<Appointment>, IOrderedQueryable<Appointment>>> orderBy = null)
    {
        var query = _repository.GetAllAsTable().Include(
            a => a.Doctor
        ).Include(
            a => a.AppUser
        ).AsQueryable();
        if (filter != null)
        {
            query = query.Where(filter);
        }
        if (orderBy != null)
        {
            query = orderBy.Compile()(query);
        }
        return query.ToList();
    }
}

