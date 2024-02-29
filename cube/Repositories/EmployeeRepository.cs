
namespace cube;

public class EmployeeRepository : BaseRepository, IRepositoryData<Employee>
{
    public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext) {}

    public bool Create(Employee entity)
    {
       _dbContext.Add(entity);
       _dbContext.SaveChanges();
       return true;
    }

    public bool Delete(Employee entity)
    {
        _dbContext.Remove(entity);
        _dbContext.SaveChanges();
        return true;
    }

    public List<Employee> GetAll()
    {
        return _dbContext.Employees.ToList();
    }

    public Employee? GetById(int id)
    {
        return _dbContext.Employees.Find(id);
    }

    public bool Update(Employee entity)
    {
        _dbContext.Update(entity);
        _dbContext.SaveChanges();
        return true;
    }
}
