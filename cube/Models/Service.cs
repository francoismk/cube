namespace cube;

public class Service
{
    public int ServiceId { get; set; }
    public required string ServiceName {get; set; }

    public required string ServiceDescription {get; set; }

    public required ICollection<Employee> Employees {get; set; }
}
