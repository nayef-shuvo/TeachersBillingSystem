using System.ComponentModel.DataAnnotations;

namespace TeachersBillingSystem.Server.Models.Dtos;

public class TeacherDto
{

    [Required]
    [StringLength(50)]
    public required string NameEnglish { get; set; }

    [Required]
    [StringLength(50)]
    public required string NameBengali { get; set; }

    [Required]
    [StringLength(50)]
    public required string Department { get; set; }

    [Required]
    [StringLength(50)]
    public required string Rank { get; set; }
}
