namespace AuthService.API.Models;

public class ApplicationUser
{
    public Guid Id {get;set;}
    public string Username { get; set;} = string.Empty;
    
    public string PhoneNumber { get; set;} = string.Empty;

    public byte[] PasswordHash { get; set;} = Array.Empty<byte>();

    public byte[] PasswordSalt { get; set;} = Array.Empty<byte>();

    public bool PhoneNumberConfirmed { get; set;} = false;

    public string? RefreshToken { get; set;}

    public DateTime? RefreshTokenExpiryTime { get; set;}

    public DateTime CreatedAt { get; set;} = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set;} = DateTime.UtcNow;
}