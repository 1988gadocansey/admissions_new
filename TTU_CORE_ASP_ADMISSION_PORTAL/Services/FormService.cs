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
            //public async Task<IEnumerable<SelectListItem>> GetRegions()
            //{


            //        IEnumerable<SelectListItem> regions = await _dbContext.RegionModel.AsNoTracking()
            //            .OrderBy(n => n.Name)
            //            .Where(n => n.Id >0)
            //            .Select(n =>
            //                new SelectListItem
            //                {
            //                    Value = n.Id.ToString(),
            //                    Text = n.Name
            //                }).ToListAsync();
            //        return new SelectList(regions, "Value", "Text");


            //}
            public object GetRegions()
            {
               return new SelectList(_dbContext.RegionModel, "Id", "Name");
            }
            public object GetReligions()
            {
                return new SelectList(_dbContext.ReligionModel, "Id", "Name");
            }

            public object GetProgrammes()
            {
                return new SelectList(_dbContext.ProgrammeModel, "Id", "Name");
            }

        public object GetDistrict()
            {
                return new SelectList(_dbContext.DistrictModel, "ID", "Name");
            }

            public object GetSchools()
            {
                return new SelectList(_dbContext.SchoolModel, "Id", "Name");
            }

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
    }
        }