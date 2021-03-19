using Microsoft.EntityFrameworkCore.Migrations;

namespace TTU_CORE_ASP_ADMISSION_PORTAL.Data.Migrations
{
    public partial class ApplicantModel3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DistrictModel_ApplicantModel_ApplicantModelID",
                table: "DistrictModel");

            migrationBuilder.DropIndex(
                name: "IX_DistrictModel_ApplicantModelID",
                table: "DistrictModel");

            migrationBuilder.DropColumn(
                name: "ApplicantModelID",
                table: "DistrictModel");

            migrationBuilder.AddColumn<int>(
                name: "DistrictID",
                table: "ApplicantModel",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantModel_DistrictID",
                table: "ApplicantModel",
                column: "DistrictID");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantModel_DistrictModel_DistrictID",
                table: "ApplicantModel",
                column: "DistrictID",
                principalTable: "DistrictModel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantModel_DistrictModel_DistrictID",
                table: "ApplicantModel");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantModel_DistrictID",
                table: "ApplicantModel");

            migrationBuilder.DropColumn(
                name: "DistrictID",
                table: "ApplicantModel");

            migrationBuilder.AddColumn<int>(
                name: "ApplicantModelID",
                table: "DistrictModel",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DistrictModel_ApplicantModelID",
                table: "DistrictModel",
                column: "ApplicantModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_DistrictModel_ApplicantModel_ApplicantModelID",
                table: "DistrictModel",
                column: "ApplicantModelID",
                principalTable: "ApplicantModel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
