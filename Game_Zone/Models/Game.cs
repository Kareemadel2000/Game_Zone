
namespace Game_Zone.Models;
public class Game : BaseEntity
{

    [MaxLength(2500)]
    public string? Description { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? Cover { get; set; } = string.Empty;

    // nav prop
    public int CategoryId { get; set; }
    public Category Category { get; set; } = default!;

    public ICollection<GameDevice> Devices { get; set; } = new List<GameDevice>();
}
