using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inventory_Management_System.Models
{
    public class Approver
    {
        [Key]
        public int ApproverID { get; set; }

        [Required]
        public string Email { get; set; }

        public int HierarchyLevel { get; set; }


    }
}