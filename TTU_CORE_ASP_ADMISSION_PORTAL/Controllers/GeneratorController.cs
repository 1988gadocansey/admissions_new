    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using TTU_CORE_ASP_ADMISSION_PORTAL.Data;
    using TTU_CORE_ASP_ADMISSION_PORTAL.Models;

    // For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

    namespace TTU_CORE_ASP_ADMISSION_PORTAL.Controllers
    {
        public class GeneratorController : Controller
        {
            // GET: /<controller>/
            public readonly IPasswordHasher<ApplicationUser> _passwordHasher;
            private readonly ILogger<GeneratorController> _logger;

            private readonly ApplicationDbContext _dbContext;
            private UserManager<ApplicationUser> _userManager;

            public GeneratorController(ILogger<GeneratorController> logger, IPasswordHasher<ApplicationUser> passwordHasher, UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext)
            {
                _passwordHasher = passwordHasher;
                _logger = logger;
                _userManager = userManager;
                _dbContext = dbContext;
            }
        [HttpGet]
        public async Task<IActionResult> IndexAsync(int? quantity, string? type, string? owner)
        {
          //  Console.Write("hello");
          //  Console.WriteLine(quantity);

            for (int a = 0; a < quantity; a++)
            {


               var Pin = GetPin();
                var Serial = GetSerial();

         


               ApplicationUser user = new();
               ApplicationUser applicationUser = new();
               Guid guid = Guid.NewGuid();
               applicationUser.Id = guid.ToString();
               applicationUser.UserName = Serial;
               applicationUser.Email = Serial+"@ttu.edu.gh";
               applicationUser.NormalizedUserName = Serial;
               applicationUser.Year = (DateTime.Now.Year).ToString();
               applicationUser.Pin = Pin;
               applicationUser.SoldBy = owner.ToUpper();
               applicationUser.Sold = 0;
               applicationUser.Started = 0;
               applicationUser.Type = type.ToUpper();
               applicationUser.EmailConfirmed = true;
               applicationUser.NormalizedEmail = Serial + "@ttu.edu.gh";

               var hasedPassword = _passwordHasher.HashPassword(applicationUser, Pin);
               applicationUser.SecurityStamp = Guid.NewGuid().ToString();
               applicationUser.PasswordHash = hasedPassword;

               IdentityResult result = _userManager.CreateAsync
                   (applicationUser).Result;

                   if (result.Succeeded)
                   {
                    
                   }
                


           }
          await  _dbContext.SaveChangesAsync();

            return Ok("FCK OFF!!!");

        }
            static string GetPin()
            {
                var  str = "59234678ABCDEFGHJKLMNPRSTUVWXY";

                var shuffled = Shuffle(str);

                var vcode = shuffled.Substring(0, 9);

                var real = vcode.ToUpper();

            return real;
            }
            static string GetSerial()
            {
                var str = "ABCDEFGHJKLMNPRSTUVWXYZ23456789";

                var shuffled = Shuffle(str);
                var vcode = shuffled.Substring(0, 5);

                var real = vcode.ToUpper();

                return "TTU"+(DateTime.Now.Year).ToString()+ real;


            }

            static string Shuffle(string str)
            {
            //List<char> list1 = new List<char>(array);

            //var rnd = new Random();
            //var randomized = array.ToCharArray().OrderBy(item => rnd.Next());

            //return randomized.ToString();

            // The source string
             var original = str;

            // The random number sequence
            Random num = new Random();

            // Create new string from the reordered char array
            string rand = new string(original.ToCharArray().
                OrderBy(s => (num.Next(2) % 2) == 0).ToArray());

             return rand;
        }
        }
    }
