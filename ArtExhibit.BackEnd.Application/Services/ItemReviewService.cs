using ArtExhibit.BackEnd.Application.DTOs;
using ArtExhibit.BackEnd.Application.Interfaces.Repositories;
using ArtExhibit.BackEnd.Application.Interfaces.Services;
using ArtExhibit.BackEnd.Domain.Entities;

namespace ArtExhibit.BackEnd.Application.Services;

public class ItemReviewService : IItemReviewService
{

    private readonly IItemReviewRepository _repository;

    public ItemReviewService(IItemReviewRepository repository)
    {
        _repository = repository; 
    }
    private ItemReviewDTO MapToDTO(ItemReview itemreview)
    {
        return new ItemReviewDTO
        {
            Id = itemreview.Id,
            UserId = itemreview.UserId,
            ItemId = itemreview.ItemId,
            Review = itemreview.Review
        };
    }
    public async Task<IEnumerable<ItemReviewDTO>> GetAllItemReviewAsync()
    {
        var itemreviews = await _repository.GetAllAsync();
        var dtos = new List<ItemReviewDTO>();
        foreach (var itemreview in itemreviews)
        {
            dtos.Add(MapToDTO(itemreview));
        }
        return dtos;
    }

    public async Task<ItemReviewDTO?> GetItemReviewByIdAsync(int id)
    {
        var itemreview = await _repository.GetByIdAsync(id);
        if (itemreview != null)
            return MapToDTO(itemreview);
        return null;
    }
    public async Task<ItemReviewDTO?> AddItemReviewAsync(CreateItemReviewDTO itemreviewDTO)
    {
        var itemreview = new ItemReview
        {
            UserId = itemreviewDTO.UserId,
            ItemId = itemreviewDTO.ItemId,
            Review = itemreviewDTO.Review
        };
        var newitemreview = await _repository.AddAsync(itemreview);
        if (newitemreview != null)
            return MapToDTO(newitemreview);
        return null;
    }
    public async Task UpdateItemReviewAsync(UpdateItemReviewDTO itemreviewDTO)
    {
        var itemreview = await _repository.GetByIdAsync(itemreviewDTO.Id);
        if (itemreview == null) throw new Exception("Review not found");
        itemreview.Id = itemreviewDTO.Id;
        itemreview.UserId = itemreviewDTO.UserId;
        itemreview.ItemId = itemreviewDTO.ItemId;
        itemreview.Review = itemreviewDTO.Review;
        await _repository.UpdateAsync(itemreview);
    }
    public async Task DeleteItemReviewAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}
