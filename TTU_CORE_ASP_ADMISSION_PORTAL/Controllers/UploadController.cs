using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TTU_CORE_ASP_ADMISSION_PORTAL.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class UploadController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
    //[HttpPost]
    
    //[ValidateAntiForgeryToken]
    //public async Task<ActionResult> Register([Bind(Exclude = "UserPhoto")] RegisterViewModel model)
    //{
    //    if (ModelState.IsValid)
    //    {

    //        // To convert the user uploaded Photo as Byte Array before save to DB    
    //        byte[] imageData = null;
    //        if (Request.Files.Count > 0)
    //        {
    //            HttpPostedFileBase poImgFile = Request.Files["UserPhoto"];

    //            using (var binary = new BinaryReader(poImgFile.InputStream))
    //            {
    //                imageData = binary.ReadBytes(poImgFile.ContentLength);
    //            }
    //        }


    //        var user = new ApplicationUser { UserName = model.Email, Email = model.Email };

    //        //Here we pass the byte array to user context to store in db    
    //        user.UserPhoto = imageData;

    //        var result = await UserManager.CreateAsync(user, model.Password);
    //        if (result.Succeeded)
    //        {
    //            await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

    //            // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771    
    //            // Send an email with this link    
    //            // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);    
    //            // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);    
    //            // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");    

    //            return RedirectToAction("Index", "Home");
    //        }
    //        AddErrors(result);
    //    }

    //    // If we got this far, something failed, redisplay form    
    //    return View(model);
    //}
}
