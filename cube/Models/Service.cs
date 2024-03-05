namespace cube;

public class Service
{
    public int ServiceId { get; set; }
    public string ServiceName { get; set; }

    public ICollection<Employee> Employees { get; set; }

    public int LocationId { get; set; }

    public Location Location { get; set; }
    public Service(string serviceName)
    {
        ServiceName = serviceName;
        Employees = new List<Employee>();
    }

}
