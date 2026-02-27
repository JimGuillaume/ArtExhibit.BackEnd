using ArtExhibit.BackEnd.Application.DTOs;

namespace ArtExhibit.BackEnd.Application.Interfaces.Services;

public interface ISubmissionService
{
    Task<IEnumerable<SubmissionDTO>> GetAllSubmissionAsync();
    Task<SubmissionDTO?> GetSubmissionByIdAsync(int id);
    Task<SubmissionDTO?> AddSubmissionAsync(CreateSubmissionDTO submissionDTO);
    Task UpdateSubmissionAsync(UpdateSubmissionDTO submissionDTO);
    Task DeleteSubmissionAsync(int id);
}