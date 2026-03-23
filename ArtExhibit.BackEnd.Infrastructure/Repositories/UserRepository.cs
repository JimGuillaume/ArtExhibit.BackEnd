using ArtExhibit.BackEnd.Application.Interfaces.Repositories;
using ArtExhibit.BackEnd.Domain.Entities;
using ArtExhibit.BackEnd.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ArtExhibit.BackEnd.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _context.Users
            .Include(u => u.UserType)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _context.Users
            .Include(u => u.UserType)
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users
            .Include(u => u.UserType)
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.UserEmail.ToLower() == email.ToLower());
    }

    public async Task<User?> GetByRefreshTokenHashAsync(string refreshTokenHash)
    {
        return await _context.Users
            .Include(u => u.UserType)
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.RefreshTokenHash == refreshTokenHash);
    }

    public async Task<User?> AddAsync(User entity)
    {
        await _context.Users.AddAsync(entity);
        await _context.SaveChangesAsync();

        _context.Entry(entity).State = EntityState.Detached;

        return entity;
    }

    public async Task UpdateAsync(User entity)
    {
        var trackedEntity = await _context.Users.FirstOrDefaultAsync(u => u.Id == entity.Id);

        if (trackedEntity is null)
        {
            _context.Users.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
        else
        {
            _context.Entry(trackedEntity).CurrentValues.SetValues(entity);
        }

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user != null)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}