using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeachersBillingSystem.Server.Models;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [ForeignKey("Id")]
    public int Id { get; private set; }

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
}
