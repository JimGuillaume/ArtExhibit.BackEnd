using ArtExhibit.BackEnd.Application.DTOs;
using ArtExhibit.BackEnd.Application.Interfaces.Services;
using ArtExhibit.BackEnd.Application.Interfaces.Repositories;
using ArtExhibit.BackEnd.Domain.Entities;

namespace ArtExhibit.BackEnd.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;

    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository; 
    }


    private CategoryDTO MapToDTO(Category category)
    {
        return new CategoryDTO
        {
            Id = category.Id,
            Name = category.Name,
        };
    }

    public async Task<IEnumerable<CategoryDTO>> GetAllCategoryAsync()
    {
        var categories = await _repository.GetAllAsync();
        var dtos = new List<CategoryDTO>();
        foreach (var category in categories)
        {
            dtos.Add(MapToDTO(category));
        }
        return dtos;
    }


    public async Task<CategoryDTO?> GetCategoryByIdAsync(int id)
    {
        var category = await _repository.GetByIdAsync(id);
        if (category == null)
            return null;
        return MapToDTO(category);
    }

    public async Task<CategoryDTO?> AddCategoryAsync(CreateCategoryDTO categoryDTO)
    {
        var category = new Category
        {
            Name = categoryDTO.Name
        };
        var newcategory = await _repository.AddAsync(category);
        if(newcategory != null)
            return MapToDTO(category);
        return null;
    }

    public async Task UpdateCategoryAsync(UpdateCategoryDTO categoryDTO)
    {
        var category = await _repository.GetByIdAsync(categoryDTO.Id);
        if (category == null) throw new Exception("Category Not found");
        category.Name = categoryDTO.Name;
        await _repository.UpdateAsync(category);
    }

    public async Task DeleteCategoryAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}