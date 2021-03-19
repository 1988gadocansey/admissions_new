using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TTU_CORE_ASP_ADMISSION_PORTAL.Data.Migrations
{
    public partial class ApplicantModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgrammeModel");

            migrationBuilder.AddColumn<string>(
                name: "FirstChoice",
                table: "ApplicantModel",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondChoice",
                table: "ApplicantModel",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThirdChoice",
                table: "ApplicantModel",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstChoice",
                table: "ApplicantModel");

            migrationBuilder.DropColumn(
                name: "SecondChoice",
                table: "ApplicantModel");

            migrationBuilder.DropColumn(
                name: "ThirdChoice",
                table: "ApplicantModel");

            migrationBuilder.CreateTable(
                name: "ProgrammeModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApplicantModelID = table.Column<int>(type: "integer", nullable: true),
                    ApplicantModelID1 = table.Column<int>(type: "integer", nullable: true),
                    ApplicantModelID2 = table.Column<int>(type: "integer", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Department = table.Column<int>(type: "integer", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    LevelAdmitted = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Runing = table.Column<bool>(type: "boolean", nullable: false),
                    ShowOnPortal = table.Column<bool>(type: "boolean", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrammeModel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProgrammeModel_ApplicantModel_ApplicantModelID",
                        column: x => x.ApplicantModelID,
                        principalTable: "ApplicantModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProgrammeModel_ApplicantModel_ApplicantModelID1",
                        column: x => x.ApplicantModelID1,
                        principalTable: "ApplicantModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProgrammeModel_ApplicantModel_ApplicantModelID2",
                        column: x => x.ApplicantModelID2,
                        principalTable: "ApplicantModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammeModel_ApplicantModelID",
                table: "ProgrammeModel",
                column: "ApplicantModelID");

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammeModel_ApplicantModelID1",
                table: "ProgrammeModel",
                column: "ApplicantModelID1");

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammeModel_ApplicantModelID2",
                table: "ProgrammeModel",
                column: "ApplicantModelID2");
        }
    }
}
