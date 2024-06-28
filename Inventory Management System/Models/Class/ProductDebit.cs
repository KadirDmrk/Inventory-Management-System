using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inventory_Management_System.Models.Class
{
    public class ProductDebit
    {
        [Key]
        public int DebitID { get; set; }
        public DateTime Datetime { get; set; }
        public int EmployeesID { get; set; }
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public int Piece { get; set; }
        public string DebitProductBrand { get; set; }
        [StringLength(255, ErrorMessage = "En fazla 50 Rakam ")]

        public string DebitProductSerialNumber { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public virtual Product Product { get; set; }
        public virtual Employees Employees { get; set; }
        public virtual Category Category { get; set; }
        public virtual Department Department { get; set; }

    }
}
