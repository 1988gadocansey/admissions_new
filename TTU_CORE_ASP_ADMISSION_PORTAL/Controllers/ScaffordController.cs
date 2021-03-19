using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TTU_CORE_ASP_ADMISSION_PORTAL.Data;
using TTU_CORE_ASP_ADMISSION_PORTAL.Models;

namespace TTU_CORE_ASP_ADMISSION_PORTAL.Controllers

{
    public class ScaffordController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ScaffordController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Scafford
        public async Task<IActionResult> Index()
        {
            return View(await _context.ApplicantModel.ToListAsync());
        }

        // GET: Scafford/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicantModel = await _context.ApplicantModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (applicantModel == null)
            {
                return NotFound();
            }

            return View(applicantModel);
        }

        // GET: Scafford/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Scafford/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ApplicationNumber,Title,FirstName,MiddleName,LastName,Name,PreviousName,DateOfBirth,Gender,Age,MaritalStatus,Phone,AltPhone,Email,Address,PostGPRS,EmergencyContact,Hometown,NationalIDType,NationalIDNo,Region,Nationality,ResidentialStatus,GuardianName,GuardianAddress,GuardianEmail,GuardianPhone,GuardianOccupation,GuardianRelationship,Disability,DisabilityType,SourceOfFinance,Religion,Denomination,Referrals,EntryMode,FirstQualification,SecondQualification,ProgrammeStudied,FormerSchool,LastYearInSchool,Awaiting,Grade,YearOfAdmission,PreferedHall,Results,ExternalHostel,Elligible,Admitted,AdmittedBy,DateAdmitted,AdmissionType,SectionAdmitted,HallAdmitted,RoomNo,Status,SMSSent,LetterPrinted,FirstChoice,SecondChoice,ThirdChoice,FeePaying,ReportedInSchool,FeesPaid,Reported,WorkPlace,WorkPlaceContact,YearsOfExperience,SponsorShip,SponsorShipCompany,SponsorShipLocation,SponsorShipCompanyContact,Form")] ApplicantModel applicantModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applicantModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(applicantModel);
        }

        // GET: Scafford/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicantModel = await _context.ApplicantModel.FindAsync(id);
            if (applicantModel == null)
            {
                return NotFound();
            }
            return View(applicantModel);
        }

        // POST: Scafford/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ApplicationNumber,Title,FirstName,MiddleName,LastName,Name,PreviousName,DateOfBirth,Gender,Age,MaritalStatus,Phone,AltPhone,Email,Address,PostGPRS,EmergencyContact,Hometown,NationalIDType,NationalIDNo,Region,Nationality,ResidentialStatus,GuardianName,GuardianAddress,GuardianEmail,GuardianPhone,GuardianOccupation,GuardianRelationship,Disability,DisabilityType,SourceOfFinance,Religion,Denomination,Referrals,EntryMode,FirstQualification,SecondQualification,ProgrammeStudied,FormerSchool,LastYearInSchool,Awaiting,Grade,YearOfAdmission,PreferedHall,Results,ExternalHostel,Elligible,Admitted,AdmittedBy,DateAdmitted,AdmissionType,SectionAdmitted,HallAdmitted,RoomNo,Status,SMSSent,LetterPrinted,FirstChoice,SecondChoice,ThirdChoice,FeePaying,ReportedInSchool,FeesPaid,Reported,WorkPlace,WorkPlaceContact,YearsOfExperience,SponsorShip,SponsorShipCompany,SponsorShipLocation,SponsorShipCompanyContact,Form")] ApplicantModel applicantModel)
        {
            if (id != applicantModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicantModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicantModelExists(applicantModel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(applicantModel);
        }

        // GET: Scafford/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicantModel = await _context.ApplicantModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (applicantModel == null)
            {
                return NotFound();
            }

            return View(applicantModel);
        }

        // POST: Scafford/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var applicantModel = await _context.ApplicantModel.FindAsync(id);
            _context.ApplicantModel.Remove(applicantModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicantModelExists(int id)
        {
            return _context.ApplicantModel.Any(e => e.ID == id);
        }
    }
}
