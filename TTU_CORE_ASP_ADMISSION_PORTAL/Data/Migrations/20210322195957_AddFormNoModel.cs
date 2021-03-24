using Microsoft.EntityFrameworkCore.Migrations;

namespace TTU_CORE_ASP_ADMISSION_PORTAL.Data.Migrations
{
    public partial class AddFormNoModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormNoModel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Year = table.Column<string>(maxLength: 256, nullable: true),
                    No = table.Column<int>(maxLength: 256, nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormNoModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
