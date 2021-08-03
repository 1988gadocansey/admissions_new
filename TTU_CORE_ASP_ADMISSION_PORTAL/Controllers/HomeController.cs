using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TTU_CORE_ASP_ADMISSION_PORTAL.Data;
using TTU_CORE_ASP_ADMISSION_PORTAL.Models;
using TTU_CORE_ASP_ADMISSION_PORTAL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using RestSharp;

namespace TTU_CORE_ASP_ADMISSION_PORTAL.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SMSService sms;

        private readonly ApplicationDbContext _dbContext;

        private readonly IHelper _helper;
        private UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, IHelper helper, UserManager<ApplicationUser> userManager,
            ApplicationDbContext dbContext)
        {
            _logger = logger;
            _userManager = userManager;
            _dbContext = dbContext;
            _helper = helper;
        }

        //[Consumes(MediaTypeNames.Application.Json)]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> IndexAsync()
        {
            _logger.LogInformation("User visted dashboard.");
            FormService _formService = new FormService(_dbContext);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
            var userName = User.FindFirstValue(ClaimTypes.Name); // will give the user's userName

            ApplicationUser applicationUser = await _userManager.GetUserAsync(User);

            var applicationNo = applicationUser?.FormNo;

            var status = applicationUser?.Admitted;
            ViewData["formno"] = "";

            if (applicationNo == null)
            {
                var Year = (DateTime.Now.Year).ToString();
                // ViewData["formno"] = _formService.GetFormNo();
                string application = _formService.GetFormNo();

                var user = await _userManager.GetUserAsync(User);


                user.FormNo = Year + application;

                // Apply the changes if any to the db
                // UserManager.Update(user);
                if (_dbContext.SaveChanges() == 1)
                {
                    // if we are able to allocate form number to an applicant
                    // then lets update the form number generator + 1
                    await _formService.UpdateFormNoAsync();
                }
            }

            else
            {
                ViewData["formno"] = applicationNo;
            }

            if ((bool) status)
            {
                var applicantModel =
                    await _dbContext.ApplicantModel.FirstOrDefaultAsync(a => a.ApplicationUserId == userId);

                ViewData["fees"] = applicantModel.FeesPaid;
                ViewData["hallfeespaid"] = applicantModel.HallFeesPaid;
                ViewData["resident"] = applicantModel.ResidentialStatus;
                ViewData["room"] = applicantModel.RoomNo;
                var applicantNo = applicantModel.ApplicationNumber;
                Console.WriteLine(" room is "+applicantModel.RoomNo);
                var programmeadmittedid = _helper.GetApplicantCodeFromId((int) applicantModel.ProgrammeAdmittedId);
                var leveladmitted = applicantModel.leveladmitted;
                var yearofadmission = applicantModel.YearOfAdmission;
                var hallfees = _helper.GetHallFee(applicantModel.HallAdmitted);
                var hallname = _helper.GetHallName(applicantModel.HallAdmitted);
                // calling external api .. srms
                var client = new RestClient($"https://srms.ttuportal.com/api/fees/components/{programmeadmittedid}/program/{leveladmitted}/level/{yearofadmission}/year");
                var request = new RestRequest(Method.GET);
                IRestResponse response = await client.ExecuteAsync(request);
                
                Console.WriteLine($"https://srms.ttuportal.com/api/fees/components/{programmeadmittedid}/program/{leveladmitted}/level/{yearofadmission}/year");

                //TODO: transform the response here to suit your needs
                ViewData["feedata"] = response.Content;
                ViewData["hallfees"] = hallfees;
                ViewData["hallname"] = hallname;
                
                // fetch hall fee and school fees paid from srms and update admissions accordingly
                
               

                    var clientSRMSAUF = new RestClient($"https://srms.ttuportal.com/api/rooms/update");
                    var requestSRMSAUF = new RestRequest(Method.POST);
                    request.AddJsonBody(new
                    {
                        year = yearofadmission,
                        type = "School Fees",
                        applicationNumber = applicantNo
                    });

                    Console.WriteLine($"https://srms.ttuportal.com/api/applicant/fees/fetch");
                    IRestResponse responseSMS = await clientSRMSAUF.ExecuteAsync(requestSRMSAUF);

                    var schoolFeesPaid = responseSMS.Content;

                    // Lets get hall fees

                    var clientSRMSHall = new RestClient($"https://srms.ttuportal.com/api/rooms/update");
                    var requestSRMSHall = new RestRequest(Method.POST);
                    request.AddJsonBody(new
                    {
                        year = yearofadmission,
                        type = "School Fees",
                        applicationNumber = applicantNo
                    });

                    Console.WriteLine($"https://srms.ttuportal.com/api/applicant/fees/fetch");
                    IRestResponse responseSMSHall = await clientSRMSHall.ExecuteAsync(requestSRMSHall);

                    var hallFeesPaid = responseSMSHall.Content;
                    var applicantData = await _dbContext.ApplicantModel.FirstOrDefaultAsync(a => a.ApplicationUserId == userId);
                    applicantData.FeesPaid = Convert.ToDecimal(schoolFeesPaid);
                    applicantData.HallFeesPaid =Convert.ToDecimal( hallFeesPaid);
                    await _dbContext.SaveChangesAsync();
                    
                    

            }

            return View();
        }


        public IActionResult Dashboard() => View(
            // SMSService sms = new SMSService()
        );

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }


        [Produces("application/json")]
        public async Task<IActionResult> FinanlizedAsync()
        {
            _logger.LogInformation("User finalized forms.");

            FormService _formService = new FormService(_dbContext);

            var ApplicantId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId

            var applicant = await _dbContext.Users.FindAsync(ApplicantId);

            applicant.FormCompleted = 1;
            applicant.Finalized = 1;

            await _dbContext.SaveChangesAsync();

            // pull applicant info from applicant table

            var applicantModel =
                await _dbContext.ApplicantModel.FirstOrDefaultAsync(a => a.ApplicationUserId == ApplicantId);
            var phone = applicantModel.Phone;

            var fname = applicantModel.FirstName;


            var message = "Hi " + fname + " your form has been received. Vist admissions.ttuportal.com with to check your admission status";


            var result = _helper.SendSMSNotification(phone, message);


            //Console.WriteLine("ddd");


            return Json(new {code = 1});

            // return RedirectToAction("Index", "Home");
        }
    }
}