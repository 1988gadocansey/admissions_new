using Microsoft.EntityFrameworkCore.Migrations;

namespace TTU_CORE_ASP_ADMISSION_PORTAL.Migrations
{
    public partial class conf1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProgrammeAdmittedId",
                table: "ApplicantModel",
                type: "integer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProgrammeAdmittedId",
                table: "ApplicantModel");
        }
    }
}
