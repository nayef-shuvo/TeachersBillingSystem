using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TeachersBillingSystem.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddindAmountTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amounts",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Value = table.Column<uint>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amounts", x => x.Name);
                });

            migrationBuilder.InsertData(
                table: "Amounts",
                columns: new[] { "Name", "Value" },
                values: new object[,]
                {
                    { "assistantController", 1600u },
                    { "classTest", 300u },
                    { "dean", 6000u },
                    { "deptChairman", 5500u },
                    { "examCommitteeMember", 2500u },
                    { "examCommitteePresident", 4000u },
                    { "examController", 2700u },
                    { "examPaperEvalSemesterFour", 150u },
                    { "examPaperEvalSenester", 120u },
                    { "gradeSheetEval", 350u },
                    { "invigilator", 500u },
                    { "labAssistant", 100u },
                    { "labAttendant", 250u },
                    { "labAttendantLab", 90u },
                    { "labCommitteePresident", 2000u },
                    { "labHeadExamineer", 600u },
                    { "labQuestion", 600u },
                    { "labReport", 40u },
                    { "officer", 150u },
                    { "questionModeration", 2500u },
                    { "subExamController", 2200u },
                    { "supervisor", 5000u },
                    { "survey", 12000u },
                    { "tabulationFirst", 70u },
                    { "tabulationFourth", 90u },
                    { "tabulationSecond", 75u },
                    { "tabulationThird", 80u },
                    { "theory", 2000u },
                    { "theoryQuestCompose", 400u },
                    { "theoryQuestModeration", 200u },
                    { "theoryQuestPhotocopy", 25u },
                    { "thesisExaminee", 1500u },
                    { "thesisViva", 150u },
                    { "viva", 60u },
                    { "vivaOfficeAssistant", 350u },
                    { "vivaOfficer", 400u }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amounts");
        }
    }
}
