using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inventory_Management_System.Models.Class
{
    public class MaterialRequestViewModel
    {
        [Required]
        public string MaterialName { get; set; }

        [Required]
        public int Quantity { get; set; }

    }
}