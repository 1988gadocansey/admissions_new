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
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
namespace TTU_CORE_ASP_ADMISSION_PORTAL.Models
{
    public class ApplicationUser:IdentityUser
    {



       //Extended Properties
        public string FormNo { get; set; }
        public int Started { get; set; }
        public string FullName { get; set; }
        public string Type { get; set; }
        public int Sold { set; get; }
        public string SoldBy { set; get; }
        public string Branch { set; get; }
        public string Teller { set; get; }
        public string TellerPhone { set; get; }
        public int FormCompleted { set; get; }
        public int PictureUploaded { set; get; }
        public int Finalized { set; get; }
        public string Year { get; set; }
        public string Pin { get; set; }
        //public byte[] ProfilePicture { get; set; }




        public ApplicationUser()
        {
        }
    }
}
