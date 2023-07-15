using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TeachersBillingSystem.Server.Models.Dtos;

public class RegisterDto
{
    [Required]
    [StringLength(50)]
    public required string Name { get; set; }

    [Required]
    [StringLength(50)]
    public required string Email { get; set; }

    [Required]
    [Phone]
    public required string PhoneNumber { get; set; }

    [Required]
    public required string Role { get; init; }

    [Required]
    [PasswordPropertyText]
    public required string Password { get; set; }
}
