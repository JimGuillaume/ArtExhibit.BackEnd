using ArtExhibit.BackEnd.Application.DTOs;
using ArtExhibit.BackEnd.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArtExhibit.BackEnd.API.Controllers;



[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _service;

    public UserController(IUserService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        return Ok(await _service.GetAllUserAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAsync(int id)
    {
        var user = await _service.GetUserByIdAsync(id);
        if (user == null)
            return NotFound();
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Post(RegisterDTO userDTO)
    {
        var user = await _service.AddUserAsync(userDTO);
        return Ok(user);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(UpdateUserDTO userDTO)
    {
        await _service.UpdateUserAsync(userDTO);
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteUserAsync(id);
        return NoContent();
    }
}