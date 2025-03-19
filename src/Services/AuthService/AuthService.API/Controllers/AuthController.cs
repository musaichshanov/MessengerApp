using AuthService.API.DTOs;
using AuthService.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly ILogger<AuthController> _logger;

    public AuthController(IAuthService authService, ILogger<AuthController> logger)
    {
        _authService = authService;
        _logger = logger;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        try
        {
            var (success, message) = await _authService.RegisterAsync(request);

            if (!success)
                return BadRequest(new { message });

            return Ok(new { message });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при регистрации пользователя");
            return StatusCode(500, new { message = "Внутренняя ошибка сервера" });
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        try
        {
            var response = await _authService.LoginAsync(request);

            if (response == null)
                return Unauthorized(new { message = "Неверное имя пользователя или пароль" });

            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при авторизации пользователя");
            return StatusCode(500, new { message = "Внутренняя ошибка сервера" });
        }
    }
}