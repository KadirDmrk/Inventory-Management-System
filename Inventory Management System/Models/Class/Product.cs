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
    public class Product
    {
        [Key]
        [Display(Name = " Ürün ID")]
        public int ProductID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(80)]
        [Display(Name = "Ürün Adı")]
        [Required]
        public string ProductName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(80)]
        [Display(Name = "Marka Adı")]
        
        public string ProductBrand { get; set; }

        [Display(Name = " Ürün Seri Numarası")]
        [StringLength(255, ErrorMessage = "En fazla 50 Rakam ")]
        public string SerialNumber { get; set; }

        [Display(Name = "Açıklama")]
        [StringLength(500, ErrorMessage = "En fazla 500 Rakam ")]

        public string Description { get; set; }
        [Required]
        public int Stok { get; set; }
        [Display(Name = "Fatura Numarası")]
        [StringLength(50, ErrorMessage = "En fazla 50 Rakam ")]
        
        public string BillSerialNumber { get; set; }

        [Display(Name = "Firma Adı")]
        
        [StringLength(50, ErrorMessage = "En fazla 80 Rakam ")]

        public string CompanyName { get; set; }
        [Display(Name = "Fatura Tarih")]
        [Required]
        public DateTime BillDateTime { get; set; }

        [Display(Name = "Kategori Numarası ")]
        public int Categoryid { get; set; }
        public bool IsActive { get; set; }
        public virtual Category Category { get; set; }
        public int? EmployeeId { get; set; }

        public virtual Employees Employees { get; set; }

        public virtual ICollection<ProductDebit> ProductDebits { get; set; }
    }
}