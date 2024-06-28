using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inventory_Management_System.Models.Class.Hardware
{
    public class HardDrive
    {
        [Key]
        public int HardDriveID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        [Display(Name = "Hardisk alanı")]
        public string HardDriveName { get; set; }

        public virtual Computer Computer { get; set; }

    }
}