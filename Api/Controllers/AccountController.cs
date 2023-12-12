using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Data.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Api.Controllers;
/// <summary>
/// Controller for user account management.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;

    /// <summary>
    /// Constructor for AccountController.
    /// </summary>
    /// <param name="userManager">The user manager.</param>
    public AccountController(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }
    /// <summary>
    /// Method for logging in.
    /// </summary>
    /// <param name="model">The login model.</param>
    /// <returns>A token if login is successful, otherwise Unauthorized.</returns>
    private static string GenerateJwtToken(IEnumerable<Claim> claims)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes("candelacandelacandela"); // Replace with your secret key
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
    /// <summary>
    /// Method to check if the current user is logged in.
    /// </summary>
    /// <returns>Ok if the user is logged in, Unauthorized otherwise.</returns>
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


            return Ok(new { Token = GenerateJwtToken(claims) });
        }

        return Unauthorized();
    }
    
    
    /// <summary>
    /// Method for registering a new user.
    /// </summary>
    /// <param name="model">The registration model.</param>
    /// <returns>A result indicating whether the registration was successful or not.</returns>
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromForm] LoginDto model)
    {
        //TODO: Check if user already exists
        var user = new IdentityUser { UserName = model.UserName };
        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded) return BadRequest(result.Errors);
        await _userManager.AddToRoleAsync(user, "User");
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.UserName),
            new(ClaimTypes.NameIdentifier, user.Id),
            new(ClaimTypes.Role, "User")
        };
        return CreatedAtAction("Register", new { Token = GenerateJwtToken(claims) });
    }
    /// <summary>
    /// Method for logging out.
    /// </summary>
    /// <returns>A result indicating that the session was successfully closed.</returns>
    [HttpGet("modify")]
    public bool CanModify()
    {
        return User.IsInRole("Admin") || User.IsInRole("Moderator");
    }
    
    /// <summary>
    /// Method to check if the current user can modify.
    /// </summary>
    /// <returns>True if the user can modify, false otherwise.</returns>
    [HttpGet]
    public bool IsLogged()
    {
        return User.Identity != null && User.Identity.IsAuthenticated;
    }
}