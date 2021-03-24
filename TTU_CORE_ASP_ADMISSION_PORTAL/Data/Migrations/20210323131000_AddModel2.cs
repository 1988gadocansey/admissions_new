using Microsoft.EntityFrameworkCore.Migrations;

namespace TTU_CORE_ASP_ADMISSION_PORTAL.Data.Migrations
{
    public partial class AddModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantModelProgrammeModel_ProgrammeModel_programmesId",
                table: "ApplicantModelProgrammeModel");

            migrationBuilder.DropColumn(
                name: "Applicant",
                table: "WorkingExperienceModel");

            migrationBuilder.RenameColumn(
                name: "programmesId",
                table: "ApplicantModelProgrammeModel",
                newName: "ProgrammesId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicantModelProgrammeModel_programmesId",
                table: "ApplicantModelProgrammeModel",
                newName: "IX_ApplicantModelProgrammeModel_ProgrammesId");

            migrationBuilder.AddColumn<int>(
                name: "ApplicantModelID",
                table: "WorkingExperienceModel",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApplicantModelID",
                table: "SMSModel",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApplicantModelID",
                table: "RequirementModel",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApplicantModelID",
                table: "DocumentUploadModel",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApplicantModelID",
                table: "AcademicExperieceModel",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkingExperienceModel_ApplicantModelID",
                table: "WorkingExperienceModel",
                column: "ApplicantModelID");

            migrationBuilder.CreateIndex(
                name: "IX_SMSModel_ApplicantModelID",
                table: "SMSModel",
                column: "ApplicantModelID");

            migrationBuilder.CreateIndex(
                name: "IX_RequirementModel_ApplicantModelID",
                table: "RequirementModel",
                column: "ApplicantModelID");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentUploadModel_ApplicantModelID",
                table: "DocumentUploadModel",
                column: "ApplicantModelID");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicExperieceModel_ApplicantModelID",
                table: "AcademicExperieceModel",
                column: "ApplicantModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicExperieceModel_ApplicantModel_ApplicantModelID",
                table: "AcademicExperieceModel",
                column: "ApplicantModelID",
                principalTable: "ApplicantModel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantModelProgrammeModel_ProgrammeModel_ProgrammesId",
                table: "ApplicantModelProgrammeModel",
                column: "ProgrammesId",
                principalTable: "ProgrammeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentUploadModel_ApplicantModel_ApplicantModelID",
                table: "DocumentUploadModel",
                column: "ApplicantModelID",
                principalTable: "ApplicantModel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RequirementModel_ApplicantModel_ApplicantModelID",
                table: "RequirementModel",
                column: "ApplicantModelID",
                principalTable: "ApplicantModel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SMSModel_ApplicantModel_ApplicantModelID",
                table: "SMSModel",
                column: "ApplicantModelID",
                principalTable: "ApplicantModel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingExperienceModel_ApplicantModel_ApplicantModelID",
                table: "WorkingExperienceModel",
                column: "ApplicantModelID",
                principalTable: "ApplicantModel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicExperieceModel_ApplicantModel_ApplicantModelID",
                table: "AcademicExperieceModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantModelProgrammeModel_ProgrammeModel_ProgrammesId",
                table: "ApplicantModelProgrammeModel");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentUploadModel_ApplicantModel_ApplicantModelID",
                table: "DocumentUploadModel");

            migrationBuilder.DropForeignKey(
                name: "FK_RequirementModel_ApplicantModel_ApplicantModelID",
                table: "RequirementModel");

            migrationBuilder.DropForeignKey(
                name: "FK_SMSModel_ApplicantModel_ApplicantModelID",
                table: "SMSModel");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingExperienceModel_ApplicantModel_ApplicantModelID",
                table: "WorkingExperienceModel");

            migrationBuilder.DropIndex(
                name: "IX_WorkingExperienceModel_ApplicantModelID",
                table: "WorkingExperienceModel");

            migrationBuilder.DropIndex(
                name: "IX_SMSModel_ApplicantModelID",
                table: "SMSModel");

            migrationBuilder.DropIndex(
                name: "IX_RequirementModel_ApplicantModelID",
                table: "RequirementModel");

            migrationBuilder.DropIndex(
                name: "IX_DocumentUploadModel_ApplicantModelID",
                table: "DocumentUploadModel");

            migrationBuilder.DropIndex(
                name: "IX_AcademicExperieceModel_ApplicantModelID",
                table: "AcademicExperieceModel");

            migrationBuilder.DropColumn(
                name: "ApplicantModelID",
                table: "WorkingExperienceModel");

            migrationBuilder.DropColumn(
                name: "ApplicantModelID",
                table: "SMSModel");

            migrationBuilder.DropColumn(
                name: "ApplicantModelID",
                table: "RequirementModel");

            migrationBuilder.DropColumn(
                name: "ApplicantModelID",
                table: "DocumentUploadModel");

            migrationBuilder.DropColumn(
                name: "ApplicantModelID",
                table: "AcademicExperieceModel");

            migrationBuilder.RenameColumn(
                name: "ProgrammesId",
                table: "ApplicantModelProgrammeModel",
                newName: "programmesId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicantModelProgrammeModel_ProgrammesId",
                table: "ApplicantModelProgrammeModel",
                newName: "IX_ApplicantModelProgrammeModel_programmesId");

            migrationBuilder.AddColumn<int>(
                name: "Applicant",
                table: "WorkingExperienceModel",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantModelProgrammeModel_ProgrammeModel_programmesId",
                table: "ApplicantModelProgrammeModel",
                column: "programmesId",
                principalTable: "ProgrammeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
