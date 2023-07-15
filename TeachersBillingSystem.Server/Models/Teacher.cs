﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeachersBillingSystem.Server.Models;

public class Teacher
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private set; }

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
