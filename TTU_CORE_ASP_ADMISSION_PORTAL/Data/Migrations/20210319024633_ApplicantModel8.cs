using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TTU_CORE_ASP_ADMISSION_PORTAL.Data.Migrations
{
    public partial class ApplicantModel8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Form",
                table: "ApplicantModel");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "ApplicantModel");

            migrationBuilder.RenameColumn(
                name: "Religion",
                table: "ApplicantModel",
                newName: "ApplicationUserId1");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "ApplicantModel",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "ApplicantModel",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReligionId",
                table: "ApplicantModel",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SchoolId",
                table: "ApplicantModel",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RegionModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReligionModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReligionModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SchoolModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    Region = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantModel_ApplicationUserId1",
                table: "ApplicantModel",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantModel_RegionId",
                table: "ApplicantModel",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantModel_ReligionId",
                table: "ApplicantModel",
                column: "ReligionId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantModel_SchoolId",
                table: "ApplicantModel",
                column: "SchoolId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantModel_AspNetUsers_ApplicationUserId1",
                table: "ApplicantModel",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantModel_RegionModel_RegionId",
                table: "ApplicantModel",
                column: "RegionId",
                principalTable: "RegionModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantModel_ReligionModel_ReligionId",
                table: "ApplicantModel",
                column: "ReligionId",
                principalTable: "ReligionModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantModel_SchoolModel_SchoolId",
                table: "ApplicantModel",
                column: "SchoolId",
                principalTable: "SchoolModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantModel_AspNetUsers_ApplicationUserId1",
                table: "ApplicantModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantModel_RegionModel_RegionId",
                table: "ApplicantModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantModel_ReligionModel_ReligionId",
                table: "ApplicantModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantModel_SchoolModel_SchoolId",
                table: "ApplicantModel");

            migrationBuilder.DropTable(
                name: "RegionModel");

            migrationBuilder.DropTable(
                name: "ReligionModel");

            migrationBuilder.DropTable(
                name: "SchoolModel");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantModel_ApplicationUserId1",
                table: "ApplicantModel");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantModel_RegionId",
                table: "ApplicantModel");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantModel_ReligionId",
                table: "ApplicantModel");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantModel_SchoolId",
                table: "ApplicantModel");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "ApplicantModel");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "ApplicantModel");

            migrationBuilder.DropColumn(
                name: "ReligionId",
                table: "ApplicantModel");

            migrationBuilder.DropColumn(
                name: "SchoolId",
                table: "ApplicantModel");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId1",
                table: "ApplicantModel",
                newName: "Religion");

            migrationBuilder.AddColumn<string>(
                name: "Form",
                table: "ApplicantModel",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "ApplicantModel",
                type: "text",
                nullable: true);
        }
    }
}
