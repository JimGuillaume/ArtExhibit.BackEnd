namespace ArtExhibit.BackEnd.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string UserEmail { get; set; } = string.Empty;
    public string UserPhone { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public string? RefreshTokenHash { get; set; }
    public DateTime? RefreshTokenExpiresAtUtc { get; set; }
    public DateTime? RefreshTokenRevokedAtUtc { get; set; }

    //Foreign Key
    public int UserTypeId { get; set; }
    public UserType UserType { get; set; } = null!;

}