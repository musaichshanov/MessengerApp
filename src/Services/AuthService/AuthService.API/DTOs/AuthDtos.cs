namespace AuthService.API.DTOs;

public record RegisterRequest(string PhoneNumber, string Password);
public record LoginRequest(string PhoneNumber, string Password);
public record AuthResponse(string Token, string RefreshToken);
public record RefreshTokenRequest(string RefreshToken);