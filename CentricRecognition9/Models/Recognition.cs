using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CentricRecognition9.Models
{
    public class Recognition
    {
        public int RecognitionID { get; set; }

        [Display(Name = "Description")]
        public string description { get; set; }

        public Guid EmployeeID { get; set; }
        [ForeignKey("EmployeeID")]

        public virtual Employee Employee { get; set; }

        public int CoreValueID { get; set; }

        public virtual CoreValue CoreValue { get; set; }

    }
}