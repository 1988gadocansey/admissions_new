    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using TTU_CORE_ASP_ADMISSION_PORTAL.Data;
    using TTU_CORE_ASP_ADMISSION_PORTAL.Models;
    using TTU_CORE_ASP_ADMISSION_PORTAL.Services;

    // For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

    namespace TTU_CORE_ASP_ADMISSION_PORTAL.Controllers
    {
        public class FormController : Controller
        {
            private readonly ILogger<FormController> _logger;
            private readonly SMSService sms;

            private readonly ApplicationDbContext _dbContext;


            private UserManager<ApplicationUser> _userManager;

            public FormController(ILogger<FormController> logger, UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext)
            {
                _logger = logger;
                _userManager = userManager;
                _dbContext = dbContext;


           

            }
        [HttpGet]
        public async Task<IActionResult> CreateAsync()
            {
                FormService _formService = new FormService(_dbContext);
                var ApplicantId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
                var ApplicantName = User.FindFirstValue(ClaimTypes.Name); // will give the user's userName

                ApplicationUser applicationUser = await _userManager.GetUserAsync(User);

                var ApplicantForm = applicationUser?.FormNo;

                var FormFinalized = applicationUser?.Finalized;

                var ApplicantPin = applicationUser?.Pin;
                var ApplicantFormType = applicationUser?.Type;
            
                

                if (FormFinalized==1)
                {
                    return RedirectToAction(nameof(PreviewFormAsync));
                }


                // check if applicant exist in db.. retrieve it and send it to view

                //var ApplicantData?  = _dbContext.ApplicantModel.Where(n => n.ApplicationNumber.ToString() == ApplicantForm).First();

                

            return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> SaveAysnc([Bind("ID,ApplicationNumber,Title,FirstName,MiddleName,LastName,Name,PreviousName,DateOfBirth,Gender,Age,MaritalStatus,Phone,AltPhone,Email,Address,PostGPRS,EmergencyContact,Hometown,NationalIDType,NationalIDNo,Region,Nationality,ResidentialStatus,GuardianName,GuardianAddress,GuardianEmail,GuardianPhone,GuardianOccupation,GuardianRelationship,Disability,DisabilityType,SourceOfFinance,Religion,Denomination,Referrals,EntryMode,FirstQualification,SecondQualification,ProgrammeStudied,FormerSchool,LastYearInSchool,Awaiting,Grade,YearOfAdmission,PreferedHall,Results,ExternalHostel,Elligible,Admitted,AdmittedBy,DateAdmitted,AdmissionType,SectionAdmitted,HallAdmitted,RoomNo,Status,SMSSent,LetterPrinted,FirstChoice,SecondChoice,ThirdChoice,FeePaying,ReportedInSchool,FeesPaid,Reported,WorkPlace,WorkPlaceContact,YearsOfExperience,SponsorShip,SponsorShipCompany,SponsorShipLocation,SponsorShipCompanyContact,Form")] ApplicantModel applicantModel)
            {
                if (ModelState.IsValid)
                {
                     _dbContext.Add(applicantModel);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(applicantModel);
            }

        public async Task<IActionResult> PreviewFormAsync()
            {
                return View();
            }


        }
    }
