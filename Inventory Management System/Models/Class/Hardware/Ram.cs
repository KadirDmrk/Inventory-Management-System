using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inventory_Management_System.Models.Class.Hardware
{
    public class Ram
    {
        [Key]
        public int RamID { get; set; }
        [Display(Name = "Ram")]
        public string RamName { get; set; }

        public virtual Computer Computer { get; set; }

   

    }
}