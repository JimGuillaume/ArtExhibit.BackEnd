using ArtExhibit.BackEnd.Application.DTOs;

namespace ArtExhibit.BackEnd.Application.Interfaces.Services;

public interface IUserService
{
    Task<IEnumerable<UserDTO>> GetAllUserAsync();
    Task<UserDTO?> GetUserByIdAsync(int id);
    Task<UserDTO?> GetByCredentialsAsync(LoginDTO loginDto);
    Task<UserDTO?> GetByRefreshTokenAsync(string refreshToken);
    Task<UserDTO?> AddUserAsync(RegisterDTO UserDto);
    Task StoreRefreshTokenAsync(int userId, string refreshToken, DateTime expiresAtUtc);
    Task RevokeRefreshTokenAsync(int userId);
    Task UpdateUserAsync(UpdateUserDTO UserDto);
    Task DeleteUserAsync(int id);
}