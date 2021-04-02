using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TTU_CORE_ASP_ADMISSION_PORTAL.Models;

namespace TTU_CORE_ASP_ADMISSION_PORTAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TTU_CORE_ASP_ADMISSION_PORTAL.Models.ApplicantModel> ApplicantModel { get; set; }
       public DbSet<TTU_CORE_ASP_ADMISSION_PORTAL.Models.FormNoModel> FormNoModel { get; set; }
        public DbSet<TTU_CORE_ASP_ADMISSION_PORTAL.Models.AcademicExperieceModel> AcademicExperieceModel { get; set; }

        public DbSet<TTU_CORE_ASP_ADMISSION_PORTAL.Models.BankModel> BankModel { get; set; }

        public DbSet<TTU_CORE_ASP_ADMISSION_PORTAL.Models.DenominationModel> DenominationModel { get; set; }

        public DbSet<TTU_CORE_ASP_ADMISSION_PORTAL.Models.DepartmentModel> DepartmentModel { get; set; }

        public DbSet<TTU_CORE_ASP_ADMISSION_PORTAL.Models.DistrictModel> DistrictModel { get; set; }

        public DbSet<TTU_CORE_ASP_ADMISSION_PORTAL.Models.DocumentUploadModel> DocumentUploadModel { get; set; }

        public DbSet<TTU_CORE_ASP_ADMISSION_PORTAL.Models.ExamModel> ExamModel { get; set; }

        public DbSet<TTU_CORE_ASP_ADMISSION_PORTAL.Models.FacultyModel> FacultyModel { get; set; }

        public DbSet<TTU_CORE_ASP_ADMISSION_PORTAL.Models.GradeModel> GradeModel { get; set; }

        public DbSet<TTU_CORE_ASP_ADMISSION_PORTAL.Models.HallModel> HallModel { get; set; }

        public DbSet<TTU_CORE_ASP_ADMISSION_PORTAL.Models.RegionModel> RegionModel { get; set; }

        public DbSet<TTU_CORE_ASP_ADMISSION_PORTAL.Models.ReligionModel> ReligionModel { get; set; }

        public DbSet<TTU_CORE_ASP_ADMISSION_PORTAL.Models.RequirementModel> RequirementModel { get; set; }

        public DbSet<TTU_CORE_ASP_ADMISSION_PORTAL.Models.SchoolModel> SchoolModel { get; set; }

        public DbSet<TTU_CORE_ASP_ADMISSION_PORTAL.Models.SMSModel> SMSModel { get; set; }

        public DbSet<TTU_CORE_ASP_ADMISSION_PORTAL.Models.SubjectModel> SubjectModel { get; set; }

        public DbSet<TTU_CORE_ASP_ADMISSION_PORTAL.Models.SHSProgrammes> SHSProgrammes { get; set; }

        public DbSet<TTU_CORE_ASP_ADMISSION_PORTAL.Models.CountryModel> CountryModel { get; set; }

        public DbSet<TTU_CORE_ASP_ADMISSION_PORTAL.Models.ProgrammeModel> ProgrammeModel { get; set; }


        public DbSet<TTU_CORE_ASP_ADMISSION_PORTAL.Models.WorkingExperienceModel> WorkingExperienceModel { get; set; }


        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override async Task<int> SaveChangesAsync(
           bool acceptAllChangesOnSuccess,
           CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            OnBeforeSaving();
            return (await base.SaveChangesAsync(acceptAllChangesOnSuccess,
                          cancellationToken));
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            var utcNow = DateTime.UtcNow;

            foreach (var entry in entries)
            {
                // for entities that inherit from BaseEntity,
                // set UpdatedOn / CreatedOn appropriately
                if (entry.Entity is BaseEntity trackable)
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            // set the updated date to "now"
                            trackable.UpdatedOn = utcNow;

                            // mark property as "don't touch"
                            // we don't want to update on a Modify operation
                            entry.Property("CreatedOn").IsModified = false;
                            break;

                        case EntityState.Added:
                            // set both updated and created date to "now"
                            trackable.CreatedOn = utcNow;
                            trackable.UpdatedOn = utcNow;
                            break;
                    }
                }
            }
        }




    }
}
