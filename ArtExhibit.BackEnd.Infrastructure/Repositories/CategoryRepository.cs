using ArtExhibit.BackEnd.Application.Interfaces.Repositories;
using ArtExhibit.BackEnd.Domain.Entities;
using ArtExhibit.BackEnd.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ArtExhibit.BackEnd.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;

    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context; 
    }

   public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _context.Categories.AsNoTracking().ToListAsync();
    }

  public  async Task<Category?> GetByIdAsync(int id)
    {
        return await _context.Categories.AsNoTracking().FirstOrDefaultAsync(prd => prd.id == id);
    }

  public async Task<Category?> AddAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
        return category;
    }

 public async Task UpdateAsync(Category category)
    {
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category != null)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}