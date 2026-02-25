using ArtExhibit.BackEnd.Application.DTOs;
using ArtExhibit.BackEnd.Application.Interfaces.Repositories;
using ArtExhibit.BackEnd.Application.Interfaces.Services;
using ArtExhibit.BackEnd.Domain.Entities;

namespace ArtExhibit.BackEnd.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
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

    public async Task<UserDTO?> AddUserAsync(RegisterDTO UserDTO)
    {
        var user = new User
        {
            UserName = UserDTO.UserName,
            FirstName = UserDTO.FirstName,
            LastName = UserDTO.LastName,
            UserEmail = UserDTO.Email,
            UserTypeId = 2 // Default to regular user
        };

        var NewUser = await _repository.AddAsync(user);
        if (NewUser != null)
            return MapToDTO(NewUser);
        return null;
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
