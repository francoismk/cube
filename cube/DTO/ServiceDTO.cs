using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace cube;

public class ServiceDTO
{
    [Required]
    public string ServiceName { get; set; }
    [Required]
    public string ServiceDescription {get; set;}

    public List<int> Employees { get; set; } = new List<int>();
}
