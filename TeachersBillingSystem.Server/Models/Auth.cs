using System.ComponentModel.DataAnnotations;

namespace TeachersBillingSystem.Server.Models;

public class Auth
{
    [Key]
    public int Id { get; init; }

    [Required]
    public required byte[] PasswordHash { get; set; }

    [Required]
    public required byte[] PasswordSalt { get; set; }
}
