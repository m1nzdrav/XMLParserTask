using System.ComponentModel.DataAnnotations;

namespace XMLParserTask.Model;

public class Product
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public float? Cost { get; set; }
    public string? Description { get; set; }
}