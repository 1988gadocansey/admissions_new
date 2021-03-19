using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TTU_CORE_ASP_ADMISSION_PORTAL.Data.Migrations
{
    public partial class ApplicantModel4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantModel_DistrictModel_DistrictID",
                table: "ApplicantModel");

            migrationBuilder.DropColumn(
                name: "FirstChoice",
                table: "ApplicantModel");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "ApplicantModel");

            migrationBuilder.DropColumn(
                name: "SecondChoice",
                table: "ApplicantModel");

            migrationBuilder.DropColumn(
                name: "ThirdChoice",
                table: "ApplicantModel");

            migrationBuilder.RenameColumn(
                name: "DistrictID",
                table: "ApplicantModel",
                newName: "DistrictId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicantModel_DistrictID",
                table: "ApplicantModel",
                newName: "IX_ApplicantModel_DistrictId");

            migrationBuilder.AlterColumn<int>(
                name: "DistrictId",
                table: "ApplicantModel",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FirstChoiceId",
                table: "ApplicantModel",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NationalityId",
                table: "ApplicantModel",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SecondChoiceId",
                table: "ApplicantModel",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ThirdChoiceId",
                table: "ApplicantModel",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CountryModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryModel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProgrammeModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    LevelAdmitted = table.Column<string>(type: "text", nullable: true),
                    Runing = table.Column<bool>(type: "boolean", nullable: false),
                    ShowOnPortal = table.Column<bool>(type: "boolean", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    Department = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrammeModel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantModelProgrammeModel",
                columns: table => new
                {
                    ApplicantID = table.Column<int>(type: "integer", nullable: false),
                    programmesID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantModelProgrammeModel", x => new { x.ApplicantID, x.programmesID });
                    table.ForeignKey(
                        name: "FK_ApplicantModelProgrammeModel_ApplicantModel_ApplicantID",
                        column: x => x.ApplicantID,
                        principalTable: "ApplicantModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicantModelProgrammeModel_ProgrammeModel_programmesID",
                        column: x => x.programmesID,
                        principalTable: "ProgrammeModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantModel_NationalityId",
                table: "ApplicantModel",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantModelProgrammeModel_programmesID",
                table: "ApplicantModelProgrammeModel",
                column: "programmesID");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantModel_CountryModel_NationalityId",
                table: "ApplicantModel",
                column: "NationalityId",
                principalTable: "CountryModel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantModel_DistrictModel_DistrictId",
                table: "ApplicantModel",
                column: "DistrictId",
                principalTable: "DistrictModel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantModel_CountryModel_NationalityId",
                table: "ApplicantModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantModel_DistrictModel_DistrictId",
                table: "ApplicantModel");

            migrationBuilder.DropTable(
                name: "ApplicantModelProgrammeModel");

            migrationBuilder.DropTable(
                name: "CountryModel");

            migrationBuilder.DropTable(
                name: "ProgrammeModel");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantModel_NationalityId",
                table: "ApplicantModel");

            migrationBuilder.DropColumn(
                name: "FirstChoiceId",
                table: "ApplicantModel");

            migrationBuilder.DropColumn(
                name: "NationalityId",
                table: "ApplicantModel");

            migrationBuilder.DropColumn(
                name: "SecondChoiceId",
                table: "ApplicantModel");

            migrationBuilder.DropColumn(
                name: "ThirdChoiceId",
                table: "ApplicantModel");

            migrationBuilder.RenameColumn(
                name: "DistrictId",
                table: "ApplicantModel",
                newName: "DistrictID");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicantModel_DistrictId",
                table: "ApplicantModel",
                newName: "IX_ApplicantModel_DistrictID");

            migrationBuilder.AlterColumn<int>(
                name: "DistrictID",
                table: "ApplicantModel",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "FirstChoice",
                table: "ApplicantModel",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
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

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantModel_DistrictModel_DistrictID",
                table: "ApplicantModel",
                column: "DistrictID",
                principalTable: "DistrictModel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
