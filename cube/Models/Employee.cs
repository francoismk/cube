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

// var employeeDto = new EmployeeDTO
// {
//     EmployeeId = employee.EmployeeId,
//     EmployeeFirstName = employee.EmployeeFirstName,
//     EmployeeLastName = employee.EmployeeLastName,
//     EmployeeBirthDate = employee.EmployeeBirthDate,
//     ServiceName = employee.Service?.ServiceName, // Utiliser ?. pour la sécurité null
//     ServiceDescription = employee.Service?.ServiceDescription,
//     LocationName = employee.Service?.Location?.LocationName // Chaînage sécurisé pour le cas où Service ou Location pourrait être null
// };
