using ArtExhibit.BackEnd.Application.DTOs;

namespace ArtExhibit.BackEnd.Application.Interfaces.Services;

public interface IReportService
{
    Task<IEnumerable<ReportDTO>> GetAllReportAsync();
    Task<ReportDTO?> GetReportByIdAsync(int id);
    Task<ReportDTO?> AddReportAsync(CreateReportDTO reportDTO);
    Task UpdateReportAsync(UpdateReportDTO reportDTO);
    Task DeleteReportAsync(int id);
}
