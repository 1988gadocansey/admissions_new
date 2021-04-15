using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TTU_CORE_ASP_ADMISSION_PORTAL.Data.Migrations
{
    public partial class issues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "ApplicantIssueModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApplicantModelID = table.Column<int>(type: "integer", nullable: false),
                    Results = table.Column<bool>(type: "boolean", nullable: false),
                    Picture = table.Column<bool>(type: "boolean", nullable: false),
                    Age = table.Column<bool>(type: "boolean", nullable: false),
                    FormCompletion = table.Column<bool>(type: "boolean", nullable: false),
                    Qualification = table.Column<bool>(type: "boolean", nullable: false),
                    IssuesOne = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantIssueModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicantIssueModel_ApplicantModel_ApplicantModelID",
                        column: x => x.ApplicantModelID,
                        principalTable: "ApplicantModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantIssueModel_ApplicantModelID",
                table: "ApplicantIssueModel",
                column: "ApplicantModelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicantIssueModel");

            migrationBuilder.CreateTable(
                name: "ApplicantIssueModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Age = table.Column<bool>(type: "boolean", nullable: false),
                    ApplicantModelID = table.Column<int>(type: "integer", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    FormCompletion = table.Column<bool>(type: "boolean", nullable: false),
                    IssueFour = table.Column<bool>(type: "boolean", nullable: false),
                    IssueOne = table.Column<bool>(type: "boolean", nullable: false),
                    IssueThree = table.Column<bool>(type: "boolean", nullable: false),
                    IssueTwo = table.Column<bool>(type: "boolean", nullable: false),
                    Picture = table.Column<bool>(type: "boolean", nullable: false),
                    Results = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IssueModel_ApplicantModel_ApplicantModelID",
                        column: x => x.ApplicantModelID,
                        principalTable: "ApplicantModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IssueModel_ApplicantModelID",
                table: "ApplicantIssueModel",
                column: "ApplicantModelID");
        }
    }
}
