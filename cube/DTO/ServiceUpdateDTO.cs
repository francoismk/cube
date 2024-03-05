using System.ComponentModel.DataAnnotations;

namespace Namespace;
public class ServiceUpdateDTO
{
    [Required]
    public string ServiceName { get; set; }

    // public string LocationName { get; set; }
}
