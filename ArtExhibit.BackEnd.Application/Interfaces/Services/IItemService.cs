using ArtExhibit.BackEnd.Application.DTOs;

namespace ArtExhibit.BackEnd.Application.Interfaces.Services;

public interface IItemService
{
    Task<IEnumerable<ItemDTO>> GetAllItemsAsync();
    Task<ItemDTO?> GetItemByIdAsync(int id);
    Task<ItemDTO?> AddItemAsync(CreateItemDTO itemDTO);
    Task UpdateItemAsync(UpdateItemDTO itemDTO);
    Task DeleteItemAsync(int id);
}
