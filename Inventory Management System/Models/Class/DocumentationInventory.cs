using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inventory_Management_System.Models.Class
{
    public class DocumentationInventory
    {
        [Key]
        public int DocumentationID { get; set; }

        [Display(Name = "Seri Numarası")]
        public int SerialNumber { get; set; }

        [Display(Name = " Dokümantasyon Adı:")]
        public string DocumentationName { get; set; }
        [Display(Name = " Açıklama")]
        public string Description { get; set; }
        public bool IsActive { get; set; }
        //public ICollection<ProductDebit> ProductDebits { get; set; }



    }
}