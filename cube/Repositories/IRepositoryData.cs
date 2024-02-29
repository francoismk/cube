namespace cube;

public interface IRepositoryData<T>
{
    bool Create(T entity);
    List<T> GetAll();
    T ?GetById(int id);
    bool Update (T entity);
    bool Delete(T entity);
}
