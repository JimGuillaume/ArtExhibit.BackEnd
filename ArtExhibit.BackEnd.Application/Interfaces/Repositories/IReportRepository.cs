using ArtExhibit.BackEnd.Domain.Entities;

namespace ArtExhibit.BackEnd.Application.Interfaces.Repositories;

public interface IReportRepository
{
    Task<IEnumerable<Report>> GetAllAsync();
    Task<Report?> GetByIdAsync(int id);
    Task<Report?> AddAsync(Report report);
    Task UpdateAsync(Report report);
    Task DeleteAsync(int id);
}