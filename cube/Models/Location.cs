namespace cube;

public class Location
{
    public int Id { get; set; }
    public required string LocationName { get; set; }

    public ICollection<Service> Services { get; set; }
}
