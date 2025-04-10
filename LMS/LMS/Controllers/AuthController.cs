using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text; // برای Session

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IConfiguration _configuration;

    public AuthController(AuthService authService, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
    {
        _authService = authService;
        _httpContextAccessor = httpContextAccessor;
        _configuration = configuration;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        // بررسی اینکه درخواست خالی نباشد
        if (request == null || string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
        {
            return BadRequest(new { message = "ایمیل و رمز عبور را وارد کنید." });
        }

        // بررسی اعتبار کاربر
        var user = _authService.Authenticate(request.Email, request.Password);

        if (user == null)
        {
            return Unauthorized(new { message = "ایمیل یا رمز عبور اشتباه است." });
        }
        Console.WriteLine($"User Role: {user.Role}");

        var issuer = _configuration["JwtConfig:Issuer"];
        var audience = _configuration["JwtConfig:Audience"];
        var key = _configuration["JwtConfig:Key"];
        var tokenvalidityMins = _configuration.GetValue<int>("JwtConfig:TokenValidatyMins");
        var tokenExpiryTimeStamp = DateTime.UtcNow.AddMinutes(tokenvalidityMins);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {

                new Claim(JwtRegisteredClaimNames.Name,request.Email),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim("UserId", user.Id.ToString())
            }),
            Expires=tokenExpiryTimeStamp,
            Issuer = issuer,
            Audience = audience,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
            SecurityAlgorithms.HmacSha512Signature),
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(tokenDescriptor);
        var accessToken = tokenHandler.WriteToken(securityToken);



        return Ok(new { message = "ورود موفقیت‌آمیز بود!", token = accessToken, role = user.Role });
    }


}

public class LoginRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}
