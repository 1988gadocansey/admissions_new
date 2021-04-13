using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TTU_CORE_ASP_ADMISSION_PORTAL.Controllers
{
    public class WorkExperienceController : Controller
    {
        // GET: WorkExperience
        public ActionResult Index()
        {
            return View();
        }

        // GET: WorkExperience/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WorkExperience/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkExperience/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WorkExperience/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WorkExperience/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WorkExperience/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WorkExperience/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}