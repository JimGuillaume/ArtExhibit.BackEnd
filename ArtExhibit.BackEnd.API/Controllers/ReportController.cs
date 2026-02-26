using ArtExhibit.BackEnd.Application.DTOs;
using ArtExhibit.BackEnd.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArtExhibit.BackEnd.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReportController : ControllerBase
{
    private readonly IReportService _service;

    public ReportController(IReportService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        return Ok(await _service.GetAllReportAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAsync(int id)
    {
        var report = await _service.GetReportByIdAsync(id);
        if (report == null)
            return NotFound();
        return Ok(report);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateReportDTO reportDTO)
    {
        var report = await _service.AddReportAsync(reportDTO);
        return Ok(report);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(UpdateReportDTO reportDTO)
    {
        await _service.UpdateReportAsync(reportDTO);
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteReportAsync(id);
        return NoContent();
    }
}