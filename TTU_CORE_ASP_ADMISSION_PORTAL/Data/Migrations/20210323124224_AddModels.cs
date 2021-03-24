using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TTU_CORE_ASP_ADMISSION_PORTAL.Data.Migrations
{
    public partial class AddModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Applicant",
                table: "AcademicExperieceModel");

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

            migrationBuilder.CreateTable(
                name: "DenominationModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DenominationModel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Faculty = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentUploadModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Applicant = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentUploadModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExamModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CutOffPoint = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FacultyModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultyModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GradeModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    Exam = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HallModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BankAcc = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HallModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequirementModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Department = table.Column<int>(type: "integer", nullable: false),
                    Year = table.Column<string>(type: "text", nullable: true),
                    Aprroved = table.Column<bool>(type: "boolean", nullable: false),
                    RuleOne = table.Column<string>(type: "text", nullable: true),
                    RuleTwo = table.Column<string>(type: "text", nullable: true),
                    RuleThree = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequirementModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SMSModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Message = table.Column<string>(type: "text", nullable: true),
                    SentBy = table.Column<int>(type: "integer", nullable: false),
                    Recipient = table.Column<int>(type: "integer", nullable: false),
                    DateSent = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMSModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubjectModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkingExperienceModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Applicant = table.Column<int>(type: "integer", nullable: false),
                    CompanyName = table.Column<string>(type: "text", nullable: true),
                    CompanyPhone = table.Column<string>(type: "text", nullable: true),
                    CompanyAddress = table.Column<string>(type: "text", nullable: true),
                    CompanyPosition = table.Column<string>(type: "text", nullable: true),
                    CompanyFrom = table.Column<string>(type: "text", nullable: true),
                    CompanyTo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingExperienceModel", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "DenominationModel");

            migrationBuilder.DropTable(
                name: "DepartmentModel");

            migrationBuilder.DropTable(
                name: "DocumentUploadModel");

            migrationBuilder.DropTable(
                name: "ExamModel");

            migrationBuilder.DropTable(
                name: "FacultyModel");

            migrationBuilder.DropTable(
                name: "GradeModel");

            migrationBuilder.DropTable(
                name: "HallModel");

            migrationBuilder.DropTable(
                name: "RequirementModel");

            migrationBuilder.DropTable(
                name: "SMSModel");

            migrationBuilder.DropTable(
                name: "SubjectModel");

            migrationBuilder.DropTable(
                name: "WorkingExperienceModel");

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

            migrationBuilder.AddColumn<int>(
                name: "Applicant",
                table: "AcademicExperieceModel",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
