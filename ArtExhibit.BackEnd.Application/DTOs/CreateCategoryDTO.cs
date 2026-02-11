using System.ComponentModel.DataAnnotations;

namespace ArtExhibit.BackEnd.Application.DTOs;

public class CreateCategoryDTO
{
    [Required(ErrorMessage = "Category name is required")]
    [MaxLength(50, ErrorMessage = "Category name cannot exceed 50 characters")]
    public string Name { get; set; } = null!;
}