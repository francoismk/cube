namespace cube;

public class Service
{
    public int ServiceId { get; set; }
    public required string ServiceName {get; set; }

    public required string ServiceDescription {get; set; }

    public required ICollection<Employee> Employees {get; set; }

    public Service(string serviceName, string serviceDescription, ICollection<Employee> employees) {
        ServiceName = serviceName;
        ServiceDescription = serviceDescription;
        Employees = employees;
    }

    public Service() {}
}
