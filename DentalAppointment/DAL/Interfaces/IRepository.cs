using Microsoft.EntityFrameworkCore;

namespace DAL.Interfaces;

public interface IRepository<T> where T : class
{
    List<T> GetAllAsList();
    DbSet<T> GetAllAsTable();
    void Add(T item);
    T? FindById(int id);
    void SaveChanges();
}
