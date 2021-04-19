    //
    //  Copyright 2021  2021
    //
    //    Licensed under the Apache License, Version 2.0 (the "License");
    //    you may not use this file except in compliance with the License.
    //    You may obtain a copy of the License at
    //
    //        http://www.apache.org/licenses/LICENSE-2.0
    //
    //    Unless required by applicable law or agreed to in writing, software
    //    distributed under the License is distributed on an "AS IS" BASIS,
    //    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
    //    See the License for the specific language governing permissions and
    //    limitations under the License.
    using System;
using System.Linq;
using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
    using TTU_CORE_ASP_ADMISSION_PORTAL.Data;
    using TTU_CORE_ASP_ADMISSION_PORTAL.Models;
    using TTU_CORE_ASP_ADMISSION_PORTAL.Services;

    namespace TTU_CORE_ASP_ADMISSION_PORTAL.Controllers
    {
        [Microsoft.AspNetCore.Authorization.Authorize]
        public class PreviewController : Controller
    {
            private readonly ILogger<PreviewController> _logger;
            private readonly SMSService sms;

            private readonly ApplicationDbContext _dbContext;

            private readonly IHttpContextAccessor _httpContextAccessor;
            private UserManager<ApplicationUser> _userManager;

            public PreviewController(ILogger<PreviewController> logger, UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
            {
                _logger = logger;
                _userManager = userManager;
                _dbContext = dbContext;
                _httpContextAccessor = httpContextAccessor;
            }


            [HttpGet]
            public async Task<IActionResult> IndexAsync()
            {
                _logger.LogInformation("User visted perview page.");
                FormService _formService = new FormService(_dbContext);

                var ApplicantId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
                var ApplicantName = User.FindFirstValue(ClaimTypes.Name); // will give the user's userName

                ApplicationUser applicationUser = await _userManager.GetUserAsync(User);

                var ApplicantForm = applicationUser?.FormNo;

                var FormFinalized = applicationUser?.Finalized;

                var ApplicantPin = applicationUser?.Pin;
                var ApplicantFormType = applicationUser?.Type;

            // check if the user completed the form send him sms
                if (applicationUser.FormCompleted==1)
                {

                }



            //var applicant = await _dbContext.ApplicantModel.FirstOrDefaultAsync(a => a.ApplicationUserId == ApplicantId);
            var applicant = await _dbContext.ApplicantModel.Include(r=>r.Region).Include(n =>n.Nationality)
                .Include(p =>p.Programmes)
                 .Include(h => h.Hall)
                 .Include(rel => rel.Religion)
                  .Include(s => s.FormerSchoolNew)
                   .Include(r => r.ResultUploads)
                  .Include(d => d.District)


                .FirstOrDefaultAsync(a => a.ApplicationUserId == ApplicantId);

            //Console.WriteLine(applicant.Region.Name);
            ViewData["applicant"] = applicant;

            var results =  _dbContext.ResultUploadModel.Include(g => g.Grade)
               .Include(s => s.Subject).Where(r => r.ApplicantModelID == applicant.ID).OrderBy(s => s.Year);



            ViewData["results"] = results;

            return View();

            }



            }
        }
