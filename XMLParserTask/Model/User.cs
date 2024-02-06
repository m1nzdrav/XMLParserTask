using System.ComponentModel.DataAnnotations;

namespace XMLParserTask.Model;

public class User
{
    [Key] public int Id { get; set; }

    public string? UserName { get; set; }

    public long? PhoneNumber { get; set; }
    public string? Email { get; set; }
}