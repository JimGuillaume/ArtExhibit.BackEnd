namespace ArtExhibit.BackEnd.Application.DTOs;

public class UserDTO
{
    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string UserEmail { get; set; } = string.Empty;
    public string UserPhone { get; set; } = string.Empty;
    //Foreign Key
    public int UserTypeId { get; set; }
    public UserTypeDTO UserType { get; set; } = null!;
}