namespace ArtExhibit.BackEnd.Domain.Entities;

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public float Price { get; set; } = 0;
    public string[] Tags { get; set; } = Array.Empty<string>();


    //Category
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;

    //User
    public int UserId { get; set; }
    public User User { get; set; } = null!;
}