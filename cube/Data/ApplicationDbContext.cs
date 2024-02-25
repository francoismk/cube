using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace cube;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {}

    public DbSet<Location> Locations { get; set; }

    public DbSet<Employee> Employees { get; set; }

    public DbSet<Service> Services { get; set; }

    public DbSet<User> Users { get; set; }
}
