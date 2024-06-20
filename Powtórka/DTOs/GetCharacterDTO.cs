namespace Powtórka.DTOs;

public class GetCharacterDTO
{
    public string FirstName { get; set; } = string.Empty; 
    public string LastName { get; set; } = string.Empty;
    public int CurrentWei { get; set; }
    public int MaxWeight { get; set; }

    public ICollection<GetBackpacksDTO> backpacksItems { get; set; } = null!;
    public ICollection<TitlesDTO> titles { get; set; } =  null!;
}

public class GetBackpacksDTO
{
    public string ItemName { get; set; } = null!;
    public int ItemWeight { get; set; }
    public int Amount { get; set; }

}

public class TitlesDTO
{
    public string title { get; set; }
    public DateTime aquiredAt { get; set; }
}