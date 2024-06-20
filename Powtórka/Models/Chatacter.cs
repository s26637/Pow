using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Powtórka.Models;

[Table("characters")]
public class Chatacter
{
    [Key]
    public int Id { get; set; }

    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;
    
    [MaxLength(120)]
    public string LastName { get; set; } = string.Empty;
    
    public int CurrentWei { get; set; }
    
    public int MaxWeight { get; set; }

    public ICollection<Backpack> Backpacks { get; set; } = new HashSet<Backpack>();

    public ICollection<CharacterTitle> CharacterTitles { get; set; } = new List<CharacterTitle>();
}