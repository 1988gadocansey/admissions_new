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

namespace TTU_CORE_ASP_ADMISSION_PORTAL.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SMSService sms;
        
        private readonly ApplicationDbContext _dbContext;


        private UserManager<ApplicationUser> _userManager;
        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _userManager = userManager;
            _dbContext= dbContext;


        }
        //[Consumes(MediaTypeNames.Application.Json)]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> IndexAsync ()
        {
            _logger.LogInformation("User visted dashboard.");
            FormService _formService = new FormService(_dbContext);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
            var userName = User.FindFirstValue(ClaimTypes.Name); // will give the user's userName


            // update user last login


            
            //var auth = _dbContext.Users.Where(n => n.Id == userId).First();
            //auth.LastLogin = DateTimeOffset.UtcNow;
            // await _dbContext.SaveChangesAsync();











            ApplicationUser applicationUser = await _userManager.GetUserAsync(User);

            var applicationNo = applicationUser?.FormNo;


            ViewData["formno"] = "";


            // lets check if the applicant has been admitted. if yes redirect him to pdf letter
            // else show in homepage
            //if (admitted)
            //{

            //}


            if (applicationNo == null)
            {
                var Year = (DateTime.Now.Year).ToString();
                // ViewData["formno"] = _formService.GetFormNo();
                string application = _formService.GetFormNo();

                var user = await _userManager.GetUserAsync(User);


                user.FormNo = Year+application;

                // Apply the changes if any to the db
                // UserManager.Update(user);
               if(_dbContext.SaveChanges()==1)
                {
                    // if we are able to allocate form number to an applicant
                    // then lets update the form number generator + 1
                  await  _formService.UpdateFormNoAsync();
                }
            }

            else { ViewData["formno"] = applicationNo; }


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
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
