using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace cube;

public class ServiceDTO
{
    [Required]
    public int ServiceId { get; set; }
    public string ServiceName { get; set; }
    [Required]
    public string LocationName { get; set; }
}
