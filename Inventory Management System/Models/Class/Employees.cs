using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace Inventory_Management_System.Models.Class
{
    public class Employees
    {
        [Key]

        public int EmployeeID { get; set; }
        [Display(Name = "Personel Adı")]
        [Column(TypeName = "Varchar")]
        [Required(ErrorMessage = "Bu Alanı Boş Bırakamazsınız ")]
        [StringLength(100, ErrorMessage = "En fazla 50 Karakterlik İsim Girin")]
        public string EmployeeName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        [Display(Name = "Personel Soyadı")]
        public string EmployeeSurname { get; set; }

        [Display(Name = "Personel Görevi")]
        [Column(TypeName = "Varchar")]
        [Required(ErrorMessage = "Bu Alanı Boş Bırakamazsınız ")]
        [StringLength(100)]
        public string EmployessTask { get; set; }


        public int Departmentid { get; set; }
        [Display(Name = "Departman")]
        public virtual Department Department { get; set; } // Bir çalışan birden fazla departmanda çalışamaz.

        
        public virtual ICollection<Devices> Devices { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public virtual ICollection<ProductDebit> ProductDebits { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(70)]
        [Display(Name = "Mail Adresi")]
        public string EmployeeMail { get; set; }

    }
}