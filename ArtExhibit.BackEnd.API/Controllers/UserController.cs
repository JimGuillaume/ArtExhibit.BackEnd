using ArtExhibit.BackEnd.Application.DTOs;
using ArtExhibit.BackEnd.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ArtExhibit.BackEnd.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserController : ControllerBase
{
    private const string RefreshTokenCookieName = "refresh_token";

    private readonly IUserService _service;
    private readonly IConfiguration _configuration;

    public UserController(IUserService service, IConfiguration configuration)
    {
        _service = service;
        _configuration = configuration;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        return Ok(await _service.GetAllUserAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAsync(int id)
    {
        var user = await _service.GetUserByIdAsync(id);
        if (user == null)
            return NotFound();
        return Ok(user);
    }

    [AllowAnonymous]
    [HttpPost]
    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(RegisterDTO userDTO)
    {
        var user = await _service.AddUserAsync(userDTO);
        if (user == null)
            return BadRequest("User already exists or payload is invalid.");

        var response = await BuildAuthResponseAsync(user);
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(LoginDTO loginDTO)
    {
        var user = await _service.GetByCredentialsAsync(loginDTO);
        if (user == null)
            return Unauthorized();

        var response = await BuildAuthResponseAsync(user);
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshAsync()
    {
        if (!Request.Cookies.TryGetValue(RefreshTokenCookieName, out var refreshToken) || string.IsNullOrWhiteSpace(refreshToken))
            return Unauthorized();

        var user = await _service.GetByRefreshTokenAsync(refreshToken);
        if (user == null)
            return Unauthorized();

        var response = await BuildAuthResponseAsync(user);
        return Ok(response);
    }

    [HttpPost("revoke")]
    public async Task<IActionResult> RevokeAsync()
    {
        var userIdValue = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!int.TryParse(userIdValue, out var userId))
            return Unauthorized();

        await _service.RevokeRefreshTokenAsync(userId);
        Response.Cookies.Delete(RefreshTokenCookieName);

        return NoContent();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(UpdateUserDTO userDTO)
    {
        await _service.UpdateUserAsync(userDTO);
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteUserAsync(id);
        return NoContent();
    }

    private async Task<AuthResponseDTO> BuildAuthResponseAsync(UserDTO user)
    {
        var accessTokenMinutes = _configuration.GetValue<int>("Jwt:AccessTokenMinutes");
        var refreshTokenDays = _configuration.GetValue<int>("Jwt:RefreshTokenDays");

        var accessTokenExpiresAtUtc = DateTime.UtcNow.AddMinutes(accessTokenMinutes);
        var refreshTokenExpiresAtUtc = DateTime.UtcNow.AddDays(refreshTokenDays);

        var accessToken = GenerateAccessToken(user, accessTokenExpiresAtUtc);
        var refreshToken = Convert.ToHexString(RandomNumberGenerator.GetBytes(64));

        await _service.StoreRefreshTokenAsync(user.Id, refreshToken, refreshTokenExpiresAtUtc);

        Response.Cookies.Append(RefreshTokenCookieName, refreshToken, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.None,
            Expires = refreshTokenExpiresAtUtc
        });

        return new AuthResponseDTO
        {
            AccessToken = accessToken,
            AccessTokenExpiresAtUtc = accessTokenExpiresAtUtc,
            User = user
        };
    }

    private string GenerateAccessToken(UserDTO user, DateTime expiresAtUtc)
    {
        var jwtKey = _configuration["Jwt:Key"]!;
        var issuer = _configuration["Jwt:Issuer"];
        var audience = _configuration["Jwt:Audience"];

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.UserName),
            new(ClaimTypes.Email, user.UserEmail),
            new(ClaimTypes.Role, user.UserType.Name),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: expiresAtUtc,
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}