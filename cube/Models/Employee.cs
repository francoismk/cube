namespace cube;

public class Employee
{
    public int EmployeeId {get; set; }
    public required string EmployeeFirstName { get; set; }
    public  required string EmployeeLastName { get; set; }

    public DateTime EmployeeBirthDate { get; set; }

    // ForeignKey
    public int ServiceId { get; set; }

    public required Service Service {get; set; }
}
