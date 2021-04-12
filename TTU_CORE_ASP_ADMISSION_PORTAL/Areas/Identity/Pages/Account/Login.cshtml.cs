using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TTU_CORE_ASP_ADMISSION_PORTAL.Models;
using System.Security.Claims;
using TTU_CORE_ASP_ADMISSION_PORTAL.Data;

namespace TTU_CORE_ASP_ADMISSION_PORTAL.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly ApplicationDbContext _dbContext;
        public LoginModel(SignInManager<ApplicationUser> signInManager, 
            ILogger<LoginModel> logger,
            UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _dbContext = dbContext;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            //[Required]
            //[EmailAddress]
            //public string Email { get; set; }
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Serial No")]
            public string UserName { get; set; }


            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Pin Code")]
            public string Password { get; set; }

            //[Required]
            //[DataType(DataType.Password)]
            //[Display(Name = "Pin Code")]
            //public string Pin { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(Input.UserName, Input.Password, Input.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {



                    //ApplicationDbContext db = new ApplicationDbContext();
                    //UserProfileInfo logged = db.UserProfileInfo.SingleOrDefault();
                    //Session["lastLoggedTime"] = logged.Logged;
                    //logged.Logged = DateTime.Now;
                    //db.Entry(logged).State = EntityState.Modified;
                    //db.SaveChanges();

                    //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
                    //var auth = _dbContext.Users.Where(n => n.Id == userId).First();
                    //auth.LastLogin = DateTimeOffset.UtcNow;
                    //_ = _dbContext.SaveChanges();

                    //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                    //ApplicationUser applicationUser = _dbContext.Users.SingleOrDefault();
                    //Session["lastLoggedTime"] = applicationUser.LastLogin;
                    //applicationUser.LastLogin= DateTimeOffset.UtcNow;
                    //await _dbContext.SaveChangesAsync();

                   
                    
                        var user = await _dbContext.Users.FindAsync(Input.Password);
                        if (user != null)
                        {
                            user.LastLogin = DateTimeOffset.UtcNow;
                            await _dbContext.SaveChangesAsync();
                        }
                        else {
                            _logger.LogInformation("Error retrieving user context.");
                        }
 


                        _logger.LogInformation("User logged in.");
                    return LocalRedirect(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Pin or Serial. Try again.");
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
