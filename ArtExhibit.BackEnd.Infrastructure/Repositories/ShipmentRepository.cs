using ArtExhibit.BackEnd.Application.Interfaces.Repositories;
using ArtExhibit.BackEnd.Domain.Entities;
using ArtExhibit.BackEnd.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ArtExhibit.BackEnd.Infrastructure.Repositories;

public class ShipmentRepository : IShipmentRepository
{
    private readonly ApplicationDbContext _context;
    public ShipmentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Shipment>> GetAllAsync()
    {
        return await _context.Shipments
            .Include(s => s.Order)
            .AsNoTracking()
            .ToListAsync();
    }
    public async Task<Shipment?> GetByIdAsync(int id)
    {
        return await _context.Shipments
            .Include(s => s.Order)
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Shipment?> AddAsync(Shipment shipment)
    {
        await _context.Shipments.AddAsync(shipment);
        await _context.SaveChangesAsync();
        return shipment;
    }

    public async Task UpdateAsync(Shipment shipment)
    {
        _context.Shipments.Update(shipment);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var shipment = await _context.Shipments.FindAsync(id);
        if (shipment != null)
        {
            _context.Shipments.Remove(shipment);
            await _context.SaveChangesAsync();
        }
    }
}
