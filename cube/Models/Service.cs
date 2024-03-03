namespace cube;

public class Service
{
    public int ServiceId { get; set; }
    public required string ServiceName { get; set; }

    public required ICollection<Employee> Employees { get; set; }

    public int LocationId { get; set; }

    public required Location Location { get; set; }
    public Service(string serviceName)
    {
        ServiceName = serviceName;
        Employees = new List<Employee>();
    }

}
