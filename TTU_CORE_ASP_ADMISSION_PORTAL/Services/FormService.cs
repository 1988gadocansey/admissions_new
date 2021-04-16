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
    using System.Collections.Generic;
    using System.Linq;
        using System.Threading.Tasks;
        using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
        using TTU_CORE_ASP_ADMISSION_PORTAL.Data;
    using TTU_CORE_ASP_ADMISSION_PORTAL.Models;
using Microsoft.AspNetCore.Identity;
namespace TTU_CORE_ASP_ADMISSION_PORTAL.Services
        {
            public  class FormService
            {
                private readonly ApplicationDbContext _dbContext;


            public FormService(ApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

                public  string GetFormNo()
                {
                //List<Customer> customers = new List<Customer>();
                //customers = await _context.Customers.AsNoTracking()
                //    .Include(x => x.Country)
                //    .Include(x => x.Region)
                //    .ToListAsync();


                    var Year = (DateTime.Now.Year).ToString();

              var formNumber = _dbContext.FormNoModel.Where(n => n.Year == Year).First();






                return formNumber.No.ToString();
                //return Ok(FormNumber.No);

            }

            public  async Task<int> UpdateFormNoAsync()
            {



                var Year = (DateTime.Now.Year).ToString();
                var update = _dbContext.FormNoModel.Where(n => n.Year == Year).First();
                    update.No = update.No + 1;
                return await _dbContext.SaveChangesAsync();






            }
        //public  IEnumerable<SelectListItem> GetProgrammes(string FormType)
        //{


        //    IEnumerable<SelectListItem> programs =  _dbContext.ProgrammeModel.AsNoTracking()
        //        .OrderBy(n => n.Name)
        //        .Where(n => n.Type ==FormType)
        //        .Select(n =>
        //            new SelectListItem
        //            {
        //                Value = n.Id.ToString(),
        //                Text = n.Name
        //            }).ToList();
        //    return new SelectList(programs, "Id", "Name");


        //}

        //public  IEnumerable<SelectListItem> GetSchools()
        //{


        //    IEnumerable<SelectListItem> schools =   _dbContext.SchoolModel.AsNoTracking()
        //        .OrderBy(n => n.Name)

        //        .Select(n =>
        //            new SelectListItem
        //            {
        //                Value = n.Id.ToString(),
        //                Text = n.Name
        //            }).ToList();
        //    return new SelectList(schools, "Id", "Name");


        //}
        public IEnumerable<SelectListItem> GetProgrammes(string FormType)
        {
            List<SelectListItem> programme = _dbContext.ProgrammeModel.AsNoTracking()
                 .OrderBy(n => n.Name)
                 .Where(n => n.Type== FormType)
                  .Select(n =>
                    new SelectListItem
                    {
                        Value = n.Id.ToString(),
                        Text = n.Name
                    }).ToList();

            return new SelectList(programme, "Value", "Text");
        }
        public IEnumerable<SelectListItem> GetSchools()
        {
            List<SelectListItem> schools = _dbContext.SchoolModel.AsNoTracking()
                 .OrderBy(n => n.Name)
                
                  .Select(n =>
                    new SelectListItem
                    {
                        Value = n.Id.ToString(),
                        Text = n.Name
                    }).ToList();

            return new SelectList(schools, "Value", "Text");
    }
        public string GetProgrammeName(int id )
            {
                 
                var programme = _dbContext.ProgrammeModel.Where(p => p.Id == id).First();

                return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(programme.Name);
            }
            public object GetRegions()
            {
               return new SelectList(_dbContext.RegionModel, "Id", "Name");
            }
            public object GetReligions()
            {
                return new SelectList(_dbContext.ReligionModel, "Id", "Name");
            }

        //public object GetProgrammes()
        //{
        //    return new SelectList(_dbContext.ProgrammeModel, "Id", "Name");
        //}

        public object GetDistrict()
            {
                return new SelectList(_dbContext.DistrictModel, "ID", "Name");
            }

        //public object GetSchools()
        //{
        //    return new SelectList(_dbContext.SchoolModel,"Id", "Name");
        //}

        public object GetDenominations()
            {
                return new SelectList(_dbContext.DenominationModel, "ID", "Name");
            }

            public object GetSHSProgrammes()
            {
                return new SelectList(_dbContext.SHSProgrammes, "Name", "Name");
            }

            public object GetCountry()
            {
                return new SelectList(_dbContext.CountryModel, "ID", "Name");
            }
        public object GetGrades()
        {
            return new SelectList(_dbContext.GradeModel, "Id", "Name");
        }
        public object GetExamTypes()
        {
            return new SelectList(_dbContext.ExamModel, "Name", "Name");
        }

        public object GetSubjects()
        {
            return new SelectList(_dbContext.SubjectModel, "Id", "Name");
        }
        public object GetYears()
        {
            //var currentYear = DateTime.Today.Year;
            //for (int i = 2; i >= 0; i--)
            //{
            //    // Now just add an entry that's the current year minus the counter
            //    DropDownList2.Items.Add((currentYear - i).ToString());
            //}
            var years= Enumerable.Range(DateTime.Now.Year - 25, ((DateTime.Now.Year)-1996));
            return years;
        }

        public object GetHalls()
        {
            return new SelectList(_dbContext.HallModel, "Id", "Name");
        }




        public string GetAdmissionYear()
            {
                 return DateTime.Now.Year + "/" + DateTime.Now.AddYears(+1).Year;
            }

            public  Int32 GetAge(DateTime dateOfBirth)
            {
                var today = DateTime.Today;

                var a = (today.Year * 100 + today.Month) * 100 + today.Day;
                var b = (dateOfBirth.Year * 100 + dateOfBirth.Month) * 100 + dateOfBirth.Day;

                return (a - b) / 10000;
            }

        public bool QualifiesMature(int age)
            {
            return (age>=25);
            }

        // count the number of failed courses
        public int checkFailed(int[] GradeValues)
        {
            int fail = 0;
             
            foreach (int values in GradeValues)
            {

                if (values > 7)
                {

                     fail++;
                }


            }
            return fail;

        }

        // count the number of passed courses

        public int checkPassed(int[] GradeValues)
        {
            int passed = 0;

            foreach (int values in GradeValues)
            {

                if (values <= 7)
                {

                    passed++;
                }


            }
            return passed;

        }
        
        public string[] GradesIssues(int[] Cores, int[] CoreAlt, int[] Electives)
        {
            var error= new  string[4];
             

            if (Cores.Count() + CoreAlt.Count() + Electives.Count() != 6)
            {
               var msg = "Results not completed.";
                Array.Fill(error,msg);


            }
            else if( Cores.Count()<2)
            {

                var msg = "Minimum of two(2) core subjects not met.";
                Array.Fill(error, msg);
            }
            else if (Electives.Count() <3)
            {
                var msg = "Minimum of three(3) elective subjects not met.";

                Array.Fill(error, msg);
            }
            else if (CoreAlt.Count() < 1)
            {
                var msg = "Social or Science required.";

                Array.Fill(error, msg);
            }
            else
            {
                string msg = null;

                Array.Fill(error, msg);
            }

            return error;



        }
        public int GetTotalAggregate(int[] Cores, int[] CoreAlt, int[] Electives)
        {
            Array.Sort(CoreAlt);

                Array.Sort(Cores);

                Array.Sort(Electives);

                int CstartIndex = 0;
                int Clenght = 1;
                IEnumerable<int> SliceCoreAlt = CoreAlt.Skip(CstartIndex).Take(Clenght);


                int EstartIndex = 0;
                int Elenght = 3;
                IEnumerable<int> SliceElect = Electives.Skip(EstartIndex).Take(Elenght);


            int grade = Cores.Sum() + SliceElect.Sum() + SliceCoreAlt.Sum();



            return grade;
             


        }
             

        
        private bool ApplicantModelExists(int id)
        {
            return _dbContext.ApplicantModel.Any(e => e.ID == id);
        }

    }
        }