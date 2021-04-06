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
                    _logger.LogInformation("User visted FORM page.");
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
                        return RedirectToAction("Index", "Preview");
                 
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


                    if (applicationUser.Started==1)
                    {
                        var applicantModel = await _dbContext.ApplicantModel.FirstOrDefaultAsync(a=>a.ApplicationUserId== ApplicantId);
                        ViewData["applicant"] = applicantModel;
                    }
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

                    DistrictModel district= await _dbContext.DistrictModel.FirstOrDefaultAsync(d => d.ID == Convert.ToInt32(HttpContext.Request.Form["district"]));

                    ProgrammeModel firstChoice = await _dbContext.ProgrammeModel.FirstOrDefaultAsync(p => p.Id == Convert.ToInt32(HttpContext.Request.Form["firstChoice"]));

                    ProgrammeModel secondChoice = await _dbContext.ProgrammeModel.FirstOrDefaultAsync(p => p.Id == Convert.ToInt32(HttpContext.Request.Form["secondChoice"]));

                    ProgrammeModel thirdChoice = await _dbContext.ProgrammeModel.FirstOrDefaultAsync(p => p.Id == Convert.ToInt32(HttpContext.Request.Form["thirdChoice"]));

                    CountryModel country = await _dbContext.CountryModel.FirstOrDefaultAsync(p => p.ID== Convert.ToInt32(HttpContext.Request.Form["nationality"]));

                    HallModel hall = await _dbContext.HallModel.FirstOrDefaultAsync(h => h.Id == Convert.ToInt32(HttpContext.Request.Form["hall"]));

                    SchoolModel school = await _dbContext.SchoolModel.FirstOrDefaultAsync(r => r.Id == Convert.ToInt32(HttpContext.Request.Form["school"]));

                    DenominationModel denomination = await _dbContext.DenominationModel.FirstOrDefaultAsync(r => r.ID == Convert.ToInt32(HttpContext.Request.Form["denomination"]));

                    ReligionModel religion = await _dbContext.ReligionModel.FirstOrDefaultAsync(r => r.Id == Convert.ToInt32(HttpContext.Request.Form["religion"]));


                    SHSProgrammes formerProgramme = await _dbContext.SHSProgrammes.FirstOrDefaultAsync(r => r.ID == Convert.ToInt32(HttpContext.Request.Form["formerProgramme"]));




                    string dob = HttpContext.Request.Form["dob"];

            

                    string[] dobArray = dob.Split("-");

           


                    DateTime dateOfBirth = new DateTime(Convert.ToInt32(dobArray[0]), Convert.ToInt32(dobArray[1]), Convert.ToInt32(dobArray[2]), 7, 0, 0);


                    // check if the form existed in database or is a new form i.e update or insert

                    var applicantModel = await _dbContext.ApplicantModel.FirstOrDefaultAsync(a => a.ApplicationUserId == userId);

                if (applicantModel == null)
                    {
                Console.WriteLine("inserting....");
                        await _dbContext.ApplicantModel.AddAsync(
                            new ApplicantModel
                            {
                                FirstName = HttpContext.Request.Form["fname"],
                                LastName = HttpContext.Request.Form["surname"],
                                DateOfBirth = dateOfBirth,

                                ApplicationUser = user,
                                ApplicationUserId = user.Id,

                                EntryMode = HttpContext.Request.Form["mode"],
                                PreviousName = HttpContext.Request.Form["previousName"],
                                MiddleName = HttpContext.Request.Form["othernames"],
                                Gender = HttpContext.Request.Form["gender"],
                                MaritalStatus = HttpContext.Request.Form["maritalStatus"],
                                Title = HttpContext.Request.Form["title"],
                                Age = _formService.GetAge(dateOfBirth).ToString(),

                                ApplicationNumber = Convert.ToInt32(ApplicantForm),
                                EmergencyContact = HttpContext.Request.Form["emergency"],
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

                                FormerSchool = HttpContext.Request.Form["school"],

                                Denomination = HttpContext.Request.Form["denomination"],

                                Referrals = HttpContext.Request.Form["Referal"],
                                FirstQualification = HttpContext.Request.Form["FirstQualification"],
                                SecondQualification = HttpContext.Request.Form["SecondQualification"],
                                ProgrammeStudied = HttpContext.Request.Form["programme"],
                                LastYearInSchool = Convert.ToInt32(HttpContext.Request.Form["year"]),
                                Awaiting = Convert.ToBoolean(HttpContext.Request.Form["awaiting"]),
                                PreferedHall = HttpContext.Request.Form["hall"],
                                Status = "Applicant",
                                SourceOfFinance = HttpContext.Request.Form["finance"],

                                Hall = hall,
                                SponsorShip = Convert.ToBoolean(HttpContext.Request.Form["sponsorship"]),
                                SponsorShipCompany = HttpContext.Request.Form["sponsorshipName"],
                                SponsorShipCompanyContact = HttpContext.Request.Form["SponsorShipCompanyContact"],
                                SponsorShipLocation = HttpContext.Request.Form["SponsorShipLocation"],

                                District = district,
                                FirstChoiceId = Convert.ToInt32(HttpContext.Request.Form["firstChoice"]),
                                SecondChoiceId = Convert.ToInt32(HttpContext.Request.Form["secondChoice"]),
                                ThirdChoiceId = Convert.ToInt32(HttpContext.Request.Form["thirdChoice"]),

                                Nationality = country,

                                Region = region,

                                School = school,
                                Grade = 10,
                                AdmissionType = "",
                                AdmittedBy = 0,
                            //DateAdmitted = DateTime.ParseExact(HttpContext.Request.Form["dob"], "dd/MM/yyyy", null),
                            DateAdmitted = new DateTime(),
                                HallAdmitted = "",
                                SectionAdmitted = "",
                                YearOfAdmission = _formService.GetAdmissionYear(),
                                Admitted = false,
                                LetterPrinted = false,
                                FeePaying = Convert.ToBoolean(HttpContext.Request.Form["FeePaying"]),
                                ReportedInSchool = false,
                                FeesPaid = Convert.ToDecimal(0.0),
                                Reported = false,
                                Elligible = false,
                                SMSSent = false,
                                Religion = religion,
                                


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

                    }
                    else
                    {

                Console.WriteLine("updating....");
                try
                            {

                        applicantModel.FirstName = HttpContext.Request.Form["fname"];
                        applicantModel.LastName = HttpContext.Request.Form["surname"];
                                applicantModel.DateOfBirth = dateOfBirth;

                                applicantModel.ApplicationUser = user;
                                applicantModel.ApplicationUserId = user.Id;

                                applicantModel.EntryMode = HttpContext.Request.Form["mode"];
                                applicantModel.PreviousName = HttpContext.Request.Form["previousName"];
                               applicantModel.MiddleName = HttpContext.Request.Form["othernames"];
                                applicantModel.Gender = HttpContext.Request.Form["gender"];
                                applicantModel.MaritalStatus = HttpContext.Request.Form["maritalStatus"];
                                applicantModel.Title = HttpContext.Request.Form["title"];
                                applicantModel.Age = _formService.GetAge(dateOfBirth).ToString();

                                applicantModel.ApplicationNumber = Convert.ToInt32(ApplicantForm);
                                applicantModel.EmergencyContact = HttpContext.Request.Form["emergency"];
                                applicantModel.Phone = HttpContext.Request.Form["phone"];
                                applicantModel.AltPhone = HttpContext.Request.Form["altPhone"];
                                applicantModel.Email = HttpContext.Request.Form["email"];
                                applicantModel.Address = HttpContext.Request.Form["address"];
                                applicantModel.PostGPRS = HttpContext.Request.Form["postGPRS"];
                                applicantModel.NationalIDType = HttpContext.Request.Form["NationalityId"];
                                applicantModel.NationalIDNo = HttpContext.Request.Form["NationalityName"];
                                applicantModel.Hometown = HttpContext.Request.Form["hometown"];
                                applicantModel.ResidentialStatus = Convert.ToBoolean(HttpContext.Request.Form["resident"]);

                                applicantModel.GuardianName = HttpContext.Request.Form["guardianName"];
                                applicantModel.GuardianRelationship = HttpContext.Request.Form["guardianRelationship"];

                                applicantModel.GuardianPhone = HttpContext.Request.Form["guardianPhone"];
                                applicantModel.GuardianOccupation = HttpContext.Request.Form["guardianOccupation"];

                                applicantModel.Disability = Convert.ToBoolean(HttpContext.Request.Form["disability"]);

                                applicantModel.DisabilityType = HttpContext.Request.Form["disabilityType"];

                                applicantModel.FormerSchool = HttpContext.Request.Form["school"];

                                applicantModel.Denomination = HttpContext.Request.Form["denomination"];

                                applicantModel.Referrals = HttpContext.Request.Form["Referal"];
                           
                                applicantModel.ProgrammeStudied = HttpContext.Request.Form["programme"];
                                applicantModel.LastYearInSchool = Convert.ToInt32(HttpContext.Request.Form["year"]);
                                applicantModel.Awaiting = Convert.ToBoolean(HttpContext.Request.Form["awaiting"]);
                                applicantModel.PreferedHall = HttpContext.Request.Form["hall"];
                            
                                applicantModel.SourceOfFinance = HttpContext.Request.Form["finance"];

                                applicantModel.Hall = hall;
                                applicantModel.SponsorShip = Convert.ToBoolean(HttpContext.Request.Form["sponsorship"]);
                                applicantModel.SponsorShipCompany = HttpContext.Request.Form["sponsorshipName"];
                                applicantModel.SponsorShipCompanyContact = HttpContext.Request.Form["SponsorShipCompanyContact"];
                                applicantModel.SponsorShipLocation = HttpContext.Request.Form["SponsorShipLocation"];

                                applicantModel.District = district;
                        applicantModel.FirstChoiceId = Convert.ToInt32(HttpContext.Request.Form["firstChoice"]);
                        applicantModel.SecondChoiceId = Convert.ToInt32(HttpContext.Request.Form["secondChoice"]);
                        applicantModel.ThirdChoiceId = Convert.ToInt32(HttpContext.Request.Form["thirdChoice"]);

                                applicantModel.Nationality = country;

                               applicantModel.Region = region;

                                applicantModel.School = school;




                        applicantModel.FeePaying = Convert.ToBoolean(HttpContext.Request.Form["FeePaying"]);
                            applicantModel.FirstQualification= HttpContext.Request.Form["FirstQualification"];
                    applicantModel.SecondQualification = HttpContext.Request.Form["SecondQualification"];
                    applicantModel.Religion = religion;

                                //.Update(applicantModel);


                                if (await _dbContext.SaveChangesAsync()==1)
                                {
                                    TempData["message"] = "Data updated successfully!!";
                                    TempData["type"] = "success";
                                }
                                else
                                {
                                    TempData["message"] = "Error updating data!!";
                                    TempData["type"] = "error";
                                }
                        
                            }
                            catch (DbUpdateConcurrencyException)
                            {
                         
                         
                                    throw;
                        
                            }
               



                    }






            //return View("create");

            return RedirectToAction("Create", "Form");
        }

                


            }
        }
