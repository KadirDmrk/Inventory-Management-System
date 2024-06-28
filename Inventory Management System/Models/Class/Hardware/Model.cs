using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inventory_Management_System.Models.Class.Hardware
{
    public class Model
    {
        [Key]
        public int ModelID { get; set; }
        [Display(Name = "Model Adı")]
        public String ModelName { get; set; }

        public virtual Computer Computer { get; set; }

    }

}