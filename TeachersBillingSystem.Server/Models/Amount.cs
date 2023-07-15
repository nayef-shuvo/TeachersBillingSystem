using System.ComponentModel.DataAnnotations;

namespace TeachersBillingSystem.Server.Models;

public class Amount
{
    [Key]
    [Required]
    [MaxLength(50)]
    public required string Name { get; set; }

    [Required]
    public uint Value { get; set; }
}
