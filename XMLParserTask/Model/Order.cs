using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XMLParserTask.Model;

public class Order
{
    [Key] public int Id { get; set; }
    public DateOnly? Date { get; set; }
    public string? Status { get; set; }
    public decimal? Sum { get; set; }
    public int UserId { get; set; }

    [ForeignKey("UserId")] public Users Users { get; set; }
}