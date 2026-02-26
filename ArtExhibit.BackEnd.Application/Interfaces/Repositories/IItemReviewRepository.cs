using ArtExhibit.BackEnd.Domain.Entities;

namespace ArtExhibit.BackEnd.Application.Interfaces.Repositories;

public interface IItemReviewRepository
{
    Task<IEnumerable<ItemReview>> GetAllAsync();
    Task<ItemReview?> GetByIdAsync(int id);
    Task<ItemReview?> AddAsync(ItemReview itemreview);
    Task UpdateAsync(ItemReview itemreview);
    Task DeleteAsync(int id);
}