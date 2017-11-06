using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentricRecognition9.Models
{
    public class CoreValue
    {
        public int CoreValueID { get; set; }

        public string CoreValueName { get; set; }

        public string CoreValueDescription { get; set; }

        public ICollection<Recognition> Recognition { get; set; }

    }
}