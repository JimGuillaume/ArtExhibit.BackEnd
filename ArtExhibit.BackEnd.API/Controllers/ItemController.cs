using ArtExhibit.BackEnd.Application.DTOs;
using ArtExhibit.BackEnd.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArtExhibit.BackEnd.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemController : ControllerBase
{
    private readonly IItemService _service;

    public ItemController(IItemService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        return Ok(await _service.GetAllItemsAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAsync(int id)
    {
        var item = await _service.GetItemByIdAsync(id);
        if (item == null)
            return NotFound();
        return Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateItemDTO itemDTO)
    {
        var item = await _service.AddItemAsync(itemDTO);
        return Ok(item);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(UpdateItemDTO itemDTO)
    {
        await _service.UpdateItemAsync(itemDTO);
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteItemAsync(id);
        return NoContent();
    }
}
