using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TTU_CORE_ASP_ADMISSION_PORTAL.Data;
using TTU_CORE_ASP_ADMISSION_PORTAL.Models;
using TTU_CORE_ASP_ADMISSION_PORTAL.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TTU_CORE_ASP_ADMISSION_PORTAL.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class FormController : Controller
    {
        private readonly ILogger<FormController> _logger;
        private readonly SMSService sms;

        private readonly ApplicationDbContext _dbContext;

        private readonly IHttpContextAccessor _httpContextAccessor;
        private UserManager<ApplicationUser> _userManager;

        public FormController(ILogger<FormController> logger, UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _userManager = userManager;
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
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



            if (FormFinalized == 1)
            {
                return RedirectToAction(nameof(PreviewFormAsync));
            }


            ViewData["regions"] = _formService.GetRegions();

            ViewData["country"] = _formService.GetCountry();
            ViewData["religions"] = _formService.GetReligions();

            ViewData["choices"] = _formService.GetProgrammes();

            ViewData["programme"] =_formService.GetSHSProgrammes();

            ViewData["denominations"] = _formService.GetDenominations();

            ViewData["districts"] = _formService.GetDistrict();

            ViewData["school"] = _formService.GetSchools();
            ViewData["hall"] = _formService.GetHalls();
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveAysnc()
        {
    //        Character character = await _context.Characters
    //.FirstOrDefaultAsync(c => c.Id == newWeapon.CharacterId &&
    //c.User.Id == int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)));

            FormService _formService = new FormService(_dbContext);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId

             
            ApplicationUser applicationUser = await _userManager.GetUserAsync(User);

            var ApplicantForm = applicationUser?.FormNo;

            ApplicationUser user = await _dbContext.Users.FirstOrDefaultAsync(n => n.Id == userId);

            RegionModel region = await _dbContext.RegionModel.FirstOrDefaultAsync(r=>r.Id== Convert.ToInt32(HttpContext.Request.Form["region"]));

             

            string dob = HttpContext.Request.Form["dob"];

            

            string[] dobArray = dob.Split("-");

           


            DateTime dateOfBirth = new DateTime(Convert.ToInt32(dobArray[0]), Convert.ToInt32(dobArray[1]), Convert.ToInt32(dobArray[2]), 7, 0, 0);


            
            await _dbContext.ApplicantModel.AddAsync(
                new ApplicantModel
                {
                    FirstName = HttpContext.Request.Form["fname"],
                    LastName = HttpContext.Request.Form["surname"],
                    DateOfBirth = dateOfBirth,

                    ApplicationUser= user,


                    PreviousName = HttpContext.Request.Form["previousName"],
                    MiddleName = HttpContext.Request.Form["othernames"],
                    Gender = HttpContext.Request.Form["gender"],
                    MaritalStatus = HttpContext.Request.Form["maritalStatus"],
                    Title = HttpContext.Request.Form["title"],
                    Age = _formService.GetAge(dateOfBirth).ToString(),
                    
                    ApplicationNumber = Convert.ToInt32(ApplicantForm),
                    EmergencyContact= HttpContext.Request.Form["emergency"],
                    Phone = HttpContext.Request.Form["phone"],
                    AltPhone = HttpContext.Request.Form["altPhone"],
                    Email = HttpContext.Request.Form["email"],
                    Address = HttpContext.Request.Form["address"],
                    PostGPRS = HttpContext.Request.Form["postGPRS"],
                    NationalIDType = HttpContext.Request.Form["NationalityId"],
                    NationalIDNo = HttpContext.Request.Form["NationalityName"],
                    Hometown = HttpContext.Request.Form["hometown"],
                    ResidentialStatus = Convert.ToBoolean(HttpContext.Request.Form["resident"]),
                    
                    GuardianName = HttpContext.Request.Form["guardianName"],
                    GuardianRelationship = HttpContext.Request.Form["guardianRelationship"],
                   
                    GuardianPhone = HttpContext.Request.Form["guardianPhone"],
                    GuardianOccupation = HttpContext.Request.Form["guardianOccupation"],

                    Disability = Convert.ToBoolean(HttpContext.Request.Form["disability"]),

                    DisabilityType = HttpContext.Request.Form["disabilityType"],
                   
                    FormerSchool= HttpContext.Request.Form["school"],
                    ApplicationUserId = 1,
                    Denomination = HttpContext.Request.Form["denomination"],

                    Referrals = HttpContext.Request.Form["Referal"],
                    FirstQualification = "wascce",
                    SecondQualification = "bece",
                    ProgrammeStudied = HttpContext.Request.Form["programme"],
                    LastYearInSchool = Convert.ToInt32(HttpContext.Request.Form["year"]),
                    Awaiting = Convert.ToBoolean(HttpContext.Request.Form["awaiting"]),
                    PreferedHall = HttpContext.Request.Form["hall"],
                    Status = "Applicant",
                    SourceOfFinance= HttpContext.Request.Form["finance"],


                    SponsorShip = Convert.ToBoolean(HttpContext.Request.Form["sponsorship"]),
                    SponsorShipCompany = HttpContext.Request.Form["sponsorshipName"],
                    SponsorShipCompanyContact = HttpContext.Request.Form["SponsorShipCompanyContact"],
                    SponsorShipLocation = HttpContext.Request.Form["SponsorShipLocation"],

                    DistrictId = 1,
                    FirstChoiceId = 1,
                    SecondChoiceId = 1,
                    ThirdChoiceId = 1,

                    NationalityId = 1,

                    Region = region,

                    SchoolId = 1,
                    Grade = 10,
                    AdmissionType = "",
                    AdmittedBy = 1,
                    //DateAdmitted = DateTime.ParseExact(HttpContext.Request.Form["dob"], "dd/MM/yyyy", null),
                    DateAdmitted = new DateTime(),
                    HallAdmitted = "",
                    SectionAdmitted = "",
                    YearOfAdmission = _formService.GetAdmissionYear(),
                    Admitted = false,
                    LetterPrinted = false,
                    FeePaying = Convert.ToBoolean(HttpContext.Request.Form["FeePaying"]),
                    ReportedInSchool = false,
                    FeesPaid =Convert.ToDecimal( 0.0),
                    Reported = false,
                    Elligible = false,
                    SMSSent = false,
                    ReligionId = 2


                });



            if (await _dbContext.SaveChangesAsync() == 1)
            {
                TempData["message"] = "Data saved successfully!!";
                TempData["type"] = "success";

                var applicant = await _dbContext.Users.FindAsync(userId);
                
                user.Started = 1;
                await _dbContext.SaveChangesAsync();
                
            }
            else
            {
                TempData["message"] = "Error saving data!!";
                TempData["type"] = "error";
            }

             


            return View("create");
        }

        public async Task<IActionResult> PreviewFormAsync()
        {

           return View();
        }


    }
}
