using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Management_System.Models.Class
{
    public class PersonelTalep
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TCKimlikNo { get; set; }
        public bool? Status { get; set; } // true: onaylandı, false: reddedildi, null: onay bekliyor

    }
}