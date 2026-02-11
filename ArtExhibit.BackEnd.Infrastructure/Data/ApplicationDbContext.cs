using ArtExhibit.BackEnd.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ArtExhibit.BackEnd.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        //Seed Initial Category
        builder.Entity<Category>().HasData(
            new Category { id = 1, name = "Peinture" },
            new Category { id = 2, name = "Sculpture" },
            new Category { id = 3, name = "Photographie" },
            new Category { id = 4, name = "Dessin" }
            );
    }

    public DbSet<Category> Categories { get; set; } = null!;
}