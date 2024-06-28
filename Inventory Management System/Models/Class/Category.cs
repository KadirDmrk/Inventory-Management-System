using Inventory_Management_System.Models.Class.Hardware;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Inventory_Management_System.Models.Class
{
    public class Category
    {
        [Key]

        [Display(Name = "Envanter Adı ")]
        public int CategoryID { get; set; }
        [Required(ErrorMessage = "Kategori Adını Giriniz")]
        [StringLength(50)]
        [Display(Name = "Kategori Adı")]
        public string CategoryName { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<HardwareSparePartsInventory> HardwareSparePartsInventories { get; set; }
        public ICollection<ProductDebit> ProductDebits { get; set; }



    }
}