namespace DAL.Interfaces;

public interface IRepository<T> where T : class
{
    public List<T> GetAll();
    public void Add(T item);
    public T? FindById(int id);
}
