using ArtExhibit.BackEnd.Application.DTOs;
using ArtExhibit.BackEnd.Application.Interfaces.Services;
using ArtExhibit.BackEnd.Application.Interfaces.Repositories;
using ArtExhibit.BackEnd.Domain.Entities;

namespace ArtExhibit.BackEnd.Application.Services;

public class ItemService : IItemService
{
    private readonly IItemRepository _repository;

    public ItemService(IItemRepository repository)
    {
        _repository = repository;
    }

    private ItemDTO MapToDTO(Item item)
    {
        return new ItemDTO
        {
            Id = item.Id,
            Name = item.Name,
            Description = item.Description,
            Price = item.Price,
            Tags = item.Tags,
            CategoryId = item.CategoryId,
            CategoryName = item.Category?.Name ?? string.Empty,
            UserId = item.UserId,
            UserName = item.User?.UserName ?? string.Empty
        };
    }

    public async Task<IEnumerable<ItemDTO>> GetAllItemsAsync()
    {
        var items = await _repository.GetAllAsync();
        var dtos = new List<ItemDTO>();
        foreach (var item in items)
        {
            dtos.Add(MapToDTO(item));
        }
        return dtos;
    }

    public async Task<ItemDTO?> GetItemByIdAsync(int id)
    {
        var item = await _repository.GetByIdAsync(id);
        if (item == null)
            return null;
        return MapToDTO(item);
    }

    public async Task<ItemDTO?> AddItemAsync(CreateItemDTO itemDTO)
    {
        var item = new Item
        {
            Name = itemDTO.Name,
            Description = itemDTO.Description,
            Price = itemDTO.Price,
            Tags = itemDTO.Tags,
            CategoryId = itemDTO.CategoryId,
            UserId = itemDTO.UserId
        };
        var newItem = await _repository.AddAsync(item);
        if (newItem != null)
        {
            var itemWithRelations = await _repository.GetByIdAsync(newItem.Id);
            if (itemWithRelations != null)
                return MapToDTO(itemWithRelations);
        }
        return null;
    }

    public async Task UpdateItemAsync(UpdateItemDTO itemDTO)
    {
        var item = await _repository.GetByIdAsync(itemDTO.Id);
        if (item == null) throw new Exception("Item not found");
        
        item.Name = itemDTO.Name;
        item.Description = itemDTO.Description;
        item.Price = itemDTO.Price;
        item.Tags = itemDTO.Tags;
        item.CategoryId = itemDTO.CategoryId;
        item.UserId = itemDTO.UserId;
        
        await _repository.UpdateAsync(item);
    }

    public async Task DeleteItemAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}
