using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using TeachersBillingSystem.Server.Models;
using TeachersBillingSystem.Server.Models.Dtos;

namespace TeachersBillingSystem.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;

    public AuthController(ILogger<AuthController> logger)
    {
        _logger = logger;
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginDto request)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogError(ModelState.ToString());
            return BadRequest(ModelState);
        }
        _logger.LogInformation("A user logged in");
        return Ok();
    }

    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<ActionResult<string>> Register(RegisterDto request)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogError(ModelState.ToString());
            return BadRequest(ModelState);
        }
        User newUser = new()
        {
            Name = request.Name, 
            Email = request.Email, 
            PhoneNumber = request.PhoneNumber, 
            Role = request.Role
        };

        var (hash, salt) = GenerateHashAndSalt(request.Password);
        Auth newUserAuth = new()
        {
            Id = newUser.Id,
            PasswordHash = hash,
            PasswordSalt = salt,
        };

        return Ok(newUser);
    }

    private (byte[], byte[]) GenerateHashAndSalt(string password)
    {
        using (var hmac = new HMACSHA512())
        {
            var salt = hmac.Key;
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            return (hash, salt);
        }
    }

    /*
    private async Task<bool> Verify(LoginDto loginDto)
    {
        var teacher = await _dbContext.TeacherDatabse.AsNoTracking().FirstOrDefaultAsync(x => x.Email == loginDto.Email);
        if (teacher == null)
        {
            return false;
        }

        var hashAndSalt = await _dbContext.AuthDatabse.AsNoTracking().FirstOrDefaultAsync(x => x.Id == teacher.Id);
        if (hashAndSalt == null)
        {
            return false;
        }

        using (var hmac = new HMACSHA512(hashAndSalt.PasswordSalt))
        {
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            if (computedHash.SequenceEqual(hashAndSalt.PasswordHash))
            {
                return true;
            }
        }

        return false;
    }
    */

}
