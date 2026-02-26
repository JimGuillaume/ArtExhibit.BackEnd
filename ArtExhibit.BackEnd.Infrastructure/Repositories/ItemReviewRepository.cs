using ArtExhibit.BackEnd.Application.Interfaces.Repositories;
using ArtExhibit.BackEnd.Domain.Entities;
using ArtExhibit.BackEnd.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ArtExhibit.BackEnd.Infrastructure;

public class ItemReviewRepository : IItemReviewRepository
{
    private readonly ApplicationDbContext _context;

    public ItemReviewRepository(ApplicationDbContext context)
    {
        _context = context;     
    }

    public async Task<IEnumerable<ItemReview>> GetAllAsync()
    {
        return await _context.ItemsReviews
            .AsNoTracking()
            .ToListAsync();
    }
    public async Task<ItemReview?> GetByIdAsync(int id)
    {
        return await _context.ItemsReviews
            .AsNoTracking()
            .FirstOrDefaultAsync(i => i.Id == id);
    }
    public async Task<ItemReview?> AddAsync(ItemReview itemreview)
    {
        await _context.ItemsReviews.AddAsync(itemreview);
        await _context.SaveChangesAsync();
        return itemreview;
    }
    public async Task UpdateAsync(ItemReview itemreview)
    {
        _context.ItemsReviews.Update(itemreview);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        var itemreview = await _context.ItemsReviews.FindAsync(id);
        if (itemreview != null)
        {
            _context.ItemsReviews.Remove(itemreview);
            await _context.SaveChangesAsync();
        }

    }
}
