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
    using System.Collections;
using System.Collections.Generic;
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
    namespace TTU_CORE_ASP_ADMISSION_PORTAL.Controllers
    {
        [Microsoft.AspNetCore.Authorization.Authorize]
        public class ResultController : Controller
        {
            private readonly ILogger<ResultController> _logger;
            private readonly SMSService sms;

            private readonly ApplicationDbContext _dbContext;

            private readonly IHttpContextAccessor _httpContextAccessor;
            private UserManager<ApplicationUser> _userManager;

            public ResultController(ILogger<ResultController> logger, UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
            {
                _logger = logger;
                _userManager = userManager;
                _dbContext = dbContext;
                _httpContextAccessor = httpContextAccessor;
            }

            [HttpGet]
            public async Task<IActionResult> IndexAsync()
            {
                _logger.LogInformation("User viewed results.");
                FormService _formService = new FormService(_dbContext);
                var ApplicantId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
                var ApplicantName = User.FindFirstValue(ClaimTypes.Name); // will give the user's userName

                ApplicationUser applicationUser = await _userManager.GetUserAsync(User);

             

                var FormFinalized = applicationUser?.Finalized;

            

                if (FormFinalized == 1)
                {
                    return RedirectToAction("Index", "Preview");

                }


                ViewData["years"] = _formService.GetYears();

                ViewData["subjects"] = _formService.GetSubjects();
                ViewData["grades"] = _formService.GetGrades();

                ViewData["types"] = _formService.GetExamTypes();

           
                return View();
            }
        

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> SaveAysnc(List<ResultUploadModel> mrptranList)
            {
    //        Character character = await _context.Characters
    //.FirstOrDefaultAsync(c => c.Id == newWeapon.CharacterId &&
    //c.User.Id == int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)));

            FormService _formService = new FormService(_dbContext);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId


            ApplicationUser applicationUser = await _userManager.GetUserAsync(User);

            //int years = Convert.ToInt32(HttpContext.Request.Form["year"]);

            // array to hold form inputs
            Console.WriteLine("center is" + HttpContext.Request.Form["center"]);
             
            var results = new ArrayList();

            var ApplicantForm = applicationUser?.FormNo;

            var applicant = await _dbContext.ApplicantModel.FirstOrDefaultAsync(n => n.ApplicationNumber == Convert.ToInt32(ApplicantForm));

            string[] year = HttpContext.Request.Form["items[year]"];

            string[] month = HttpContext.Request.Form["items[month]"];

            string[] grade = HttpContext.Request.Form["items[grade]"];

            string[] subject = HttpContext.Request.Form["items[subject]"];

            string[] sitting = HttpContext.Request.Form["items[sitting]"];

            string[] indexno = HttpContext.Request.Form["items[indexno]"];

            string[] center = HttpContext.Request.Form["items[center]"];

            string[] type = HttpContext.Request.Form["items[type]"];

            // total no of items in the submitted form
            
            results.Add(year);
            results.Add(month);
            results.Add(grade);
            results.Add(subject);
            results.Add(sitting);
            results.Add(indexno);
            results.Add(center);
            results.Add(type);

            var total = results.Count;
            

            
                if (applicant.FirstQualification== "WASSSCE" || applicant.FirstQualification == "SSSCE") {
                            for(int i=0; i <type.Length;i++)
                            {

                        
                            

                                await _dbContext.ResultUploadModel.AddRangeAsync(
                                      new ResultUploadModel
                                      {
                                         
                                          Applicant = applicant.ID,
                                          Subject = Convert.ToInt32(subject[i]),
                                          ApplicantModelID =applicant.ID,
                                          Sitting= sitting[i],
                                          ExamType= Convert.ToInt32(type[i]),
                                          Center= center[i].ToString(),
                                          IndexNo= indexno[i].ToString(),
                                          Month= month[i].ToString(),
                                          GradeOld =1,
                                          Grade = Convert.ToInt32(grade[i])
                                      });

                    
                    await _dbContext.SaveChangesAsync();
                        Console.WriteLine("month is " + month[i]);
                     
                            }
                          
                }
                else
                {

                }

                    return RedirectToAction("Index");
           // ViewBag["Model"]= await _dbContext.ResultUploadModel.FirstOrDefaultAsync();
           // Console.WriteLine(mrptranList);
           // Console.WriteLine(ViewBag["Model"]);
           // await _dbContext.ResultUploadModel.AddRangeAsync(mrptranList);
           //await _dbContext.SaveChangesAsync();

            

        }

            }
        }
