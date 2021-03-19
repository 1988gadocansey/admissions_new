using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TTU_CORE_ASP_ADMISSION_PORTAL.Data.Migrations
{
    public partial class ApplicantModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicantModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApplicationNumber = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    PreviousName = table.Column<string>(type: "text", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<string>(type: "text", nullable: true),
                    MaritalStatus = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    AltPhone = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: true),
                    PostGPRS = table.Column<string>(type: "text", nullable: true),
                    EmergencyContact = table.Column<string>(type: "text", nullable: true),
                    Hometown = table.Column<string>(type: "text", nullable: true),
                    NationalIDType = table.Column<string>(type: "text", nullable: true),
                    NationalIDNo = table.Column<string>(type: "text", nullable: true),
                    Region = table.Column<string>(type: "text", nullable: true),
                    Nationality = table.Column<string>(type: "text", nullable: true),
                    ResidentialStatus = table.Column<bool>(type: "boolean", nullable: false),
                    GuardianName = table.Column<string>(type: "text", nullable: true),
                    GuardianAddress = table.Column<string>(type: "text", nullable: true),
                    GuardianEmail = table.Column<string>(type: "text", nullable: true),
                    GuardianPhone = table.Column<string>(type: "text", nullable: true),
                    GuardianOccupation = table.Column<string>(type: "text", nullable: true),
                    GuardianRelationship = table.Column<string>(type: "text", nullable: true),
                    Disability = table.Column<bool>(type: "boolean", nullable: false),
                    DisabilityType = table.Column<string>(type: "text", nullable: true),
                    SourceOfFinance = table.Column<string>(type: "text", nullable: true),
                    Religion = table.Column<string>(type: "text", nullable: true),
                    Denomination = table.Column<string>(type: "text", nullable: true),
                    Referrals = table.Column<string>(type: "text", nullable: true),
                    EntryMode = table.Column<string>(type: "text", nullable: true),
                    FirstQualification = table.Column<string>(type: "text", nullable: true),
                    SecondQualification = table.Column<string>(type: "text", nullable: true),
                    ProgrammeStudied = table.Column<string>(type: "text", nullable: true),
                    FormerSchool = table.Column<string>(type: "text", nullable: true),
                    LastYearInSchool = table.Column<int>(type: "integer", nullable: false),
                    Awaiting = table.Column<bool>(type: "boolean", nullable: false),
                    Grade = table.Column<int>(type: "integer", nullable: false),
                    YearOfAdmission = table.Column<string>(type: "text", nullable: true),
                    PreferedHall = table.Column<string>(type: "text", nullable: true),
                    Results = table.Column<string>(type: "text", nullable: true),
                    ExternalHostel = table.Column<string>(type: "text", nullable: true),
                    Elligible = table.Column<bool>(type: "boolean", nullable: false),
                    Admitted = table.Column<bool>(type: "boolean", nullable: false),
                    AdmittedBy = table.Column<int>(type: "integer", nullable: false),
                    DateAdmitted = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AdmissionType = table.Column<string>(type: "text", nullable: true),
                    SectionAdmitted = table.Column<string>(type: "text", nullable: true),
                    HallAdmitted = table.Column<string>(type: "text", nullable: true),
                    RoomNo = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    SMSSent = table.Column<bool>(type: "boolean", nullable: false),
                    LetterPrinted = table.Column<bool>(type: "boolean", nullable: false),
                    FirstChoice = table.Column<string>(type: "text", nullable: true),
                    SecondChoice = table.Column<string>(type: "text", nullable: true),
                    ThirdChoice = table.Column<string>(type: "text", nullable: true),
                    FeePaying = table.Column<bool>(type: "boolean", nullable: false),
                    ReportedInSchool = table.Column<bool>(type: "boolean", nullable: false),
                    FeesPaid = table.Column<decimal>(type: "numeric", nullable: false),
                    Reported = table.Column<bool>(type: "boolean", nullable: false),
                    WorkPlace = table.Column<string>(type: "text", nullable: true),
                    WorkPlaceContact = table.Column<string>(type: "text", nullable: true),
                    YearsOfExperience = table.Column<string>(type: "text", nullable: true),
                    SponsorShip = table.Column<bool>(type: "boolean", nullable: false),
                    SponsorShipCompany = table.Column<string>(type: "text", nullable: true),
                    SponsorShipLocation = table.Column<string>(type: "text", nullable: true),
                    SponsorShipCompanyContact = table.Column<string>(type: "text", nullable: true),
                    Form = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantModel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DistrictModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Region = table.Column<int>(type: "integer", nullable: false),
                    ApplicantModelID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistrictModel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DistrictModel_ApplicantModel_ApplicantModelID",
                        column: x => x.ApplicantModelID,
                        principalTable: "ApplicantModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DistrictModel_ApplicantModelID",
                table: "DistrictModel",
                column: "ApplicantModelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DistrictModel");

            migrationBuilder.DropTable(
                name: "ApplicantModel");
        }
    }
}
