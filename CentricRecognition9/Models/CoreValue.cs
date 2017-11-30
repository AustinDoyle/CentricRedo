using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CentricRecognition9.Models
{
    public class CoreValue
    {
        public int CoreValueID { get; set; }

        [Display(Name = "Core Value")]
        public string CoreValueName { get; set; }

        [Display(Name = "Description")]
        public string CoreValueDescription { get; set; }

        public ICollection<Recognition> Recognition { get; set; }

    }
}