using ArtExhibit.BackEnd.Application.DTOs;

namespace ArtExhibit.BackEnd.Application.Interfaces.Services;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDTO>> GetAllCategoryAsync();
    Task<CategoryDTO?> GetCategoryByIdAsync(int id);
    Task<CategoryDTO?> AddCategoryAsync(CreateCategoryDTO categoryDTO);
    Task UpdateCategoryAsync(UpdateCategoryDTO categoryDTO);
    Task DeleteCategoryAsync(int id);
}

