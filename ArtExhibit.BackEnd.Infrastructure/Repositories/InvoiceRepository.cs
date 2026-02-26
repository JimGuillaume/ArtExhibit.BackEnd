using ArtExhibit.BackEnd.Application.Interfaces.Repositories;
using ArtExhibit.BackEnd.Domain.Entities;
using ArtExhibit.BackEnd.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ArtExhibit.BackEnd.Infrastructure.Repositories;

public class InvoiceRepository : IInvoiceRepository
{
    private readonly ApplicationDbContext _context;
    public InvoiceRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Invoice>> GetAllAsync()
    {
        return await _context.Invoices
            .Include(i => i.Order)
            .AsNoTracking()
            .ToListAsync();
    }
    public async Task<Invoice?> GetByIdAsync(int id)
    {
        return await _context.Invoices
            .Include(i => i.Order)
            .AsNoTracking()
            .FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<Invoice?> AddAsync(Invoice invoice)
    {
        await _context.Invoices.AddAsync(invoice);
        await _context.SaveChangesAsync();
        return invoice;
    }

    public async Task UpdateAsync(Invoice invoice)
    {
        _context.Invoices.Update(invoice);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var invoice = await _context.Items.FindAsync(id);
        if (invoice != null)
        {
            _context.Items.Remove(invoice);
            await _context.SaveChangesAsync();
        }
    }
}