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
    [Microsoft.AspNetCore.Authorization.Authorize]
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

            //[HttpPost]
            //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> SaveAysnc([Bind("ID,ApplicationNumber,Title,FirstName,MiddleName,LastName,Name,PreviousName,DateOfBirth,Gender,Age,MaritalStatus,Phone,AltPhone,Email,Address,PostGPRS,EmergencyContact,Hometown,NationalIDType,NationalIDNo,Region,Nationality,ResidentialStatus,GuardianName,GuardianAddress,GuardianEmail,GuardianPhone,GuardianOccupation,GuardianRelationship,Disability,DisabilityType,SourceOfFinance,Religion,Denomination,Referrals,EntryMode,FirstQualification,SecondQualification,ProgrammeStudied,FormerSchool,LastYearInSchool,Awaiting,Grade,YearOfAdmission,PreferedHall,Results,ExternalHostel,Elligible,Admitted,AdmittedBy,DateAdmitted,AdmissionType,SectionAdmitted,HallAdmitted,RoomNo,Status,SMSSent,LetterPrinted,FirstChoice,SecondChoice,ThirdChoice,FeePaying,ReportedInSchool,FeesPaid,Reported,WorkPlace,WorkPlaceContact,YearsOfExperience,SponsorShip,SponsorShipCompany,SponsorShipLocation,SponsorShipCompanyContact,Form")] ApplicantModel applicantModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //         _dbContext.Add(applicantModel);
        //        await _dbContext.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(applicantModel);
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveAysnc()
        {
            FormService _formService = new FormService(_dbContext);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId

            ApplicationUser applicationUser = await _userManager.GetUserAsync(User);

            var ApplicantForm = applicationUser?.FormNo;
            await _dbContext.ApplicantModel.AddAsync(
                new ApplicantModel
                {
                    FirstName = HttpContext.Request.Form["fname"],
                    LastName = HttpContext.Request.Form["surname"],
                  DateOfBirth =new DateTime(),
                 // DateOfBirth = DateTime.ParseExact(HttpContext.Request.Form["dob"], "dd/MM/yyyy", null),
                    PreviousName = HttpContext.Request.Form["previousName"],
                    MiddleName = HttpContext.Request.Form["othernames"],
                    Gender = HttpContext.Request.Form["gender"],
                    MaritalStatus = HttpContext.Request.Form["maritalStatus"],
                    Title = HttpContext.Request.Form["title"],
                    //Age = _formService.GetAge(DateTime.Parse(HttpContext.Request.Form["dob"])).ToString(),
                    Age="10",
                    ApplicationNumber = Convert.ToInt32(ApplicantForm),

                    Phone = HttpContext.Request.Form["phone"],
                    AltPhone = HttpContext.Request.Form["altPhone"],
                    Email = HttpContext.Request.Form["email"],
                    Address = HttpContext.Request.Form["address"],
                    PostGPRS = HttpContext.Request.Form["postGPRS"],
                    NationalIDType = "Voters",
                    NationalIDNo = "12322",
                    Hometown = HttpContext.Request.Form["hometown"],
                    ResidentialStatus = true,
                    GuardianName = HttpContext.Request.Form["guardianName"],
                    GuardianRelationship = HttpContext.Request.Form["guardianRelationship"],
                    GuardianAddress = HttpContext.Request.Form["guardianAddress"],
                    GuardianPhone = HttpContext.Request.Form["guardianPhone"],
                    GuardianOccupation = HttpContext.Request.Form["guardianOccupation"],

                    Disability = true,

                    DisabilityType = HttpContext.Request.Form["disabilityType"],
                    SourceOfFinance = "self",

                    ApplicationUserId = 1,
                    Denomination = HttpContext.Request.Form["denomination"],

                    Referrals = HttpContext.Request.Form["Referal"],
                    FirstQualification = "wascce",
                    SecondQualification = "bece",
                    ProgrammeStudied = HttpContext.Request.Form["programme"],
                    LastYearInSchool = Convert.ToInt32(HttpContext.Request.Form["year"]),
                    Awaiting = true,
                    PreferedHall = HttpContext.Request.Form["hall"],
                    Status = "Admitted",

                    SponsorShip = true,
                    SponsorShipCompany = HttpContext.Request.Form["sponsorshipName"],
                    SponsorShipCompanyContact = "ucc 13, cape coast",
                    SponsorShipLocation = "cape coast",
                  //DistrictId= Convert.ToInt32(HttpContext.Request.Form["district"]),

                  //FirstChoiceId= Convert.ToInt32(HttpContext.Request.Form["firstChoice"]),
                  //SecondChoiceId = Convert.ToInt32(HttpContext.Request.Form["secondChoice"]),
                  //ThirdChoiceId = Convert.ToInt32(HttpContext.Request.Form["thirdChoice"]),

                  //NationalityId = Convert.ToInt32(HttpContext.Request.Form["nationality"]),

                  //RegionId = Convert.ToInt32(HttpContext.Request.Form["nationality"]),

                  //SchoolId = Convert.ToInt32(HttpContext.Request.Form["nationality"]),
                  DistrictId=1,
                  FirstChoiceId = 1,
                    SecondChoiceId = 1,
                    ThirdChoiceId = 1,

                    NationalityId = 1,

                    RegionId = 1,

                    SchoolId = 1,
                    Grade=10,
                    AdmissionType="Regular",
                    AdmittedBy=1,
                    //DateAdmitted = DateTime.ParseExact(HttpContext.Request.Form["dob"], "dd/MM/yyyy", null),
                    DateAdmitted= new DateTime(),
                    HallAdmitted ="Ahanta",
                    SectionAdmitted="Regular",
                    YearOfAdmission=_formService.GetAdmissionYear(),
                    Admitted=true,
                    LetterPrinted=true,
                    FeePaying=true,
                    ReportedInSchool=true,
                    FeesPaid=40,
                    Reported=true,
                    Elligible=true,
                    SMSSent=true,
                    ReligionId=2
                     

                });


            //await _dbContext.ApplicantModel.AddAsync(applicant);

            //if (result==1) {
            //    TempData["message"] = "Data saved successfully!!";
            //    TempData["type"] = "success";
            //}
            //else
            //{
           await _dbContext.SaveChangesAsync();
                TempData["message"] = HttpContext.Request.ToString();
                TempData["type"] = "error";

            //}
           

            return View("create");
        }

        public async Task<IActionResult> PreviewFormAsync()
            {
                return View();
            }


        }
    }
