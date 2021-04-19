using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TTU_CORE_ASP_ADMISSION_PORTAL.Data.Migrations
{
    public partial class FormerSchool1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantModel_DistrictModel_DistrictId",
                table: "ApplicantModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantModel_RegionModel_RegionId",
                table: "ApplicantModel");

            

            migrationBuilder.DropIndex(
                name: "IX_ApplicantModel_SchoolId",
                table: "ApplicantModel");

            migrationBuilder.DropColumn(
                name: "SchoolId",
                table: "ApplicantModel");

            migrationBuilder.AlterColumn<int>(
                name: "RegionId",
                table: "ApplicantModel",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "DistrictId",
                table: "ApplicantModel",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "FormerSchoolNewId",
                table: "ApplicantModel",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FormerSchoolModel",
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
                    table.PrimaryKey("PK_FormerSchoolModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantModel_FormerSchoolNewId",
                table: "ApplicantModel",
                column: "FormerSchoolNewId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantModel_DistrictModel_DistrictId",
                table: "ApplicantModel",
                column: "DistrictId",
                principalTable: "DistrictModel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantModel_FormerSchoolModel_FormerSchoolNewId",
                table: "ApplicantModel",
                column: "FormerSchoolNewId",
                principalTable: "FormerSchoolModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantModel_RegionModel_RegionId",
                table: "ApplicantModel",
                column: "RegionId",
                principalTable: "RegionModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantModel_DistrictModel_DistrictId",
                table: "ApplicantModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantModel_FormerSchoolModel_FormerSchoolNewId",
                table: "ApplicantModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantModel_RegionModel_RegionId",
                table: "ApplicantModel");

            migrationBuilder.DropTable(
                name: "FormerSchoolModel");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantModel_FormerSchoolNewId",
                table: "ApplicantModel");

            migrationBuilder.DropColumn(
                name: "FormerSchoolNewId",
                table: "ApplicantModel");

            migrationBuilder.AlterColumn<int>(
                name: "RegionId",
                table: "ApplicantModel",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DistrictId",
                table: "ApplicantModel",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

           

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantModel_DistrictModel_DistrictId",
                table: "ApplicantModel",
                column: "DistrictId",
                principalTable: "DistrictModel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantModel_RegionModel_RegionId",
                table: "ApplicantModel",
                column: "RegionId",
                principalTable: "RegionModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            
        }
    }
}
