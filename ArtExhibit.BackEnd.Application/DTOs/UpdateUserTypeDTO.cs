using System.ComponentModel.DataAnnotations;

namespace ArtExhibit.BackEnd.Application.DTOs;

public class UpdateUserTypeDTO
{
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "User type name is required")]
    [MaxLength(50, ErrorMessage = "User type name cannot exceed 50 characters")]
    public string Name { get; set; } = null!;
}