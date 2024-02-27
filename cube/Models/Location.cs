namespace cube;

public class Location
{
    public int Id { get; set; }
    public required string LocationName { get; set; }
    public int ZipCode { get; set; }

    public required ICollection<Service> Services { get; set; }
}
