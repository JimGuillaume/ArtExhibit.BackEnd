using ArtExhibit.BackEnd.Application.DTOs;
using ArtExhibit.BackEnd.Application.Interfaces.Repositories;
using ArtExhibit.BackEnd.Application.Interfaces.Services;
using ArtExhibit.BackEnd.Domain.Entities;
using System.Reflection.Metadata.Ecma335;

namespace ArtExhibit.BackEnd.Application.Services;

public class InvoiceService : IInvoiceService
{
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly IOrderRepository _orderRepository;

    public InvoiceService(IInvoiceRepository invoiceRepository, IOrderRepository orderRepository)
    {
        _invoiceRepository = invoiceRepository;
        _orderRepository = orderRepository;
    }

    private InvoiceDTO MapToDTO(Invoice invoice)
    {
        return new InvoiceDTO
        {
            Id = invoice.Id,
            Date = invoice.Date,
            Amount = invoice.Amount,
            OrderId = invoice.OrderId,
            OrderComission = invoice.Order.Commission,
            OrderPrice = invoice.Order.TotalPrice
        };
    }

    public async Task<IEnumerable<InvoiceDTO>> GetAllInvoiceAsync()
    {
        var invoices = await _invoiceRepository.GetAllAsync();
        var dtos = new List<InvoiceDTO>();
        foreach (var invoice in invoices)
        {
            dtos.Add(MapToDTO(invoice));
        }
        return dtos;
    }
    
    public async Task<InvoiceDTO?> GetInvoiceByIdAsync(int id)
    {
        var invoice = await _invoiceRepository.GetByIdAsync(id);
        if (invoice == null)
            return null;
        return MapToDTO(invoice);
    }
    
    public async Task<InvoiceDTO?> AddInvoiceAsync(CreateInvoiceDTO invoiceDTO)
    {
        var order = await _orderRepository.GetByIdAsync(invoiceDTO.OrderId);
        if (order == null)
            throw new Exception("Order not found");

        var invoice = new Invoice
        {
            Date = invoiceDTO.Date,
            Amount = order.TotalPrice + order.Commission,
            OrderId = invoiceDTO.OrderId,
            Order = order
        };

        var newInvoice = await _invoiceRepository.AddAsync(invoice);
        if (newInvoice != null)
            return MapToDTO(newInvoice);
        return null;
    }
    
    public async Task UpdateInvoiceAsync(UpdateInvoiceDTO invoiceDTO)
    {
        var invoice = await _invoiceRepository.GetByIdAsync(invoiceDTO.Id);
        if (invoice == null) throw new Exception("Invoice not found");

        var order = await _orderRepository.GetByIdAsync(invoiceDTO.OrderId);
        if (order == null)
            throw new Exception("Order not found");

        invoice.Date = invoiceDTO.Date;
        invoice.Amount = order.TotalPrice + order.Commission;
        invoice.OrderId = invoiceDTO.OrderId;
        
        await _invoiceRepository.UpdateAsync(invoice);
    }
    
    public async Task DeleteInvoiceAsync(int id)
    {
        await _invoiceRepository.DeleteAsync(id);
    }
}