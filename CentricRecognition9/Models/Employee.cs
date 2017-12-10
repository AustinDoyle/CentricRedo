using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace CentricRecognition9.Models
{
    public class Employee
    {
        [Required]
        [Key]
        public Guid UID { get; set; }

        [Display(Name = "Full Name")]
        public string fullName { get { return LastName + ", " + FirstName; } }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Patient first name is required")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Patient last name is required")]
        public string LastName { get; set; }

        [Display(Name = "Business Unit")]
        [Required(ErrorMessage = "Business Unit is required")]
        public string BusinessUnit { get; set; }

        [Display(Name = "Work Email")]
        [Required(ErrorMessage = "Work email is required")]
        public string PersonalEmail { get; set; }

        [Display(Name = "Mobile Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^((\d{3}) |\d{3}-)\d{3}-\d{4}$", ErrorMessage = "Phone numbers must be stored in the format (xxx) xxx-xxxx or xxx-xxx-xxxx")]
        public string MobilePhone { get; set; }

        [Display(Name = "LinkedIn")]
        public string Linkedin { get; set; }

        [Display(Name = "Employment Status")]
        public string EmploymentStatus { get; set; }

        [Display(Name = "Skills")]
        public string Skills { get; set; }

        [Display(Name = "When did you start working at Centric?")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public string StartDate { get; set; }

        [Display(Name = "School")]
        public string School { get; set; }

        [Display(Name = "Previous Job")]
        public string PreviousJob { get; set; }

    }
}