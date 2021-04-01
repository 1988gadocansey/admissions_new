using Microsoft.EntityFrameworkCore.Migrations;

namespace TTU_CORE_ASP_ADMISSION_PORTAL.Data.Migrations
{
    public partial class newApplicantm111 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GuardianAddress",
                table: "ApplicantModel");

            migrationBuilder.DropColumn(
                name: "GuardianEmail",
                table: "ApplicantModel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GuardianAddress",
                table: "ApplicantModel",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GuardianEmail",
                table: "ApplicantModel",
                type: "text",
                nullable: true);
        }
    }
}
