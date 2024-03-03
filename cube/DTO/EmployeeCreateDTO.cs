using System.ComponentModel.DataAnnotations;

namespace Namespace;
public class EmployeeCreateDTO
{
    [Required]
    public string EmployeeFirstName { get; set; }
    [Required]
    public string EmployeeLastName { get; set; }
    [Required]
    public string EmployeeLandline { get; set; }
    [Required]
    public string EmployeePhoneNumber { get; set; }
    [Required]
    public string EmployeeEmail { get; set; }
    [Required]
    public string ServiceName { get; set; }
    [Required]
    public string LocationName { get; set; }
}
