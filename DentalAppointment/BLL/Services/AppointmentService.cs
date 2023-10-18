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

    public List<Core.Models.Appointment> GetPlannedAppointments()
    {
        return GetByPredicate(filter: a => IsAppointmentPlanned(a),
            orderBy: appointments => appointments.OrderBy(
                    x => x.AppointmentDate + x.AppointmentTime
                )
            );
    }
    
    public List<Appointment>? GetCurrentAppointments()
    {
        return GetByPredicate(filter: a => IsAppointmentCurrent(a),
            orderBy: appointments => appointments.OrderBy(
                    x => x.AppointmentDate + x.AppointmentTime
                )
            );
    }
    
    public List<Appointment>? GetFinishedAppointments()
    {
        return GetByPredicate(filter: a => IsAppointmentFinished(a),
            orderBy: appointments => appointments.OrderBy(
                    x => x.AppointmentDate + x.AppointmentTime
                )
            );

    }
    public bool IsAppointmentPlanned(Appointment a)
    {
        return DateTime.Now.Date < a.AppointmentDate.Date ||
               (DateTime.Now.Hour < a.AppointmentTime.Hours && DateTime.Now.Date == a.AppointmentDate.Date);
    }
    
    public bool IsAppointmentCurrent(Appointment a)
    {
        return DateTime.Now.Hour == a.AppointmentTime.Hours && DateTime.Now.Date == a.AppointmentDate.Date;
    }
    
    public bool IsAppointmentFinished(Appointment a)
    {
        return DateTime.Now.Date > a.AppointmentDate.Date ||
               (DateTime.Now.Hour > a.AppointmentTime.Hours && DateTime.Now.Date == a.AppointmentDate.Date);
    }
    
    public new List<Appointment> GetByPredicate(Expression<Func<Appointment, bool>> filter = null, Expression<Func<IQueryable<Appointment>, IOrderedQueryable<Appointment>>> orderBy = null)
    {
        var query = _repository.GetAllAsTable().Include(
                a => a.Doctor
            ).Include(
                a => a.AppUser
            ).ToList().AsQueryable();

        if (filter != null)
        {
            query = query.Where(filter);
        }
        if (orderBy != null)
        {
            query = orderBy.Compile()(query);
        }

        if (query == null)
        {
            var result = new List<Appointment>();
            
            return result;
        }
        return query.ToList();
    }
    
    public Appointment? GetNearestAppointment()
    {
        var appointments = GetByPredicate();

        // Order the appointments by date and time.
        appointments.Sort((a, b) =>
        {
            var dateComparison = a.AppointmentDate.CompareTo(b.AppointmentDate);
            return dateComparison != 0 ? dateComparison : a.AppointmentTime.CompareTo(b.AppointmentTime);
        });

        // Find the first appointment in the future.
        return appointments.FirstOrDefault(appointment => appointment.AppointmentDate >= DateTime.Now);
    }
}

