﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TTU_CORE_ASP_ADMISSION_PORTAL.Data;

namespace TTU_CORE_ASP_ADMISSION_PORTAL.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210319010701_ApplicantModel2")]
    partial class ApplicantModel2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("TTU_CORE_ASP_ADMISSION_PORTAL.Models.ApplicantModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("AdmissionType")
                        .HasColumnType("text");

                    b.Property<bool>("Admitted")
                        .HasColumnType("boolean");

                    b.Property<int>("AdmittedBy")
                        .HasColumnType("integer");

                    b.Property<string>("Age")
                        .HasColumnType("text");

                    b.Property<string>("AltPhone")
                        .HasColumnType("text");

                    b.Property<int>("ApplicationNumber")
                        .HasColumnType("integer");

                    b.Property<bool>("Awaiting")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("DateAdmitted")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Denomination")
                        .HasColumnType("text");

                    b.Property<bool>("Disability")
                        .HasColumnType("boolean");

                    b.Property<string>("DisabilityType")
                        .HasColumnType("text");

                    b.Property<bool>("Elligible")
                        .HasColumnType("boolean");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("EmergencyContact")
                        .HasColumnType("text");

                    b.Property<string>("EntryMode")
                        .HasColumnType("text");

                    b.Property<string>("ExternalHostel")
                        .HasColumnType("text");

                    b.Property<bool>("FeePaying")
                        .HasColumnType("boolean");

                    b.Property<decimal>("FeesPaid")
                        .HasColumnType("numeric");

                    b.Property<string>("FirstChoice")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("FirstQualification")
                        .HasColumnType("text");

                    b.Property<string>("Form")
                        .HasColumnType("text");

                    b.Property<string>("FormerSchool")
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Grade")
                        .HasColumnType("integer");

                    b.Property<string>("GuardianAddress")
                        .HasColumnType("text");

                    b.Property<string>("GuardianEmail")
                        .HasColumnType("text");

                    b.Property<string>("GuardianName")
                        .HasColumnType("text");

                    b.Property<string>("GuardianOccupation")
                        .HasColumnType("text");

                    b.Property<string>("GuardianPhone")
                        .HasColumnType("text");

                    b.Property<string>("GuardianRelationship")
                        .HasColumnType("text");

                    b.Property<string>("HallAdmitted")
                        .HasColumnType("text");

                    b.Property<string>("Hometown")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("LastYearInSchool")
                        .HasColumnType("integer");

                    b.Property<bool>("LetterPrinted")
                        .HasColumnType("boolean");

                    b.Property<string>("MaritalStatus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("NationalIDNo")
                        .HasColumnType("text");

                    b.Property<string>("NationalIDType")
                        .HasColumnType("text");

                    b.Property<string>("Nationality")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PostGPRS")
                        .HasColumnType("text");

                    b.Property<string>("PreferedHall")
                        .HasColumnType("text");

                    b.Property<string>("PreviousName")
                        .HasColumnType("text");

                    b.Property<string>("ProgrammeStudied")
                        .HasColumnType("text");

                    b.Property<string>("Referrals")
                        .HasColumnType("text");

                    b.Property<string>("Region")
                        .HasColumnType("text");

                    b.Property<string>("Religion")
                        .HasColumnType("text");

                    b.Property<bool>("Reported")
                        .HasColumnType("boolean");

                    b.Property<bool>("ReportedInSchool")
                        .HasColumnType("boolean");

                    b.Property<bool>("ResidentialStatus")
                        .HasColumnType("boolean");

                    b.Property<string>("Results")
                        .HasColumnType("text");

                    b.Property<string>("RoomNo")
                        .HasColumnType("text");

                    b.Property<bool>("SMSSent")
                        .HasColumnType("boolean");

                    b.Property<string>("SecondChoice")
                        .HasColumnType("text");

                    b.Property<string>("SecondQualification")
                        .HasColumnType("text");

                    b.Property<string>("SectionAdmitted")
                        .HasColumnType("text");

                    b.Property<string>("SourceOfFinance")
                        .HasColumnType("text");

                    b.Property<bool>("SponsorShip")
                        .HasColumnType("boolean");

                    b.Property<string>("SponsorShipCompany")
                        .HasColumnType("text");

                    b.Property<string>("SponsorShipCompanyContact")
                        .HasColumnType("text");

                    b.Property<string>("SponsorShipLocation")
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<string>("ThirdChoice")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("WorkPlace")
                        .HasColumnType("text");

                    b.Property<string>("WorkPlaceContact")
                        .HasColumnType("text");

                    b.Property<string>("YearOfAdmission")
                        .HasColumnType("text");

                    b.Property<string>("YearsOfExperience")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("ApplicantModel");
                });

            modelBuilder.Entity("TTU_CORE_ASP_ADMISSION_PORTAL.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("Branch")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<int>("Finalized")
                        .HasColumnType("integer");

                    b.Property<int>("FormCompleted")
                        .HasColumnType("integer");

                    b.Property<string>("FormNo")
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<int>("PictureUploaded")
                        .HasColumnType("integer");

                    b.Property<string>("Pin")
                        .HasColumnType("text");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<int>("Sold")
                        .HasColumnType("integer");

                    b.Property<string>("SoldBy")
                        .HasColumnType("text");

                    b.Property<int>("Started")
                        .HasColumnType("integer");

                    b.Property<string>("Teller")
                        .HasColumnType("text");

                    b.Property<string>("TellerPhone")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("Year")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("TTU_CORE_ASP_ADMISSION_PORTAL.Models.DistrictModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ApplicantModelID")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Region")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("ApplicantModelID");

                    b.ToTable("DistrictModel");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TTU_CORE_ASP_ADMISSION_PORTAL.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TTU_CORE_ASP_ADMISSION_PORTAL.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TTU_CORE_ASP_ADMISSION_PORTAL.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("TTU_CORE_ASP_ADMISSION_PORTAL.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TTU_CORE_ASP_ADMISSION_PORTAL.Models.DistrictModel", b =>
                {
                    b.HasOne("TTU_CORE_ASP_ADMISSION_PORTAL.Models.ApplicantModel", null)
                        .WithMany("District")
                        .HasForeignKey("ApplicantModelID");
                });

            modelBuilder.Entity("TTU_CORE_ASP_ADMISSION_PORTAL.Models.ApplicantModel", b =>
                {
                    b.Navigation("District");
                });
#pragma warning restore 612, 618
        }
    }
}
