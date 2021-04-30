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
using System.ComponentModel.DataAnnotations;

namespace TTU_CORE_ASP_ADMISSION_PORTAL.Models
{
    public class ConfigurationModel
    {
        [Key]
        public int Id { set; get; }
        public string Year { set; get; }
        [DataType(DataType.Date)]
        public DateTime OrientationStarts { get; set; }

        [DataType(DataType.Date)]
        public DateTime OrientationEnds { get; set; }

        [DataType(DataType.Date)]
        public DateTime Matriculation { get; set; }

        [DataType(DataType.Date)]
        public DateTime Reporting { get; set; }


        [DataType(DataType.Date)]
        public DateTime FeesDeadline { get; set; }

        [DataType(DataType.Date)]
        public DateTime MedicalStarts { get; set; }

        [DataType(DataType.Date)]
        public DateTime MedicalEnds { get; set; }

        public string AdmissionsOfficer { set; get; }
        public ConfigurationModel()
        {
        }
    }
}
