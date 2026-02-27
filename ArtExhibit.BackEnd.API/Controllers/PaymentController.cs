using ArtExhibit.BackEnd.Application.DTOs;
using ArtExhibit.BackEnd.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArtExhibit.BackEnd.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService _service;

    public PaymentController(IPaymentService service)
    {
        _service = service; 
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        return Ok(await _service.GetAllPaymentAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAsync(int id)
    {
        var payment = await _service.GetPaymentByIdAsync(id);
        if (payment == null)
            return NotFound();
        return Ok(payment);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreatePaymentDTO paymentDTO)
    {
        var payment = await _service.AddPaymentAsync(paymentDTO);
        return Ok(payment);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(UpdatePaymentDTO paymentDTO)
    {
        await _service.UpdatePaymentAsync(paymentDTO);
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeletePaymentAsync(id);
        return NoContent();
    }
}
