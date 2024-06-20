using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Powtórka.Models;


[Table("item")]
public class Item
{
    [Key]
    public int Id { get; set; }

    [MaxLength(120)] 
    public string Name { get; set; } = string.Empty;
    
    public int Weight { get; set; }
    
    public ICollection<Backpack> Backpacks { get; set; } = new List<Backpack>();

}

// Brak gitignore
// Nie wszystkie nazwy tabel są zgodne ze schematem
// Błędny routing
// Brak wszystkich danych dla postaci
// Brak sprawdzenia czy postać istnieje
// Brak pełnej realizacji drugiej końcówki