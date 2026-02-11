using ArtExhibit.BackEnd.Application.Interfaces.Repositories;
using ArtExhibit.BackEnd.Application.Interfaces.Services;
using ArtExhibit.BackEnd.Domain.Entities;
using ArtExhibit.BackEnd.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ArtExhibit.BackEnd.Infrastructure.Repositories;

public class UserTypeRepository : IUserTypeRepository
{
    private readonly ApplicationDbContext _context;

    public UserTypeRepository(ApplicationDbContext context)
    {
        _context = context; 
    }

    public async Task<IEnumerable<UserType>> GetAllAsync()
    {
        return await _context.UserTypes.AsNoTracking().ToListAsync();
    }

    public async Task<UserType?> GetByIdAsync(int id)
    {
        return await _context.UserTypes.AsNoTracking().FirstOrDefaultAsync(ut => ut.Id == id);
    }

    public async Task<UserType?> AddAsync(UserType usertype)
    {
        await _context.UserTypes.AddAsync(usertype);
        await _context.SaveChangesAsync();
        return usertype;
    }

    public async Task UpdateAsync(UserType usertype)
    {
        _context.UserTypes.Update(usertype);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var usertype = await _context.UserTypes.FindAsync(id);
        if(usertype != null)
        {
            _context.UserTypes.Remove(usertype);
            await _context.SaveChangesAsync();
        }

    }
}
