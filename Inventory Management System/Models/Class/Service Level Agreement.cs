using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inventory_Management_System.Models.Class
{
    public class ServiceLevelAgreement
    {
        [Key]
        public int SlaID { get; set; }
        public int StartDate  { get; set; }
        public int EndDate { get; set; }

        public int MyProperty { get; set; }

        public  ICollection<Devices> Devices { get; set; } // SLA'in birden fazla cihazı olur 

    }
}