using DAL.Interfaces;
using DAL.Repositories;
using System.Linq.Expressions;
using BLL.Interface;

namespace BLL.Services;

public abstract class GenericService<T> : IGenericService<T>
{
    protected IRepository<T> _repository;

    protected GenericService(IRepository<T> repository)
    {
        _repository = repository;
    }


    public void Add(T item)
    {
        _repository.Add(item);
        _repository.SaveChanges();
    }

    public T? GetById(int id)
    {
        var item = _repository.FindById(id);

        return item;
    }

    public List<T> GetByPredicate(Expression<Func<T, bool>> filter = null, Expression<Func<IQueryable<T>, IOrderedQueryable<T>>> orderBy = null)
    {
        var query = _repository.GetAll().AsQueryable();
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