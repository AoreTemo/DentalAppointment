using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _table;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
        _table = _context.Set<T>();
    }

    public void Add(T item)
    {
        _table.Add(item);
    }

    public void Update(T item)
    {
        _table.Update(item);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var item = _table.Find(id);

        if (item != null)
        {
            _table.Remove(item);
            _context.SaveChanges();
        }
    }

    public T? FindById(int id)
    {
        var item = _table.Find(id);

        return item;
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public List<T> GetAllAsList()
    {
        var resultList = _table.ToList();

        return resultList;
    }
    
    public DbSet<T> GetAllAsTable()
    {
        return _table;
    }
}
