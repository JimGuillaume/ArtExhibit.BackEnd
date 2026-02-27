using ArtExhibit.BackEnd.Domain.Entities;

namespace ArtExhibit.BackEnd.Application.Interfaces.Repositories;

public interface ISubmissionRepository
{
    Task<IEnumerable<Submission>> GetAllAsync();

    Task<Submission?> GetByIdAsync(int id);

    Task<Submission?> AddAsync(Submission submission);

    Task UpdateAsync(Submission submission);

    Task DeleteAsync(int id);
}