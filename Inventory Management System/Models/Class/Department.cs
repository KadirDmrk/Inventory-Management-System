using Inventory_Management_System.Models.Class.Hardware;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inventory_Management_System.Models.Class
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        [Display(Name = "Departman Adı")]
        public string DepartmentName { get; set; }
      


        public bool DepartmentPosition { get; set; }

        public ICollection<Employees> Employees { get; set; } // Departmanda birden fazla çalışan yer alabilir.

        public virtual ICollection<ProductDebit> ProductDebits { get; set; }


    }
}