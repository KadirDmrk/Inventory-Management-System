using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inventory_Management_System.Models.Class
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage = "Kullanıcı Adını Giriniz")]
        public string Username { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage = "Parolanızı Giriniz")]
        public string Password { get; set; }
        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string Authorization { get; set; }
    }
}