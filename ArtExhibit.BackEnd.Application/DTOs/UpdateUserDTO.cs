using System.ComponentModel.DataAnnotations;

namespace ArtExhibit.BackEnd.Application.DTOs;

public class UpdateUserDTO
{

    public int Id { get; set; }
    [Required(ErrorMessage = "Username is required")]
    public string UserName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string UserEmail { get; set; } = string.Empty;
    public string UserPhone { get; set; } = string.Empty;
}