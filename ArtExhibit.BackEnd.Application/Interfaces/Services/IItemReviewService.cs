using ArtExhibit.BackEnd.Application.DTOs;

namespace ArtExhibit.BackEnd.Application.Interfaces.Services;

public interface IItemReviewService
{
    Task<IEnumerable<ItemReviewDTO>> GetAllItemReviewAsync();
    Task<ItemReviewDTO?> GetItemReviewByIdAsync(int id);
    Task<ItemReviewDTO?> AddItemReviewAsync(CreateItemReviewDTO itemreviewDTO);
    Task UpdateItemReviewAsync(UpdateItemReviewDTO itemreviewDTO);
    Task DeleteItemReviewAsync(int id);
}
