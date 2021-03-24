using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TTU_CORE_ASP_ADMISSION_PORTAL.Data.Migrations
{
    public partial class AddModelNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantModel_AcademicExperieceModel_AcademicExperieceMode~",
                table: "ApplicantModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantModel_RequirementModel_RequirementModelId",
                table: "ApplicantModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantModel_SMSModel_SMSModelId",
                table: "ApplicantModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantModel_WorkingExperienceModel_WorkingExperienceMode~",
                table: "ApplicantModel");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantModel_AcademicExperieceModelId",
                table: "ApplicantModel");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantModel_RequirementModelId",
                table: "ApplicantModel");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantModel_SMSModelId",
                table: "ApplicantModel");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantModel_WorkingExperienceModelId",
                table: "ApplicantModel");

            migrationBuilder.DropColumn(
                name: "AcademicExperieceModelId",
                table: "ApplicantModel");

            migrationBuilder.DropColumn(
                name: "RequirementModelId",
                table: "ApplicantModel");

            migrationBuilder.DropColumn(
                name: "SMSModelId",
                table: "ApplicantModel");

            migrationBuilder.DropColumn(
                name: "WorkingExperienceModelId",
                table: "ApplicantModel");

            migrationBuilder.CreateTable(
                name: "ResultUploadModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Applicant = table.Column<int>(type: "integer", nullable: false),
                    Subject = table.Column<int>(type: "integer", nullable: false),
                    ExamType = table.Column<int>(type: "integer", nullable: false),
                    Grade = table.Column<int>(type: "integer", nullable: false),
                    GradeOld = table.Column<int>(type: "integer", nullable: false),
                    GradeValueOld = table.Column<string>(type: "text", nullable: true),
                    IndexNo = table.Column<string>(type: "text", nullable: true),
                    Sitting = table.Column<string>(type: "text", nullable: true),
                    Month = table.Column<string>(type: "text", nullable: true),
                    Form = table.Column<string>(type: "text", nullable: true),
                    Center = table.Column<string>(type: "text", nullable: true),
                    Year = table.Column<string>(type: "text", nullable: true),
                    OldSubject = table.Column<string>(type: "text", nullable: true),
                    InstitutionName = table.Column<string>(type: "text", nullable: true),
                    ApplicantModelID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultUploadModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResultUploadModel_ApplicantModel_ApplicantModelID",
                        column: x => x.ApplicantModelID,
                        principalTable: "ApplicantModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResultUploadModel_ApplicantModelID",
                table: "ResultUploadModel",
                column: "ApplicantModelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResultUploadModel");

            migrationBuilder.AddColumn<int>(
                name: "AcademicExperieceModelId",
                table: "ApplicantModel",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequirementModelId",
                table: "ApplicantModel",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SMSModelId",
                table: "ApplicantModel",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkingExperienceModelId",
                table: "ApplicantModel",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantModel_AcademicExperieceModelId",
                table: "ApplicantModel",
                column: "AcademicExperieceModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantModel_RequirementModelId",
                table: "ApplicantModel",
                column: "RequirementModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantModel_SMSModelId",
                table: "ApplicantModel",
                column: "SMSModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantModel_WorkingExperienceModelId",
                table: "ApplicantModel",
                column: "WorkingExperienceModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantModel_AcademicExperieceModel_AcademicExperieceMode~",
                table: "ApplicantModel",
                column: "AcademicExperieceModelId",
                principalTable: "AcademicExperieceModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantModel_RequirementModel_RequirementModelId",
                table: "ApplicantModel",
                column: "RequirementModelId",
                principalTable: "RequirementModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantModel_SMSModel_SMSModelId",
                table: "ApplicantModel",
                column: "SMSModelId",
                principalTable: "SMSModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantModel_WorkingExperienceModel_WorkingExperienceMode~",
                table: "ApplicantModel",
                column: "WorkingExperienceModelId",
                principalTable: "WorkingExperienceModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
