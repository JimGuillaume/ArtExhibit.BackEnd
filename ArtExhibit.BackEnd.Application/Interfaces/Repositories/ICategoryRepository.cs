using ArtExhibit.BackEnd.Domain.Entities;

namespace ArtExhibit.BackEnd.Application.Interfaces.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllAsync();

    Task<Category?> GetByIdAsync(int id);

    Task<Category?> AddAsync(Category category);

    Task UpdateAsync(Category category);

    Task DeleteAsync(int id);
}
