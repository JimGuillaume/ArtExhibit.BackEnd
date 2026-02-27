using ArtExhibit.BackEnd.Application.DTOs;
using ArtExhibit.BackEnd.Application.Interfaces.Repositories;
using ArtExhibit.BackEnd.Application.Interfaces.Services;
using ArtExhibit.BackEnd.Domain.Entities;

namespace ArtExhibit.BackEnd.Application.Services;

public class SubmissionService : ISubmissionService
{
    private readonly ISubmissionRepository _repository;

    public SubmissionService(ISubmissionRepository repository)
    {
        _repository = repository; 
    }

    private SubmissionDTO MapToDTO(Submission submission)
    {
        return new SubmissionDTO
        {
            Id = submission.Id,
            UserId = submission.UserId,
            ItemId = submission.ItemId,
            Date = submission.Date,
            Status = submission.Status,
            RejectionReason = submission.RejectionReason
        };
    }
    public async Task<IEnumerable<SubmissionDTO>> GetAllSubmissionAsync()
    {
        var submissions = await _repository.GetAllAsync();
        var dtos = new List<SubmissionDTO>();
        foreach (var submission in submissions)
        {
            dtos.Add(MapToDTO(submission)); 
        }
        return dtos;
    }
    public async Task<SubmissionDTO?> GetSubmissionByIdAsync(int id)
    {
        var submission = await _repository.GetByIdAsync(id);
        if (submission != null)
            return MapToDTO(submission);
        return null;
    }
    public async Task<SubmissionDTO?> AddSubmissionAsync(CreateSubmissionDTO submissionDTO)
    {
        var submission = new Submission
        {
            UserId = submissionDTO.UserId,
            ItemId = submissionDTO.ItemId,
            Date = submissionDTO.Date
        };
        var newsubmission = await _repository.AddAsync(submission);
        if (newsubmission != null)
            return MapToDTO(newsubmission);
        return null;
    }
    public async Task UpdateSubmissionAsync(UpdateSubmissionDTO submissionDTO)
    {
        var submission = await _repository.GetByIdAsync(submissionDTO.Id);
        if (submission == null) throw new Exception("Submission not found");
        submission.Id = submissionDTO.Id;
        submission.UserId = submissionDTO.UserId;
        submission.ItemId = submissionDTO.ItemId;
        submission.Date = submissionDTO.Date;
        submission.Status = submissionDTO.Status;
        submission.RejectionReason = submissionDTO.RejectionReason;

        await _repository.UpdateAsync(submission);
    }
    public async Task DeleteSubmissionAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}