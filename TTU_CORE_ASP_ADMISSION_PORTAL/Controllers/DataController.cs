using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TTU_CORE_ASP_ADMISSION_PORTAL.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TTU_CORE_ASP_ADMISSION_PORTAL.Controllers
{
    [Route("api/[controller]")]
    public class DataController : Controller
    {
        // GET: api/values
        private readonly ApplicationDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DataController(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {

            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;

        }
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/Get/Form
        [HttpGet("{Form:int}")]
        public IActionResult Get(int Form)
        {



            // check if form is valid
            if (Form != 0)
            {



                try
                {
                    //var applicant = await _dbContext.ApplicantModel.FirstOrDefaultAsync(a => a.ApplicationUserId == ApplicantId);
                    string[] LegacyYears = { "2017", "2018", "2019", "2020" };
                    
                    if (Array.Find(LegacyYears, element => element == Form.ToString().Substring(0, 4)) != null)
                       
                    {
                         
                        var applicanta = _dbContext.ApplicantModel.Include(r => r.Region)
                          .Include(p => p.Programmes)
                          


                          .FirstOrDefault(a => a.ApplicationNumber == Form);

                        ViewData["applicant"] = applicanta;

                        Console.WriteLine("firstname is " + applicanta.FirstName);

                        
                        
                            var ResultsOld = _dbContext.ResultUploadModel
                           .Include(s => s.Subject)

                           .Where(r => r.Form == applicanta.ApplicationNumber.ToString()||  r.Applicant == applicanta.ID);

                        ViewData["results"] = ResultsOld;
                        return View("legacy");

                    }
                    else
                    {
                        var applicant = _dbContext.ApplicantModel.Include(r => r.Region).Include(n => n.Nationality)
                   .Include(p => p.Programmes)
                   .Include(a => a.ApplicationUser)
                    .Include(h => h.Hall)
                    .Include(rel => rel.Religion)
                     .Include(s => s.FormerSchoolNew)
                      .Include(r => r.ResultUploads)
                     .Include(d => d.District)

                   .FirstOrDefault(a => a.ApplicationNumber == Form);
                        ViewData["applicant"] = applicant;
                            var results = _dbContext.ResultUploadModel.Include(g => g.Grade)
                                   .Include(s => s.Subject).Where(r => r.ApplicantModelID == applicant.ID).OrderBy(s => s.Year);
                            ViewData["results"] = results;
                            return View("form");
                    }
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        "Error retrieving data from the database");
                }
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
