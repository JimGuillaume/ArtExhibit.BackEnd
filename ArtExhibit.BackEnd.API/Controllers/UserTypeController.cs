using ArtExhibit.BackEnd.Application.DTOs;
using ArtExhibit.BackEnd.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;


namespace ArtExhibit.BackEnd.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserTypeController : ControllerBase
{
    private readonly IUserTypeService _service;

    public UserTypeController(IUserTypeService service)
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
        var usertype = await _service.GetCategoryByIdAsync(id);
        if (usertype == null)
            return NotFound();
        return Ok(usertype);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateUserTypeDTO dto)
    {
        var usertype = await _service.AddCategoryAsync(dto);
        return Ok(usertype);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(UpdateUserTypeDTO dto)
    {
        await _service.UpdateCategoryAsync(dto);
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteCategoryAsync(id);
        return NoContent();
    }
}

