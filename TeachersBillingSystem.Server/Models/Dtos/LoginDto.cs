using System.ComponentModel.DataAnnotations;

namespace TeachersBillingSystem.Server.Models.Dtos;

public class LoginDto
{
    [Required]
    public required string Email { get; set; }

    [Required] 
    public required string Password { get; set; }
}
