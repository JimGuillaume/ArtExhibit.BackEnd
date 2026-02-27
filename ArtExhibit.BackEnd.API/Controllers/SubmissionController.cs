using ArtExhibit.BackEnd.Application.DTOs;
using ArtExhibit.BackEnd.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArtExhibit.BackEnd.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubmissionController : ControllerBase
{
    private readonly ISubmissionService _service;

    public SubmissionController(ISubmissionService service)
    {
        _service = service; 
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        return Ok(await _service.GetAllSubmissionAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAsync(int id)
    {
        var submission = await _service.GetSubmissionByIdAsync(id);
        if (submission == null)
            return NotFound();
        return Ok(submission);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateSubmissionDTO submissionDTO)
    {
        var submission = await _service.AddSubmissionAsync(submissionDTO);
        return Ok(submission);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(UpdateSubmissionDTO submissionDTO)
    {
        await _service.UpdateSubmissionAsync(submissionDTO);
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteSubmissionAsync(id);
        return NoContent();
    }
}