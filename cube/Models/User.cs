namespace cube;

public class User
{
    public int UserId { get; set; }

    public required Boolean IsAdmin { get; set; }

    public required string UserEmail { get; set; }

    public required string UserPassword { get; set; }

    public required string UserFirstName { get; set; }

    public required string UserLastName { get; set; }
}
