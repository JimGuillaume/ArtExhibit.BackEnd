using ArtExhibit.BackEnd.Application.DTOs;

namespace ArtExhibit.BackEnd.Application.Interfaces.Services;

public interface IUserTypeService
{
    Task<IEnumerable<UserTypeDTO>> GetAllCategoryAsync();
    Task<UserTypeDTO?> GetCategoryByIdAsync(int id);
    Task<UserTypeDTO?> AddCategoryAsync(CreateUserTypeDTO usertypeDTO);
    Task UpdateCategoryAsync(UpdateUserTypeDTO usertypeDTO);
    Task DeleteCategoryAsync(int id);
}