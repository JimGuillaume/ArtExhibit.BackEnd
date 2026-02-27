using ArtExhibit.BackEnd.Application.DTOs;
using ArtExhibit.BackEnd.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArtExhibit.BackEnd.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShipmentController : ControllerBase
{
    private readonly IShipmentService _service;

    public ShipmentController(IShipmentService service)
    {
        _service = service; 
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        return Ok(await _service.GetAllShipmentAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAsync(int id)
    {
        var shipment = await _service.GetShipmentByIdAsync(id);
        if (shipment == null)
            return NotFound();
        return Ok(shipment);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateShipmentDTO shipmentDTO)
    {
        var shipment = await _service.AddShipmentAsync(shipmentDTO);
        return Ok(shipment);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(UpdateShipmentDTO shipmentDTO)
    {
        await _service.UpdateShipmentAsync(shipmentDTO);
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteShipmentAsync(id);
        return NoContent();
    }
}
