using Microsoft.EntityFrameworkCore;
using TeachersBillingSystem.Server.Models;

namespace TeachersBillingSystem.Server.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Auth> Auths { get; set; }
    public DbSet<Amount> Amounts { get; set; }
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Amount>().HasData(
            new Amount { Name = "theory", Value = 2000 },
            new Amount { Name = "classTest", Value = 300 },
            new Amount { Name = "questionModeration", Value = 2500 },
            new Amount { Name = "examPaperEvalSenester", Value = 120 },
            new Amount { Name = "examPaperEvalSemesterFour", Value = 150 },
            new Amount { Name = "viva", Value = 60 },
            new Amount { Name = "vivaOfficer", Value = 400 },
            new Amount { Name = "vivaOfficeAssistant", Value = 350 },
            new Amount { Name = "labAttendant", Value = 250 },
            new Amount { Name = "labQuestion", Value = 600 },
            new Amount { Name = "labReport", Value = 40 },
            new Amount { Name = "survey", Value = 12000 },
            new Amount { Name = "tabulationFirst", Value = 70 },
            new Amount { Name = "tabulationSecond", Value = 75 },
            new Amount { Name = "tabulationThird", Value = 80 },
            new Amount { Name = "tabulationFourth", Value = 90 },
            new Amount { Name = "gradeSheetEval", Value = 350 },
            new Amount { Name = "theoryQuestCompose", Value = 400 },
            new Amount { Name = "theoryQuestModeration", Value = 200 },
            new Amount { Name = "theoryQuestPhotocopy", Value = 25 },
            new Amount { Name = "labHeadExamineer", Value = 600 },
            new Amount { Name = "invigilator", Value = 500 },
            new Amount { Name = "examController", Value = 2700 },
            new Amount { Name = "subExamController", Value = 2200 },
            new Amount { Name = "assistantController", Value = 1600 },
            new Amount { Name = "officer", Value = 150 },
            new Amount { Name = "labAssistant", Value = 100 },
            new Amount { Name = "labAttendantLab", Value = 90 },
            new Amount { Name = "labCommitteePresident", Value = 2000 },
            new Amount { Name = "supervisor", Value = 5000 },
            new Amount { Name = "thesisExaminee", Value = 1500 },
            new Amount { Name = "thesisViva", Value = 150 },
            new Amount { Name = "examCommitteeMember", Value = 2500 },
            new Amount { Name = "examCommitteePresident", Value = 4000 },
            new Amount { Name = "dean", Value = 6000 },
            new Amount { Name = "deptChairman", Value = 5500 }
        );
    }

}
