using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using TTU_CORE_ASP_ADMISSION_PORTAL.Data;
using TTU_CORE_ASP_ADMISSION_PORTAL.Models;
using TTU_CORE_ASP_ADMISSION_PORTAL.Services;
using Renci.SshNet;
using ConnectionInfo = Renci.SshNet.ConnectionInfo;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace TTU_CORE_ASP_ADMISSION_PORTAL.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
                    public class UploadController : Controller
                    {
                    private readonly ILogger<UploadController> _logger;
                    private string serverUrl = "https://photos.ttuportal.com/public/albums/thumbnails";
        private readonly IConfiguration Configuration;
 
        private readonly IWebHostEnvironment hostingEnvironment;

                        private UserManager<ApplicationUser> _userManager;
                        private readonly ApplicationDbContext _dbContext;
                         private readonly IHelper _helper;
        

        
        public UploadController(ILogger<UploadController> logger, IWebHostEnvironment environment, UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext,IHelper helper, IConfiguration configuration)
                        {
                           _logger = logger;
                            hostingEnvironment = environment;
                            _userManager = userManager;
                            _dbContext = dbContext;
                             _helper = helper;
            Configuration = configuration;
        }

                        public IActionResult Index()
                        {
                            return View();
                        }

         
        [HttpPost]
        [Obsolete]
        public async Task<IActionResult> UploadAsync(IFormFile file)
                        {

                            if (Request.Form.Files.Count > 0)
                            {
                

                                ApplicationUser applicationUser = await _userManager.GetUserAsync(User);

                                var applicationNo = applicationUser?.FormNo;

                                var fileName = file.FileName;

                               var uploads = Path.Combine(hostingEnvironment.WebRootPath, "pictures");
                
                                 //var uploads= Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            
                             var extension = Path.GetExtension(fileName).ToLower();

               

                                var PictureToSave = applicationNo  + extension;

                                var filePath = Path.Combine(uploads, PictureToSave);

                                if (IMageService.IsImage(file))
                                {
                                    if (file.Length <= 250000)
                                    {

                                        using var image = Image.Load(file.OpenReadStream());

                                        image.Mutate(img => img.AutoOrient());
                                        image.Mutate(x => x.Resize(192, 192));
                        //image.Mutate(x => x.Crop(189, 189));

                        try
                        {

                            /**
                             * Call the image background service from the ttuportal.com/api/image/check to help test
                             **/

                            Console.WriteLine(filePath);
                                            image.Save(filePath);

                            int port = Convert.ToInt32(Configuration["sftpport"]);
                            string host = Configuration["sftphost"];
                            string username = Configuration["sftpusername"];
                            string password = Configuration["sftppassword"];

                            if (_helper.SendFileToServer(host, port, username, password, filePath) == 1)
                            {
                                var fileInfo = new FileInfo(filePath);
                                fileInfo.Delete();
                            }
                            else
                            {
                                TempData["message"] = "Photo Server down!!.. check later";
                                TempData["type"] = "error";
                                return RedirectToAction("Index");
                            }
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
