using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Powtórka.Models;

[Table("character_titles")]
[PrimaryKey(nameof(CharacterId), nameof(TitleId))]
public class CharacterTitle
{
    public int CharacterId { get; set; }
    
    public int TitleId { get; set; }
    
    public DateTime AcquiredAt { get; set; }

    [ForeignKey(nameof(CharacterId))]
    public Chatacter Chatacter { get; set; } = null!;

    [ForeignKey(nameof(TitleId))]
    public Title Title { get; set; } = null!;
}