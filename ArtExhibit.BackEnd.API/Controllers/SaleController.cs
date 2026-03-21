using ArtExhibit.BackEnd.Application.DTOs;
using ArtExhibit.BackEnd.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArtExhibit.BackEnd.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SaleController : ControllerBase
{
    private readonly ISaleService _service;

    public SaleController(ISaleService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        return Ok(await _service.GetAllSaleAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAsync(int id)
    {
        var item = await _service.GetSaleByIdAsync(id);
        if (item == null)
            return NotFound();
        return Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateSaleDTO saleDTO)
    {
        var item = await _service.AddSaleAsync(saleDTO);
        return Ok(item);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(UpdateSaleDTO saleDTO)
    {
        await _service.UpdateSaleAsync(saleDTO);
        return NoContent();
    }

    [HttpGet("{id:int}/bids")]
    public async Task<IActionResult> GetBids(int id)
    {
        try
        {
            var result = await _service.GetBidsBySaleIdAsync(id);
            return Ok(result);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost("{id:int}/bid")]
    public async Task<IActionResult> PlaceBid(int id, PlaceBidDTO bidDTO)
    {
        try
        {
            var result = await _service.PlaceBidAsync(id, bidDTO);
            return Ok(result);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteSaleAsync(id);
        return NoContent();
    }
}