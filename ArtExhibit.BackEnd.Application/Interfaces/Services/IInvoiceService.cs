using ArtExhibit.BackEnd.Application.DTOs;

namespace ArtExhibit.BackEnd.Application.Interfaces.Services;

public interface IInvoiceService
{
    Task<IEnumerable<InvoiceDTO>> GetAllInvoiceAsync();
    Task<InvoiceDTO?> GetInvoiceByIdAsync(int id);
    Task<InvoiceDTO?> AddInvoiceAsync(CreateInvoiceDTO invoiceDTO);
    Task UpdateInvoiceAsync(UpdateInvoiceDTO invoiceDTO);
    Task DeleteInvoiceAsync(int id);
}