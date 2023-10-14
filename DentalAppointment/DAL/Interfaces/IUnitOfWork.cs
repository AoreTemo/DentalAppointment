using DAL.Interfaces;

namespace DAL.Repositories;

public interface IUnitOfWork : IDisposable
{
    IRepository<T> GetRepository<T>() where T : class;

    void Save();
}
