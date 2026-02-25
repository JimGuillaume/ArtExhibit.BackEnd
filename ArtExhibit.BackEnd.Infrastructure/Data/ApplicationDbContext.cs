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

        //Seed Initial User Types
        builder.Entity<UserType>().HasData(
            new UserType { Id = 1, Name = "User" },
            new UserType { Id = 2, Name = "Administrator" }
            );

        //Seed Sample Users
        builder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                UserName = "marie_artist",
                FirstName = "Marie",
                LastName = "Dubois",
                UserEmail = "marie.dubois@example.com",
                UserPhone = "0612345678",
                UserTypeId = 1
            },
            new User
            {
                Id = 2,
                UserName = "pierre_sculptor",
                FirstName = "Pierre",
                LastName = "Martin",
                UserEmail = "pierre.martin@example.com",
                UserPhone = "0623456789",
                UserTypeId = 1
            },
            new User
            {
                Id = 3,
                UserName = "sophie_photo",
                FirstName = "Sophie",
                LastName = "Bernard",
                UserEmail = "sophie.bernard@example.com",
                UserPhone = "0634567890",
                UserTypeId = 1
            },
            new User
            {
                Id = 4,
                UserName = "admin_user",
                FirstName = "Jean",
                LastName = "Admin",
                UserEmail = "admin@example.com",
                UserPhone = "0645678901",
                UserTypeId = 2
            }
            );

        //Seed Sample Items
        builder.Entity<Item>().HasData(
            new Item
            {
                Id = 1,
                Name = "Sunset Over Paris",
                Description = "Beautiful oil painting capturing the golden hour over the Eiffel Tower",
                Price = 1250.50f,
                Tags = ["landscape", "paris", "sunset", "oil"],
                CategoryId = 1,
                UserId = 1
            },
            new Item
            {
                Id = 2,
                Name = "Abstract Dreams",
                Description = "Modern abstract painting with vibrant colors",
                Price = 890.00f,
                Tags = ["abstract", "modern", "colorful"],
                CategoryId = 1,
                UserId = 1
            },
            new Item
            {
                Id = 3,
                Name = "Bronze Warrior",
                Description = "Life-size bronze sculpture of an ancient warrior",
                Price = 5500.00f,
                Tags = ["bronze", "warrior", "ancient", "statue"],
                CategoryId = 2,
                UserId = 2
            },
            new Item
            {
                Id = 4,
                Name = "Dancing Figure",
                Description = "Elegant marble sculpture depicting a ballet dancer",
                Price = 3200.00f,
                Tags = ["marble", "ballet", "dance", "elegant"],
                CategoryId = 2,
                UserId = 2
            },
            new Item
            {
                Id = 5,
                Name = "Urban Streets",
                Description = "Black and white photography series of Parisian streets",
                Price = 450.00f,
                Tags = ["photography", "black-white", "urban", "paris"],
                CategoryId = 3,
                UserId = 3
            },
            new Item
            {
                Id = 6,
                Name = "Nature's Beauty",
                Description = "Stunning landscape photography collection",
                Price = 680.00f,
                Tags = ["nature", "landscape", "photography", "color"],
                CategoryId = 3,
                UserId = 3
            },
            new Item
            {
                Id = 7,
                Name = "Portrait Study",
                Description = "Detailed charcoal drawing of a human face",
                Price = 320.00f,
                Tags = ["portrait", "charcoal", "drawing", "realistic"],
                CategoryId = 4,
                UserId = 1
            },
            new Item
            {
                Id = 8,
                Name = "Botanical Sketches",
                Description = "Collection of detailed plant and flower sketches",
                Price = 280.00f,
                Tags = ["botanical", "sketches", "nature", "pencil"],
                CategoryId = 4,
                UserId = 3
            }
            );
    }

    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<UserType> UserTypes { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Item> Items { get; set; } = null!;
}