using System.ComponentModel.DataAnnotations;

namespace ArtExhibit.BackEnd.Application.DTOs;

public class RegisterDTO
{
    [Required(ErrorMessage = "Username is required")]
    [MaxLength(25, ErrorMessage = "Username cannot exceed 25 characters")]
    [MinLength(2, ErrorMessage = "Username must be at least 2 characters long")]
    public string UserName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;

}