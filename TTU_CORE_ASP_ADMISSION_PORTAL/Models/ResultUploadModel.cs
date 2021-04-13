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
using System.ComponentModel.DataAnnotations;

namespace TTU_CORE_ASP_ADMISSION_PORTAL.Models
{
    public class ResultUploadModel:BaseEntity
    {
        [Key]
        public int Id { set; get; }
        public int Applicant { set; get; }
        //public int Subject { set; get; }
        public string ExamType { set; get; }
        //public int Grade { set; get; }
        public int GradeOld { set; get; }
        public string GradeValueOld { set; get; }
        public string IndexNo { set; get; }
        public string Sitting { set; get; }
        public string Month { set; get; }
        public string Form { set; get; }
        public string Center { set; get; }
        public string Year { set; get; }
        public string OldSubject { set; get; }
        public string InstitutionName { set; get; }
        public int ApplicantModelID { set; get; }

        public virtual SubjectModel Subject { get; set; }

        public virtual GradeModel Grade  { get; set; }


        public ResultUploadModel()
        {
        }
    }
}
