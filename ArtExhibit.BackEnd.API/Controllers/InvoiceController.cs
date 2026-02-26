using ArtExhibit.BackEnd.Application.DTOs;
using ArtExhibit.BackEnd.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArtExhibit.BackEnd.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InvoiceController : ControllerBase
{
    private readonly IInvoiceService _service;

    public InvoiceController(IInvoiceService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        return Ok(await _service.GetAllInvoiceAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAsync(int id)
    {
        var invoice = await _service.GetInvoiceByIdAsync(id);
        if (invoice == null)
            return NotFound();
        return Ok(invoice);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateInvoiceDTO invoiceDTO)
    {
        var item = await _service.AddInvoiceAsync(invoiceDTO);
        return Ok(item);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(UpdateInvoiceDTO invoiceDTO)
    {
        await _service.UpdateInvoiceAsync(invoiceDTO);
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteInvoiceAsync(id);
        return NoContent();
    }
}