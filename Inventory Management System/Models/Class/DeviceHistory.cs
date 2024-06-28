using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inventory_Management_System.Models.Class
{
    public class DeviceHistory
    {
        [Key]
        public int HistoryID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Action { get; set; }

        public  ICollection<Devices> Devices { get; set; } // Cihaz geçmişinde birden fazla bilgisayar bulunur. 
    }
}