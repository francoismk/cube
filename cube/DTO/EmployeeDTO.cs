using System.ComponentModel.DataAnnotations;

namespace cube;

public class EmployeeDTO
{
    public int EmployeeId { get; set; }
    [Required]
    public string EmployeeFirstName { get; set; }
    [Required]
    public string EmployeeLastName { get; set; }
    public string EmployeeLandline { get; set; }
    public string EmployeePhoneNumber { get; set; }
    public string EmployeeEmail { get; set; }
    public string ServiceName { get; set; }
    public string LocationName { get; set; }
}
