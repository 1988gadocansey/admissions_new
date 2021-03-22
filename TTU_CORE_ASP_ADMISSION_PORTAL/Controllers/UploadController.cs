                    using System;
                    using System.Collections.Generic;
                    using System.IO;
                    using System.Linq;
                    using System.Threading.Tasks;
                    using Microsoft.AspNetCore.Hosting;
                    using Microsoft.AspNetCore.Http;
                    using Microsoft.AspNetCore.Mvc;
                    using Microsoft.Extensions.FileProviders;
                    using SixLabors.ImageSharp;
                    using SixLabors.ImageSharp.Processing;
                    using TTU_CORE_ASP_ADMISSION_PORTAL.Models;
                    using TTU_CORE_ASP_ADMISSION_PORTAL.Services;

namespace TTU_CORE_ASP_ADMISSION_PORTAL.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class UploadController : Controller
    {
        // GET: /<controller>/
        private string serverUrl = "https://photos.ttuportal.com/public/albums/thumbnails";
        private readonly IHostingEnvironment hostingEnvironment;
        public UploadController(IHostingEnvironment environment)
        {
            hostingEnvironment = environment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Upload(IFormFile file)
        {

            if (Request.Form.Files.Count > 0)
            {

                string fileName = file.FileName;

                string uploads = Path.Combine(hostingEnvironment.WebRootPath, "pictures");
                string filePath = Path.Combine(uploads, fileName);

                if (IMageService.IsImage(file))
                {
                    if (file.Length <= 2500000)
                    {

                        using var image = Image.Load(file.OpenReadStream());
                        image.Mutate(x => x.Resize(256, 256));

                        // image.Save(file.FileName);
                        //image.Save(filePath);
                        try
                        {
                            //image.Save(serverUrl);
                            image.Save(filePath);

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
