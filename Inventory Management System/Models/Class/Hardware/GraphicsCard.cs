using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inventory_Management_System.Models.Class.Hardware
{
    public class GraphicsCard
    {
        [Key]
        public int GraphicsCardID { get; set; }
        [Display(Name = "Ekran Kartı")]
        public string GraphicsCardName { get; set; }

        public virtual Computer Computer { get; set; }

       
     

       
    }
}