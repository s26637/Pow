using Powtórka.Models;

namespace Powtórka.Services;

public interface IDbService 
{
    public Task<ICollection<Chatacter>> GetCharactersData(int id);
    
    public Task<ICollection<Item>> GetItemData(int id);

    public Task<bool> DoesCharacterExist(int id);

    public Task<bool> DoesItemExist(int id);

    public Task AddNewItemToCharacter(IEnumerable<Backpack> backpacks);


}