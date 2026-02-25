using System.ComponentModel.DataAnnotations;

namespace ArtExhibit.BackEnd.Application.DTOs;

public class CreateCategoryDTO
{
    [Required(ErrorMessage = "Category name is required")]
    [MaxLength(50, ErrorMessage = "Category name cannot exceed 50 characters")]
    [MinLength(2, ErrorMessage = "Category name must be at least 2 characters long")]
    public string Name { get; set; } = null!;
}