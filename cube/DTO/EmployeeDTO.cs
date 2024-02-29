namespace cube;

public class EmployeeDTO
{
    public int EmployeeId {get; set; }
    public required string EmployeeFirstName { get; set; }
    public  required string EmployeeLastName { get; set; }

    public DateTime EmployeeBirthDate { get; set; }
}
