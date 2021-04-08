﻿//
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

            ViewData["programme"] = _formService.GetSHSProgrammes();

            ViewData["denominations"] = _formService.GetDenominations();

            ViewData["districts"] = _formService.GetDistrict();

            ViewData["school"] = _formService.GetSchools();
            ViewData["hall"] = _formService.GetHalls();


            if (applicationUser.Started == 1)
            {
                var applicantModel = await _dbContext.ApplicantModel.FirstOrDefaultAsync(a => a.ApplicationUserId == ApplicantId);
                ViewData["applicant"] = applicantModel;
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CreateAsync()
        {
            _logger.LogInformation("User created result.");
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

            ViewData["programme"] = _formService.GetSHSProgrammes();

            ViewData["denominations"] = _formService.GetDenominations();

            ViewData["districts"] = _formService.GetDistrict();

            ViewData["school"] = _formService.GetSchools();
            ViewData["hall"] = _formService.GetHalls();


            if (applicationUser.Started == 1)
            {
                var applicantModel = await _dbContext.ApplicantModel.FirstOrDefaultAsync(a => a.ApplicationUserId == ApplicantId);
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

            return View();
        }

        }
    }
