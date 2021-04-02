using Microsoft.EntityFrameworkCore.Migrations;

namespace TTU_CORE_ASP_ADMISSION_PORTAL.Data.Migrations
{
    public partial class newApplicantm11121 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkPlace",
                table: "ApplicantModel");

            migrationBuilder.DropColumn(
                name: "WorkPlaceContact",
                table: "ApplicantModel");

            migrationBuilder.DropColumn(
                name: "YearsOfExperience",
                table: "ApplicantModel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WorkPlace",
                table: "ApplicantModel",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkPlaceContact",
                table: "ApplicantModel",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YearsOfExperience",
                table: "ApplicantModel",
                type: "text",
                nullable: true);
        }
    }
}
