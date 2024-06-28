using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inventory_Management_System.Models.Class
{
    public class Orders
    {
        [Key]
        public int OrderID { get; set; }    
        public DateTime DateTime { get; set; }
        public DateTime DeliveryDate { get; set; }
        public ICollection<Devices> Devices  { get; set; }
    }
}
