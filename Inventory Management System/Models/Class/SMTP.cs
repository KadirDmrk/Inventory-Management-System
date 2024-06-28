using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Xunit.Sdk;

namespace Inventory_Management_System.Models
{
    public class SMTP
    {
        [Required(ErrorMessage = "AdıSoyadı gereklidir!!")]
        public string Name { get; set; }
        [Email(ErrorMessage = "Email Geçersiz")]
        [Required(ErrorMessage = "Boş Olmaz!!")]
        public string Email { get; set; }
        [MaxLength(500, ErrorMessage = "100 Karekteri geçemez")]
        public string Subject { get; set; }
        [MaxLength(500, ErrorMessage = "2000 Karekteri geçemez")]
        public string Message { get; set; }

    }
}