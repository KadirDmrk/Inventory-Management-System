using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inventory_Management_System.Models.Class.Hardware
{
    public class Processor
    {
        [Key]
        public int ProcessorID { get; set; }
        [Display(Name = "İşlemci")]
        public string ProcessorName { get; set; }

        public virtual Computer Computer { get; set; }

    }
}