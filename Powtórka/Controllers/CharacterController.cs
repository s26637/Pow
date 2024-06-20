using Microsoft.AspNetCore.Mvc;
using Powtórka.DTOs;
using Powtórka.Services;

namespace Powtórka.Controllers;

public class CharacterController : ControllerBase
{
    private readonly IDbService _dbService;
    public CharacterController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("api/characters/{characterId}")]
    public async Task<IActionResult> GetCharactersData(int characterId)
    {
        var characters = await _dbService.GetCharactersData(characterId);

        
        if (!await _dbService.DoesCharacterExist(characterId))
        {
           return NotFound("Brak osoby"); 
        }
        
        
        return Ok(characters.Select(e => new GetCharacterDTO()
        {
            FirstName = e.FirstName,
            LastName = e.LastName,
            CurrentWei = e.CurrentWei,
            MaxWeight = e.MaxWeight,
            backpacksItems = e.Backpacks.Select(p => new GetBackpacksDTO
            {
                ItemName = p.Item.Name,
                ItemWeight = p.Item.Weight,
                Amount = p.Amount
                
            }).ToList(),
            titles = e.CharacterTitles.Select(d => new TitlesDTO()
            {
                title = d.Title.Name,
                aquiredAt = d.AcquiredAt
            }).ToList()
        }));
    }
}