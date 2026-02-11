using System.ComponentModel.DataAnnotations;

namespace ArtExhibit.BackEnd.Application.DTOs;

public class UpdateCategoryDTO
{
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "Category name is required")]
    [MaxLength(50, ErrorMessage = "Category name cannot exceed 50 characters")]
    public string Name { get; set; } = null!;
}
