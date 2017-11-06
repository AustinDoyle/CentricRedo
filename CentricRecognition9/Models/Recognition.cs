using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CentricRecognition9.Models
{
    public class Recognition
    {
        public int RecognitionID { get; set; }

        [Display(Name = "Description")]
        public string description { get; set; }

        public int EmployeeID { get; set; }

        public virtual Employee Employee { get; set; }

        public int CoreValueID { get; set; }

        public virtual CoreValue CoreValue { get; set; }

    }
}