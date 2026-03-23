using ArtExhibit.BackEnd.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace ArtExhibit.BackEnd.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext
{
    private static readonly string SeedPasswordHash = Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes("Password123!")));

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Bid>()
            .HasOne(b => b.Sale)
            .WithMany(s => s.Bids)
            .HasForeignKey(b => b.SaleId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Bid>()
            .HasOne(b => b.Buyer)
            .WithMany()
            .HasForeignKey(b => b.BuyerId)
            .OnDelete(DeleteBehavior.Restrict);

        //Seed Initial Category
        builder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Peinture" },
            new Category { Id = 2, Name = "Sculpture" },
            new Category { Id = 3, Name = "Photographie" },
            new Category { Id = 4, Name = "Dessin" }
            );

        //Seed Initial User Types
        builder.Entity<UserType>().HasData(
            new UserType { Id = 1, Name = "User" },
            new UserType { Id = 2, Name = "Administrator" }
            );

        //Seed Sample Users
        //Tous les mdps sont : Password123!
        builder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                UserName = "marie_artist",
                FirstName = "Marie",
                LastName = "Dubois",
                UserEmail = "marie.dubois@example.com",
                UserPhone = "0612345678",
                PasswordHash = SeedPasswordHash,
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
                PasswordHash = SeedPasswordHash,
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
                PasswordHash = SeedPasswordHash,
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
                PasswordHash = SeedPasswordHash,
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
                UserId = 1,
                ImageLink = "https://picsum.photos/600"
            },
            new Item
            {
                Id = 2,
                Name = "Abstract Dreams",
                Description = "Modern abstract painting with vibrant colors",
                Price = 890.00f,
                Tags = ["abstract", "modern", "colorful"],
                CategoryId = 1,
                UserId = 1,
                ImageLink = "https://picsum.photos/500"
            },
            new Item
            {
                Id = 3,
                Name = "Bronze Warrior",
                Description = "Life-size bronze sculpture of an ancient warrior",
                Price = 5500.00f,
                Tags = ["bronze", "warrior", "ancient", "statue"],
                CategoryId = 2,
                UserId = 2,
                ImageLink = "https://picsum.photos/400"
            },
            new Item
            {
                Id = 4,
                Name = "Dancing Figure",
                Description = "Elegant marble sculpture depicting a ballet dancer",
                Price = 3200.00f,
                Tags = ["marble", "ballet", "dance", "elegant"],
                CategoryId = 2,
                UserId = 2,
                ImageLink = "https://picsum.photos/700"
            },
            new Item
            {
                Id = 5,
                Name = "Urban Streets",
                Description = "Black and white photography series of Parisian streets",
                Price = 450.00f,
                Tags = ["photography", "black-white", "urban", "paris"],
                CategoryId = 3,
                UserId = 3,
                ImageLink = "https://picsum.photos/800"
            },
            new Item
            {
                Id = 6,
                Name = "Nature's Beauty",
                Description = "Stunning landscape photography collection",
                Price = 680.00f,
                Tags = ["nature", "landscape", "photography", "color"],
                CategoryId = 3,
                UserId = 3,
                ImageLink = "https://picsum.photos/900"
            },
            new Item
            {
                Id = 7,
                Name = "Portrait Study",
                Description = "Detailed charcoal drawing of a human face",
                Price = 320.00f,
                Tags = ["portrait", "charcoal", "drawing", "realistic"],
                CategoryId = 4,
                UserId = 1,
                ImageLink = "https://picsum.photos/505"
            },
            new Item
            {
                Id = 8,
                Name = "Botanical Sketches",
                Description = "Collection of detailed plant and flower sketches",
                Price = 280.00f,
                Tags = ["botanical", "sketches", "nature", "pencil"],
                CategoryId = 4,
                UserId = 3,
                ImageLink = "https://picsum.photos/405"
            }
            );

        //Seed Sample Sales
        builder.Entity<Sale>().HasData(
            new Sale
            {
                Id = 1,
                StartDate = new DateTime(2024, 1, 15),
                EndDate = new DateTime(2024, 1, 20),
                StartingPrice = 890.00f,
                FinalPrice = 850.00f,
                Status = "Completed",
                ItemId = 2,
                SellerId = 1,
                BuyerId = 4
            },
            new Sale
            {
                Id = 2,
                StartDate = new DateTime(2024, 2, 1),
                EndDate = new DateTime(2024, 2, 10),
                StartingPrice = 450.00f,
                FinalPrice = 450.00f,
                Status = "Completed",
                ItemId = 5,
                SellerId = 3,
                BuyerId = 1
            },
            new Sale
            {
                Id = 3,
                StartDate = new DateTime(2026, 3, 5),
                EndDate = new DateTime(2026, 5, 15),
                StartingPrice = 280.00f,
                FinalPrice = 0.0f,
                Status = "Active",
                ItemId = 8,
                SellerId = 3,
                BuyerId = 2
            },
            new Sale
            {
                Id = 4,
                StartDate = new DateTime(2024, 2, 20),
                EndDate = new DateTime(2024, 2, 28),
                StartingPrice = 3200.00f,
                FinalPrice = 3100.00f,
                Status = "Completed",
                ItemId = 4,
                SellerId = 2,
                BuyerId = 4
            },
            new Sale
            {
                Id = 5,
                StartDate = new DateTime(2026, 6, 1),
                EndDate = new DateTime(2026, 8, 20),
                StartingPrice = 1250.50f,
                FinalPrice = 0.0f,
                Status = "Pending",
                ItemId = 1,
                SellerId = 1,
                BuyerId = 2
            }
            );

        //Seed Sample Bids
        builder.Entity<Bid>().HasData(
            new Bid
            {
                Id = 1,
                SaleId = 1,
                BuyerId = 2,
                Amount = 820.00f,
                PlacedAtUtc = new DateTime(2024, 1, 18, 10, 30, 0)
            },
            new Bid
            {
                Id = 2,
                SaleId = 1,
                BuyerId = 4,
                Amount = 850.00f,
                PlacedAtUtc = new DateTime(2024, 1, 19, 14, 45, 0)
            },
            new Bid
            {
                Id = 3,
                SaleId = 2,
                BuyerId = 1,
                Amount = 450.00f,
                PlacedAtUtc = new DateTime(2024, 2, 8, 16, 10, 0)
            },
            new Bid
            {
                Id = 4,
                SaleId = 3,
                BuyerId = 2,
                Amount = 300.00f,
                PlacedAtUtc = new DateTime(2026, 3, 20, 9, 0, 0)
            },
            new Bid
            {
                Id = 5,
                SaleId = 4,
                BuyerId = 3,
                Amount = 3050.00f,
                PlacedAtUtc = new DateTime(2024, 2, 26, 11, 20, 0)
            },
            new Bid
            {
                Id = 6,
                SaleId = 4,
                BuyerId = 4,
                Amount = 3100.00f,
                PlacedAtUtc = new DateTime(2024, 2, 27, 17, 35, 0)
            },
            new Bid
            {
                Id = 7,
                SaleId = 5,
                BuyerId = 2,
                Amount = 1260.00f,
                PlacedAtUtc = new DateTime(2026, 6, 10, 13, 15, 0)
            }
            );

        //Seed Sample Orders
        builder.Entity<Order>().HasData(
            new Order
            {
                Id = 1,
                UserId = 1,
                TotalPrice = 850.00f,
                Commission = 85.00f,
                OrderStatus = "Completed"
            },
            new Order
            {
                Id = 2,
                UserId = 4,
                TotalPrice = 3950.00f,
                Commission = 395.00f,
                OrderStatus = "Completed"
            },
            new Order
            {
                Id = 3,
                UserId = 2,
                TotalPrice = 450.00f,
                Commission = 45.00f,
                OrderStatus = "Processing"
            },
            new Order
            {
                Id = 4,
                UserId = 3,
                TotalPrice = 1250.50f,
                Commission = 125.05f,
                OrderStatus = "Pending"
            },
            new Order
            {
                Id = 5,
                UserId = 1,
                TotalPrice = 680.00f,
                Commission = 68.00f,
                OrderStatus = "Completed"
            }
            );

        //Seed Sample Invoices
        builder.Entity<Invoice>().HasData(
            new Invoice
            {
                Id = 1,
                Date = new DateOnly(2024, 1, 21),
                Amount = 850.00f,
                OrderId = 1
            },
            new Invoice
            {
                Id = 2,
                Date = new DateOnly(2024, 2, 29),
                Amount = 3950.00f,
                OrderId = 2
            },
            new Invoice
            {
                Id = 3,
                Date = new DateOnly(2024, 2, 11),
                Amount = 450.00f,
                OrderId = 3
            },
            new Invoice
            {
                Id = 4,
                Date = new DateOnly(2024, 3, 21),
                Amount = 680.00f,
                OrderId = 5
            }
            );

        //Seed Sample Reports
        builder.Entity<Report>().HasData(
            new Report
            {
                Id = 1,
                UserId = 4,
                ItemId = 2,
                Date = new DateOnly(2024, 1, 10),
                Description = "Item description contains misleading information about the artwork origin"
            },
            new Report
            {
                Id = 2,
                UserId = 2,
                ItemId = 5,
                Date = new DateOnly(2024, 1, 25),
                Description = "Suspected copyright violation - images appear to be stock photos"
            },
            new Report
            {
                Id = 3,
                UserId = 1,
                ItemId = 3,
                Date = new DateOnly(2024, 2, 5),
                Description = "Price seems unreasonably high compared to similar items"
            },
            new Report
            {
                Id = 4,
                UserId = 4,
                ItemId = 7,
                Date = new DateOnly(2024, 2, 18),
                Description = "Item quality does not match the description provided"
            },
            new Report
            {
                Id = 5,
                UserId = 3,
                ItemId = 1,
                Date = new DateOnly(2024, 3, 8),
                Description = "Inappropriate content or tags associated with the artwork"
            }
            );

        //Seed Sample Item Reviews
        builder.Entity<ItemReview>().HasData(
            new ItemReview
            {
                Id = 1,
                UserId = 4,
                ItemId = 1,
                Review = "Absolutely stunning artwork! The colors are vibrant and the detail is incredible."
            },
            new ItemReview
            {
                Id = 2,
                UserId = 2,
                ItemId = 1,
                Review = "Beautiful piece. Perfect for my living room."
            },
            new ItemReview
            {
                Id = 3,
                UserId = 1,
                ItemId = 3,
                Review = "Impressive sculpture with great attention to detail. Worth the price."
            },
            new ItemReview
            {
                Id = 4,
                UserId = 4,
                ItemId = 3,
                Review = "The craftsmanship is exceptional. A true masterpiece!"
            },
            new ItemReview
            {
                Id = 5,
                UserId = 1,
                ItemId = 5,
                Review = "The photographs capture the essence of Paris beautifully."
            },
            new ItemReview
            {
                Id = 6,
                UserId = 4,
                ItemId = 6,
                Review = "Nature's Beauty indeed! These photos are breathtaking."
            },
            new ItemReview
            {
                Id = 7,
                UserId = 2,
                ItemId = 6,
                Review = "High quality prints with amazing composition."
            },
            new ItemReview
            {
                Id = 8,
                UserId = 3,
                ItemId = 4,
                Review = "The marble work is exquisite. The dancer seems almost alive."
            },
            new ItemReview
            {
                Id = 9,
                UserId = 1,
                ItemId = 7,
                Review = "Remarkable charcoal work. The emotion in the portrait is captivating."
            },
            new ItemReview
            {
                Id = 10,
                UserId = 2,
                ItemId = 8,
                Review = "Lovely botanical sketches, very detailed and accurate."
            }
            );

        //Seed Sample Submissions
        builder.Entity<Submission>().HasData(
            new Submission
            {
                Id = 1,
                UserId = 1,
                ItemId = 1,
                Date = new DateOnly(2024, 1, 5),
                Status = "Approved",
                RejectionReason = ""
            },
            new Submission
            {
                Id = 2,
                UserId = 1,
                ItemId = 2,
                Date = new DateOnly(2024, 1, 8),
                Status = "Approved",
                RejectionReason = ""
            },
            new Submission
            {
                Id = 3,
                UserId = 2,
                ItemId = 3,
                Date = new DateOnly(2024, 1, 12),
                Status = "Approved",
                RejectionReason = ""
            },
            new Submission
            {
                Id = 4,
                UserId = 2,
                ItemId = 4,
                Date = new DateOnly(2024, 2, 15),
                Status = "Approved",
                RejectionReason = ""
            },
            new Submission
            {
                Id = 5,
                UserId = 3,
                ItemId = 5,
                Date = new DateOnly(2024, 1, 28),
                Status = "Approved",
                RejectionReason = ""
            },
            new Submission
            {
                Id = 6,
                UserId = 3,
                ItemId = 6,
                Date = new DateOnly(2024, 2, 20),
                Status = "Approved",
                RejectionReason = ""
            },
            new Submission
            {
                Id = 7,
                UserId = 1,
                ItemId = 7,
                Date = new DateOnly(2024, 3, 1),
                Status = "Pending",
                RejectionReason = ""
            },
            new Submission
            {
                Id = 8,
                UserId = 3,
                ItemId = 8,
                Date = new DateOnly(2024, 3, 3),
                Status = "Rejected",
                RejectionReason = "Image quality does not meet minimum requirements for exhibition"
            },
            new Submission
            {
                Id = 9,
                UserId = 2,
                ItemId = 3,
                Date = new DateOnly(2024, 3, 12),
                Status = "Pending",
                RejectionReason = ""
            },
            new Submission
            {
                Id = 10,
                UserId = 1,
                ItemId = 1,
                Date = new DateOnly(2024, 3, 18),
                Status = "Under Review",
                RejectionReason = ""
            }
            );

        //Seed Sample Payments
        builder.Entity<Payment>().HasData(
            new Payment
            {
                Id = 1,
                OrderId = 1,
                Amount = 850.00f,
                Status = "Completed",
                PaymentMethod = "Credit Card"
            },
            new Payment
            {
                Id = 2,
                OrderId = 2,
                Amount = 3950.00f,
                Status = "Completed",
                PaymentMethod = "Bank Transfer"
            },
            new Payment
            {
                Id = 3,
                OrderId = 3,
                Amount = 450.00f,
                Status = "Pending",
                PaymentMethod = "PayPal"
            },
            new Payment
            {
                Id = 4,
                OrderId = 4,
                Amount = 1250.50f,
                Status = "Pending",
                PaymentMethod = "Credit Card"
            },
            new Payment
            {
                Id = 5,
                OrderId = 5,
                Amount = 680.00f,
                Status = "Completed",
                PaymentMethod = "PayPal"
            },
            new Payment
            {
                Id = 6,
                OrderId = 1,
                Amount = 85.00f,
                Status = "Failed",
                PaymentMethod = "Credit Card"
            },
            new Payment
            {
                Id = 7,
                OrderId = 2,
                Amount = 395.00f,
                Status = "Completed",
                PaymentMethod = "Bank Transfer"
            }
            );

        //Seed Sample Shipments
        builder.Entity<Shipment>().HasData(
            new Shipment
            {
                Id = 1,
                OrderId = 1,
                Carrier = "La Poste",
                TrackingNumber = "LP1234567890FR",
                Status = "Delivered"
            },
            new Shipment
            {
                Id = 2,
                OrderId = 2,
                Carrier = "Chronopost",
                TrackingNumber = "CP9876543210FR",
                Status = "Delivered"
            },
            new Shipment
            {
                Id = 3,
                OrderId = 3,
                Carrier = "DHL Express",
                TrackingNumber = "DHL5678901234",
                Status = "In Transit"
            },
            new Shipment
            {
                Id = 4,
                OrderId = 5,
                Carrier = "UPS",
                TrackingNumber = "UPS3456789012",
                Status = "Delivered"
            },
            new Shipment
            {
                Id = 5,
                OrderId = 4,
                Carrier = "Colissimo",
                TrackingNumber = "CL7890123456FR",
                Status = "Pending"
            }
            );

    }

    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<UserType> UserTypes { get; set; } = null!;
    public new DbSet<User> Users { get; set; } = null!;
    public DbSet<Item> Items { get; set; } = null!;
    public DbSet<Sale> Sales { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<Invoice> Invoices { get; set; } = null!;
    public DbSet<Report> Reports { get; set; } = null!;
    public DbSet<ItemReview> ItemsReviews { get; set; } = null!;
    public DbSet<Submission> Submissions { get; set; } = null!;
    public DbSet<Payment> Payments { get; set; } = null!;
    public DbSet<Shipment> Shipments { get; set; } = null!;
    public DbSet<Bid> Bids { get; set; } = null!;

}