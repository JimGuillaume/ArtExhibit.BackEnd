namespace ArtExhibit.BackEnd.Application.DTOs;

public class AuthResponseDTO
{
    public string AccessToken { get; set; } = string.Empty;
    public DateTime AccessTokenExpiresAtUtc { get; set; }
    public UserDTO User { get; set; } = null!;
}
