        using System;
        using System.Collections.Generic;
                            using System.IO;
                            using System.Linq;
                            using System.Threading.Tasks;
                            using Microsoft.AspNetCore.Hosting;
                            using Microsoft.AspNetCore.Http;
        using Microsoft.AspNetCore.Identity;
        using Microsoft.AspNetCore.Mvc;
                            using Microsoft.Extensions.FileProviders;
    using Microsoft.Extensions.Logging;
    using SixLabors.ImageSharp;
                            using SixLabors.ImageSharp.Processing;
        using TTU_CORE_ASP_ADMISSION_PORTAL.Data;
        using TTU_CORE_ASP_ADMISSION_PORTAL.Models;
                            using TTU_CORE_ASP_ADMISSION_PORTAL.Services;

        namespace TTU_CORE_ASP_ADMISSION_PORTAL.Controllers
        {
            [Microsoft.AspNetCore.Authorization.Authorize]
            public class UploadController : Controller
            {
            private readonly ILogger<UploadController> _logger;
            private string serverUrl = "https://photos.ttuportal.com/public/albums/thumbnails";
                private readonly IHostingEnvironment hostingEnvironment;
                private UserManager<ApplicationUser> _userManager;
                private readonly ApplicationDbContext _dbContext;
                public UploadController(ILogger<UploadController> logger, IHostingEnvironment environment, UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext)
                {
                   _logger = logger;
                    hostingEnvironment = environment;
                    _userManager = userManager;
                    _dbContext = dbContext;
                }

                public IActionResult Index()
                {
                    return View();
                }

                [HttpPost]
                public async Task<IActionResult> UploadAsync(IFormFile file)
                {

                    if (Request.Form.Files.Count > 0)
                    {
                

                        ApplicationUser applicationUser = await _userManager.GetUserAsync(User);

                        var applicationNo = applicationUser?.FormNo;

                        var fileName = file.FileName;

                        var uploads = Path.Combine(hostingEnvironment.WebRootPath, "pictures");
                

                        var extension = Path.GetExtension(fileName).ToLower();

               

                        var PictureToSave = applicationNo  + extension;

                        var filePath = Path.Combine(uploads, PictureToSave);

                        if (IMageService.IsImage(file))
                        {
                            if (file.Length <= 250000)
                            {

                                using var image = Image.Load(file.OpenReadStream());
                                image.Mutate(x => x.Resize(413, 531));

                                // image.Save(file.FileName);
                                //image.Save(filePath);
                                try
                                {
                            //IMageService.ExifRotate(image);
                                    //image.Save(serverUrl);
                                    image.Save(filePath);
                             

                                        // lets update the user login table to show that he has uploaded the pic

                               

                                        var user = await _userManager.GetUserAsync(User);


                                         user.PictureUploaded = 1;

                                        await _dbContext.SaveChangesAsync();
                            

                                }
                                catch (Exception exp)
                                {
                                    System.Console.WriteLine("Exception generated when uploading file - " + exp.Message);

                                    return Ok("Error reaching picture server.");
                                }

                         
                                TempData["message"] = "Picture uploaded successfully!!";
                                TempData["type"] = "success";
                                return RedirectToAction("Index");
                       

                            }
                            else
                            {
 
                                TempData["message"] = "File size too big. Upload only file of size less than 251KB.";
                                TempData["type"] = "error";
                                return RedirectToAction("Index");

                            }


                        }
                        else
                        {
 

                            TempData["message"] = "Upload only JPEG image.";
                            TempData["type"] = "error";
                            return RedirectToAction("Index");
                        }


                    }
                    else
                    {
                

                        TempData["message"] = "No file uploaded.";
                        TempData["type"] = "error";

                        return RedirectToAction("Index");

                    }


                }


                //public IActionResult ProcessForm()
                //{
                //    // ... process form ...
                //    Response.Cookies.Add(new HttpCookie("FlashMessage", "Data processed") { Path = "/" }));
                //    return RedirectToAction("Index");
                //}






            }
        }
