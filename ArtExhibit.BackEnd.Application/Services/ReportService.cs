using ArtExhibit.BackEnd.Application.DTOs;
using ArtExhibit.BackEnd.Application.Interfaces.Repositories;
using ArtExhibit.BackEnd.Application.Interfaces.Services;
using ArtExhibit.BackEnd.Domain.Entities;

namespace ArtExhibit.BackEnd.Application.Services;

public class ReportService : IReportService
{
    private readonly IReportRepository _reportRepository;
    private readonly IItemRepository _itemRepository;
    private readonly IUserRepository _userRepository;

    public ReportService(IReportRepository reportRepository, IItemRepository itemRepository, IUserRepository userRepository)
    {
        _reportRepository = reportRepository;
        _itemRepository = itemRepository;
        _userRepository = userRepository;
    }

    private ReportDTO MapToDTO(Report report)
    {
        return new ReportDTO
        {
            Id = report.Id,
            Date = report.Date,
            UserId = report.UserId,
            ItemId = report.ItemId,
            Description = report.Description
        };
    }

    public async Task<IEnumerable<ReportDTO>> GetAllReportAsync()
    {
        var reports = await _reportRepository.GetAllAsync();
        var dtos = new List<ReportDTO>();
        foreach (var report in reports)
        {
            dtos.Add(MapToDTO(report));
        }
        return dtos;
    }
    public async Task<ReportDTO?> GetReportByIdAsync(int id)
    {
        var report = await _reportRepository.GetByIdAsync(id);
        if (report == null)
            return null;
        return MapToDTO(report);
    }
    public async Task<ReportDTO?> AddReportAsync(CreateReportDTO reportDTO)
    {
        var report = new Report
        {
            Date = reportDTO.Date,
            UserId = reportDTO.UserId,
            ItemId = reportDTO.ItemId,
            Description = reportDTO.Description,
        };

        var newReport = await _reportRepository.AddAsync(report);
        if (newReport != null)
            return MapToDTO(newReport);
        return null;
    }
    public async Task UpdateReportAsync(UpdateReportDTO reportDTO)
    {
        var report = await _reportRepository.GetByIdAsync(reportDTO.Id);
        if (report == null) 
            throw new Exception("Report not found");

        report.Id = reportDTO.Id;
        report.UserId = reportDTO.UserId;
        report.ItemId = reportDTO.ItemId;
        report.Date = reportDTO.Date;
        report.Description = reportDTO.Description;

        await _reportRepository.UpdateAsync(report);
    }
    public async Task DeleteReportAsync(int id)
    {
        await _reportRepository.DeleteAsync(id);
    }
}
