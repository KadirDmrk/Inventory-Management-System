using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inventory_Management_System.Models.Class
{
    public class Devices
    {
        [Key]
        public string DevicesID { get; set; }
        public int SerialNumber { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Processor { get; set; }
        public string Monitors { get; set; }
        public string HardDrive { get; set; }

        public Employees Employees { get; set; }

        public virtual Product Product { get; set; }
        public DeviceHistory DeviceHistory { get; set; } // bir cihazın bir geçmişi olur . 
        public ServiceLevelAgreement ServiceLevelAgreement { get; set; } // Bir cihazın bir  bir servis sağlayacısı olur 

        public Orders Orders { get; set; } // bir cihaz bir order'a bağlıdır. 
    }
}