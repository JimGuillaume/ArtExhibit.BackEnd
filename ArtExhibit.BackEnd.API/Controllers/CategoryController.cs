using ArtExhibit.BackEnd.Application.DTOs;
using ArtExhibit.BackEnd.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArtExhibit.BackEnd.API.Controllers;



[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _service;

    public CategoryController(ICategoryService service)
    {
        _service = service; 
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        return Ok(await _service.GetAllCategoryAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAsync(int id)
    {
        var category = await _service.GetCategoryByIdAsync(id);
        if(category == null)
            return NotFound();
        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateCategoryDTO categoryDTO)
    {
        var category = await _service.AddCategoryAsync(categoryDTO);
        return Ok(category);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(UpdateCategoryDTO categoryDTO)
    {
        await _service.UpdateCategoryAsync(categoryDTO);
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteCategoryAsync(id);
        return NoContent();
    }
}