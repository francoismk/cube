namespace cube;

public class Employee
{
    public int EmployeeId { get; set; }
    public required string EmployeeFirstName { get; set; }
    public required string EmployeeLastName { get; set; }
    public required string EmployeeLandline { get; set; }
    public required string EmployeePhoneNumber { get; set; }
    public required string EmployeeEmail { get; set; }

    // ForeignKey
    public int ServiceId { get; set; }

    public Service Service { get; set; }
}
