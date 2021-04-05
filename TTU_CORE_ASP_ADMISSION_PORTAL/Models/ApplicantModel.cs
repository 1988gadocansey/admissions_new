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
    public class ApplicantModel:BaseEntity
    {
        [Key]
        public int ID { set; get; }
        public int ApplicationNumber { set; get; }
        [Required]
        public string Title { set; get; }
        [Required]
        [Display(Name = "First Name")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string FirstName { set; get; }

         

        public string MiddleName { set; get; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        
        public string LastName { set; get; }

        

        public string PreviousName { set; get; }

        [Required]
        [DataType(DataType.Date)]
       
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Gender { get; set; }

        public string Age { get; set; }

        [Required]
        public string MaritalStatus { get; set; }

        [Required]
        public string Phone { get; set; }

        public string AltPhone { get; set; }
        [Required]
        public string Email { get; set; }
        public string Address { get; set; }
        public string PostGPRS { get; set; }
        public string EmergencyContact { get; set; }
        public string Hometown { get; set; }

        public int DistrictId { get; set; }
        public virtual DistrictModel District { get; set; }

        public virtual HallModel Hall { get; set; }



        public string NationalIDType { get; set; }
        public string NationalIDNo { get; set; }

        
        public int RegionId { get; set; }
        public virtual RegionModel Region { get; set; }

        public int NationalityId { get; set; }
        public virtual CountryModel Nationality { get; set; }

        
        public bool?   ResidentialStatus { get; set; }
        public string GuardianName { get; set; }
        
        public string GuardianPhone { get; set; }
        public string GuardianOccupation { get; set; }
        public string GuardianRelationship { get; set; }
        public bool? Disability{ get; set; }
        public string DisabilityType { get; set; }
        public string SourceOfFinance { get; set; }
        
        public int ReligionId { get; set; }
        public virtual ReligionModel Religion { get; set; }

        public string Denomination{ get; set; }
        public string Referrals { get; set; }
        public string EntryMode { get; set; }
        public string FirstQualification { get; set; }
        public string SecondQualification { get; set; }

        public string ProgrammeStudied { get; set; }
        public string FormerSchool { get; set; }
        public int SchoolId { get; set; }
        public virtual SchoolModel School { get; set; }

        public int LastYearInSchool { get; set; }
        public bool? Awaiting { get; set; }
        public int Grade { get; set; }
        public string YearOfAdmission { get; set; }
        public string PreferedHall { get; set; }
        public string Results { get; set; }
        public string ExternalHostel { get; set; }
        public bool? Elligible { get; set; }
        public bool? Admitted { get; set; }
        public int AdmittedBy { get; set; }

        public DateTime DateAdmitted { get; set; }
        public string AdmissionType { get; set; }
        public string SectionAdmitted { get; set; }
        public string HallAdmitted { get; set; }
        public string RoomNo { get; set; }
        public string Status { get; set; }
        public bool? SMSSent { get; set; }
        public bool? LetterPrinted { get; set; }
        public int FirstChoiceId { get; set; }
        public int SecondChoiceId { get; set; }
        public int ThirdChoiceId { get; set; }
        //public virtual ProgrammeModel FirstChoice { get; set; }
        //public virtual ProgrammeModel SecondChoice { get; set; }
        //public virtual ProgrammeModel ThirdChoice { get; set; }

        public virtual ICollection<ProgrammeModel> Programmes { get; set; }

         public virtual ICollection<ResultUploadModel> ResultUploads { get; set; }

        public virtual ICollection<WorkingExperienceModel> WorkingExperience { get; set; }

        public virtual ICollection<AcademicExperieceModel> AcademicExperience { get; set; }

        public virtual ICollection<RequirementModel> Requirement { get; set; }

        public virtual ICollection<DocumentUploadModel> DocumentUpload { get; set; }

        public virtual ICollection<SMSModel> Sms { get; set; }

        public bool? FeePaying { get; set; }
        public bool? ReportedInSchool { get; set; }
        public decimal FeesPaid { get; set; }
        public bool Reported { get; set; }
        //public string WorkPlace { get; set; }
        //public string WorkPlaceContact { get; set; }
        //public string YearsOfExperience { get; set; }
        public bool? SponsorShip { get; set; }
        public string SponsorShipCompany { get; set; }
        public string SponsorShipLocation { get; set; }
        public string SponsorShipCompanyContact { get; set; }

        //public string ama { get; set; }
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }


        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName + " "+ MiddleName;
            }

        }




        public ApplicantModel()
        {
          

        }
    }
}
