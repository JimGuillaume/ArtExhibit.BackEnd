using ArtExhibit.BackEnd.Application.DTOs;
using ArtExhibit.BackEnd.Application.Interfaces.Repositories;
using ArtExhibit.BackEnd.Application.Interfaces.Services;
using ArtExhibit.BackEnd.Domain.Entities;
using System.Runtime.InteropServices;

namespace ArtExhibit.BackEnd.Application.Services;
    public class UserTypeService : IUserTypeService
    {

    private readonly IUserTypeRepository _repository;

    public UserTypeService(IUserTypeRepository repository)
    {
        _repository = repository;
    }


    private UserTypeDTO MapToDTO(UserType usertype)
    {
        return new UserTypeDTO
        {
            Id = usertype.Id,
            Name = usertype.Name,
        };
    }

    public async Task<IEnumerable<UserTypeDTO>> GetAllCategoryAsync()
    {
        var usertypes = await _repository.GetAllAsync();
        var dtos = new List<UserTypeDTO>();
        foreach (var usertype in usertypes)
        {
            dtos.Add(MapToDTO(usertype));
        }
        return dtos;
    }

    public async Task<UserTypeDTO?> GetCategoryByIdAsync(int id)
    {
        var usertype = await _repository.GetByIdAsync(id);
        if (usertype == null)
            return null;
        return MapToDTO(usertype);
    }

    public async Task<UserTypeDTO?> AddCategoryAsync(CreateUserTypeDTO usertypeDTO)
    {
        var usertype = new UserType
        {
            Name = usertypeDTO.Name,
        };
        var newusertype = await _repository.AddAsync(usertype);
        if (newusertype != null)
            return MapToDTO(newusertype);
        return null;

    }
    public async Task UpdateCategoryAsync(UpdateUserTypeDTO usertypeDTO)
    {
        var usertype = await _repository.GetByIdAsync(usertypeDTO.Id);
        if (usertype == null) throw new Exception("User type not found");
        usertype.Name = usertypeDTO.Name;
        await _repository.UpdateAsync(usertype);
    }
    public async Task DeleteCategoryAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}
