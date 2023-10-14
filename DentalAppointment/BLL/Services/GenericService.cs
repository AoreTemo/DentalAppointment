using DAL.Interfaces;
using DAL.Repositories;
using System.Linq.Expressions;

namespace BLL.Services;

public class GenericService<T> : IGenericService<T> where T : class
{
    protected UnitOfWork _unitOfWork;
    protected IRepository<T> _repository;

    protected GenericService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _repository = unitOfWork.GetRepository<T>();
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