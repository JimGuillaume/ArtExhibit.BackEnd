using ArtExhibit.BackEnd.Application.DTOs;
using ArtExhibit.BackEnd.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArtExhibit.BackEnd.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemReviewController : ControllerBase
{
    private readonly IItemReviewService _service;

    public ItemReviewController(IItemReviewService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        return Ok(await _service.GetAllItemReviewAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAsync(int id)
    {
        var itemreview = await _service.GetItemReviewByIdAsync(id);
        if (itemreview == null)
            return NotFound();
        return Ok(itemreview);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateItemReviewDTO itemreviewDTO)
    {
        var category = await _service.AddItemReviewAsync(itemreviewDTO);
        return Ok(category);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(UpdateItemReviewDTO itemreviewDTO)
    {
        await _service.UpdateItemReviewAsync(itemreviewDTO);
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteItemReviewAsync(id);
        return NoContent();
    }
}