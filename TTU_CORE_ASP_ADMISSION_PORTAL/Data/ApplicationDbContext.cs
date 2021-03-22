using System;
using System.Collections.Generic;
using System.Text;
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
        public DbSet<TTU_CORE_ASP_ADMISSION_PORTAL.Models.ApplicantModel> FormNoModel { get; set; }
    }
}
