using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CentricRecognition9.Models
{
    public class Employee
    {
        public int ID { get; set; }

        [Display(Name= "First Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name= "Last Name")]
        [Required]
        public string LastName { get; set; }
        
        [Display(Name = "Business Unit")]
        public string BusinessUnit { get; set; }

        [Display(Name = "Personal Email")]
        public string PersonalEmail { get; set; }

        [Display(Name = "Hire Date")]
        public string HireDate { get; set; }

        [Display(Name = "Mobile Phone")]
        public int MobilePhone { get; set; }

        [Display(Name = "LinkedIn")]
        public string Linkedin { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "Zip")]
        public int Zip { get; set; }

        [Display(Name = "Employement Status")]
        public string EmploymentStatus { get; set; }

        [Display(Name = "Skills")]
        public string Skills { get; set; }

        [Display(Name = "Centric Anniversary")]
        public string Birthday { get; set; }

        [Display(Name = "School")]
        public string School { get; set; }

        [Display(Name = "Previous Job")]
        public string PreviousJob { get; set; }
    }
}