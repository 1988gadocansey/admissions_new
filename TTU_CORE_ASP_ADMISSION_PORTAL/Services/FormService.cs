﻿        //
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
            public async Task<IEnumerable<SelectListItem>> GetRegions()
            {


                    IEnumerable<SelectListItem> regions = await _dbContext.RegionModel.AsNoTracking()
                        .OrderBy(n => n.Name)
                        .Where(n => n.Id >0)
                        .Select(n =>
                            new SelectListItem
                            {
                                Value = n.Id.ToString(),
                                Text = n.Name
                            }).ToListAsync();
                    return new SelectList(regions, "Value", "Text");


            }
        }
        }