using Castle.MicroKernel.SubSystems.Conversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory_Management_System.Models.Class
{
    public class OfficeInventory
    {
        [Key]
        public int ProductID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        [Display(Name = "Ürün Adı")]
        public string ProductName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        [Display(Name = "Marka Adı")]
        public string ProductBrand { get; set; }
        [Display(Name = "Seri Numarası")]
        public int SerialNumber { get; set; }
        public string Descraption { get; set; }    
        public int Stok { get; set; }
        public bool IsActive { get; set; }
        public int CategoryID { get; set; }
        //public ICollection<ProductDebit> ProductDebits { get; set; }



    }
}