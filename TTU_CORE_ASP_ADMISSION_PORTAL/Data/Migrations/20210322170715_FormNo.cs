using Microsoft.EntityFrameworkCore.Migrations;

namespace TTU_CORE_ASP_ADMISSION_PORTAL.Data.Migrations
{
    public partial class FormNo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantModelProgrammeModel_ProgrammeModel_programmesID",
                table: "ApplicantModelProgrammeModel");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "ProgrammeModel",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "programmesID",
                table: "ApplicantModelProgrammeModel",
                newName: "programmesId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicantModelProgrammeModel_programmesID",
                table: "ApplicantModelProgrammeModel",
                newName: "IX_ApplicantModelProgrammeModel_programmesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantModelProgrammeModel_ProgrammeModel_programmesId",
                table: "ApplicantModelProgrammeModel",
                column: "programmesId",
                principalTable: "ProgrammeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantModelProgrammeModel_ProgrammeModel_programmesId",
                table: "ApplicantModelProgrammeModel");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ProgrammeModel",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "programmesId",
                table: "ApplicantModelProgrammeModel",
                newName: "programmesID");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicantModelProgrammeModel_programmesId",
                table: "ApplicantModelProgrammeModel",
                newName: "IX_ApplicantModelProgrammeModel_programmesID");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantModelProgrammeModel_ProgrammeModel_programmesID",
                table: "ApplicantModelProgrammeModel",
                column: "programmesID",
                principalTable: "ProgrammeModel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
