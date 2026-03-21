using ArtExhibit.BackEnd.Application.DTOs;
using ArtExhibit.BackEnd.Application.Interfaces.Repositories;
using ArtExhibit.BackEnd.Application.Interfaces.Services;
using ArtExhibit.BackEnd.Domain.Entities;
using System.Security.Cryptography;
using System.Text;

namespace ArtExhibit.BackEnd.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    private static string HashValue(string value)
    {
        return Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(value)));
    }

    private UserDTO MapToDTO(User user)
    {
        return new UserDTO
        {
            Id = user.Id,
            UserName = user.UserName,
            FirstName = user.FirstName,
            LastName = user.LastName,
            UserEmail = user.UserEmail,
            UserPhone = user.UserPhone,
            UserTypeId = user.UserTypeId,
            UserType = new UserTypeDTO
            {
                Id = user.UserType.Id,
                Name = user.UserType.Name
            }
        };
    }

    public async Task<IEnumerable<UserDTO>> GetAllUserAsync()
    {
        var users = await _repository.GetAllAsync();
        var dtos = new List<UserDTO>();
        foreach (var user in users)
        {
            dtos.Add(MapToDTO(user));
        }
        return dtos;
    }

    public async Task<UserDTO?> GetUserByIdAsync(int id)
    {
        var user = await _repository.GetByIdAsync(id);
        if (user == null)
            return null;
        return MapToDTO(user);
    }

    public async Task<UserDTO?> GetByCredentialsAsync(LoginDTO loginDto)
    {
        var user = await _repository.GetByEmailAsync(loginDto.Email);
        if (user == null)
            return null;

        var incomingPasswordHash = HashValue(loginDto.Password);
        if (!string.Equals(user.PasswordHash, incomingPasswordHash, StringComparison.Ordinal))
            return null;

        return MapToDTO(user);
    }

    public async Task<UserDTO?> GetByRefreshTokenAsync(string refreshToken)
    {
        var refreshTokenHash = HashValue(refreshToken);
        var user = await _repository.GetByRefreshTokenHashAsync(refreshTokenHash);
        if (user == null)
            return null;

        if (user.RefreshTokenRevokedAtUtc.HasValue)
            return null;

        if (!user.RefreshTokenExpiresAtUtc.HasValue || user.RefreshTokenExpiresAtUtc.Value <= DateTime.UtcNow)
            return null;

        return MapToDTO(user);
    }

    public async Task<UserDTO?> AddUserAsync(RegisterDTO UserDTO)
    {
        var existingUser = await _repository.GetByEmailAsync(UserDTO.Email);
        if (existingUser != null)
            return null;

        var user = new User
        {
            UserName = UserDTO.UserName,
            FirstName = UserDTO.FirstName,
            LastName = UserDTO.LastName,
            UserEmail = UserDTO.Email,
            PasswordHash = HashValue(UserDTO.Password),
            UserTypeId = 1
        };

        var NewUser = await _repository.AddAsync(user);
        if (NewUser != null)
        {
            var userWithUserType = await _repository.GetByIdAsync(NewUser.Id);
            if (userWithUserType != null)
                return MapToDTO(userWithUserType);
        }
        return null;
    }

    public async Task StoreRefreshTokenAsync(int userId, string refreshToken, DateTime expiresAtUtc)
    {
        var user = await _repository.GetByIdAsync(userId);
        if (user == null)
            throw new Exception("User not found");

        user.RefreshTokenHash = HashValue(refreshToken);
        user.RefreshTokenExpiresAtUtc = expiresAtUtc;
        user.RefreshTokenRevokedAtUtc = null;

        await _repository.UpdateAsync(user);
    }

    public async Task RevokeRefreshTokenAsync(int userId)
    {
        var user = await _repository.GetByIdAsync(userId);
        if (user == null)
            throw new Exception("User not found");

        user.RefreshTokenRevokedAtUtc = DateTime.UtcNow;
        await _repository.UpdateAsync(user);
    }

    public async Task UpdateUserAsync(UpdateUserDTO UserDTO)
    {
        var user = await _repository.GetByIdAsync(UserDTO.Id);
        if (user == null) throw new Exception("User not found");
        user.UserName = UserDTO.UserName;
        user.FirstName = UserDTO.FirstName;
        user.LastName = UserDTO.LastName;
        user.UserEmail = UserDTO.UserEmail;
        user.UserPhone = UserDTO.UserPhone;
        await _repository.UpdateAsync(user);
    }

    public async Task DeleteUserAsync(int id)
    {
        var user = await _repository.GetByIdAsync(id);
        if (user == null) throw new Exception("User not found");
        await _repository.DeleteAsync(id);
    }
}
