using Microsoft.EntityFrameworkCore;
using Powtórka.Data;
using Powtórka.Models;

namespace Powtórka.Services;

public class DbService : IDbService
{
     
     private readonly DatabaseContext _context;
     public DbService(DatabaseContext context)
     {
         _context = context;
     }
     public async Task<ICollection<Chatacter>> GetCharactersData(int id)
     {
         return await _context.Chatacters
             .Include(e => e.Backpacks)
             .ThenInclude(e => e.Item)
             .Include(e => e.CharacterTitles)
             .ThenInclude(e => e.Title)
             .Where(e => e.Id == id)
             .ToListAsync();
     }

     public async Task<bool> DoesCharacterExist(int id)
     {
         return await _context.Chatacters.AnyAsync(e => e.Id == id);
     }


     public async Task<bool> DoesItemExist(int id)
     {
         return await  _context.Items.AnyAsync(e => e.Id == id);
     }

     public async Task<ICollection<Item>> GetItemData(int id)
     {
         return await _context.Items.Where(e => e.Id == id).ToListAsync();
     }
     public async Task AddNewItemToCharacter(IEnumerable<Backpack> backpacks)
     {
         await _context.AddRangeAsync(backpacks);
         await _context.SaveChangesAsync();
     }
     

}