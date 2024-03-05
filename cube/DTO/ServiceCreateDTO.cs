using System.ComponentModel.DataAnnotations;

namespace Namespace;
public class ServiceCreateDTO
{
    public string ServiceName { get; set; }
    [Required]
    public string LocationName { get; set; }
}
