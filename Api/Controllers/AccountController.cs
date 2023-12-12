using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Data.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;

    public AccountController(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromForm] LoginDto model)
    {
        var user = await _userManager.FindByNameAsync(model.UserName);
        if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, user.UserName),
                new(ClaimTypes.NameIdentifier, user.Id)
            };

            // Get the user's roles
            var roles = await _userManager.GetRolesAsync(user);

            // Add each role as a claim
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("candela"); // Replace with your secret key
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new { Token = tokenHandler.WriteToken(token) });
        }

        return Unauthorized();
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return CreatedAtAction("Logout", new { }, null);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromForm] LoginDto model)
    {
        //TODO: Check if user already exists
        var user = new IdentityUser { UserName = model.UserName };
        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded) return BadRequest(result.Errors);
        await _userManager.AddToRoleAsync(user, "User");
        return CreatedAtAction("Register", new { model.UserName, model.Password }, model);
    }

    [HttpGet("modify")]
    public bool CanModify()
    {
        return User.IsInRole("Admin") || User.IsInRole("Moderator");
    }

    [HttpGet]
    public async Task<IActionResult> IsLogged()
    {
        // Extract the user's ID from the token's claims
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        // Look up the user in the database
        var user = await _userManager.FindByIdAsync(userId);

        // If a user with the given ID exists, the token is valid
        if (user != null)
        {
            return Ok("User is logged in");
        }
        return Unauthorized("User is not logged in");
    }
}