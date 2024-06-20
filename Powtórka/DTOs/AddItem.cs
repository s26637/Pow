using System.ComponentModel.DataAnnotations;

namespace Powtórka.DTOs;


public class AddItem
{
    [Required] public List<int> ItemsList { get; set; } = new List<int>();
    
}