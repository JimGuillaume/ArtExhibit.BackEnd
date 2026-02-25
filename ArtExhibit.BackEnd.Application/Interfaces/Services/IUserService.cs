using ArtExhibit.BackEnd.Application.DTOs;

namespace ArtExhibit.BackEnd.Application.Interfaces.Services;

public interface IUserService
{
    Task<IEnumerable<UserDTO>> GetAllUserAsync();
    Task<UserDTO?> GetUserByIdAsync(int id);
    Task<UserDTO?> AddUserAsync(RegisterDTO UserDto);
    Task UpdateUserAsync(UpdateUserDTO UserDto);
    Task DeleteUserAsync(int id);
}