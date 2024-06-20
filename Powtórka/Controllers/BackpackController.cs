using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using Powtórka.DTOs;
using Powtórka.Models;
using Powtórka.Services;

namespace Powtórka.Controllers;

[Route("api/characters/{characterId}/backpacks")]
public class BackpackController  : ControllerBase
{
    
    private readonly IDbService _dbService;
    public BackpackController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpPost()]
    public async Task<IActionResult> AddItemToCharacter(int characterId, AddItem addItem)
    {
        var items = new List<Backpack>();
        int itemW = 0;

        if (!await _dbService.DoesCharacterExist(characterId))
        {
            return NotFound("Wrong Character");
        }
        
        foreach (var item in addItem.ItemsList)
        {
            if (!await _dbService.DoesItemExist(item))
            {
                return NotFound("Wrong Item");
            }
            
            items.Add(new Backpack()
            {
                CharacterId = characterId,
                ItemId = item,
                Amount = 1
            });
        }

        
        using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            await _dbService.AddNewItemToCharacter(items);
            
            scope.Complete();
        }
        
        return Created("api/orders", new
        {
            items
        });
    }



    
    
}