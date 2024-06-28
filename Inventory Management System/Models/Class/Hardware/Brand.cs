using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inventory_Management_System.Models.Class.Hardware
{
    public class Brand
    {
        [Key]
        public int BrandID { get; set; }
        [Display(Name = "Marka Adı")]
        public string BrandName { get; set; }

        public virtual Computer Computer { get; set; }
    }
}