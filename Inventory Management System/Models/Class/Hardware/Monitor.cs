using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inventory_Management_System.Models.Class.Hardware
{
    public class Monitor
    {
        [Key]
        public int MonitorID { get; set; }
        [Display(Name = "Monitör")]
        public string MonitorName { get; set; }
        [Display(Name = "Seri Numarası")]
        public int SerialNumber { get; set; }

        public virtual Computer Computer { get; set; }


    }
}