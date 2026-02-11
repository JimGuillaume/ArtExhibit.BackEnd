using ArtExhibit.BackEnd.Domain.Entities;

namespace ArtExhibit.BackEnd.Application.Interfaces.Repositories;

public interface IUserTypeRepository
{   
    Task<IEnumerable<UserType>> GetAllAsync();

    Task<UserType?> GetByIdAsync(int id);

    Task<UserType?> AddAsync(UserType usertype);

    Task UpdateAsync(UserType usertype);

    Task DeleteAsync(int id);
}