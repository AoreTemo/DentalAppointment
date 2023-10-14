using System.Linq.Expressions;

namespace BLL.Services;

public interface IGenericService<T> where T : class
{
    T? GetById(int id);
    List<T> GetByPredicate(Expression<Func<T, bool>> filter = null,
        Expression<Func<IQueryable<T>, IOrderedQueryable<T>>> orderBy = null);
}