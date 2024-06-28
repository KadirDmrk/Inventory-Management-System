using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inventory_Management_System.Models.Class
{
    public class Request
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Açıklama")]
        [StringLength(500, ErrorMessage = "Harf Sınırını Aştınız !!")]
        public string Description { get; set; }
        [Display(Name = "Onaylayacak Kişi Sayısı")]
        public int ApproverCount { get; set; }
        public bool IsApproved { get; set; }

        [Display(Name = "Seri Numarası")]
        public string Trackingcode { get; set; }
        [Display(Name = "Pozisyon")]
        [StringLength(70, ErrorMessage = "Harf Sınırını Aştınız !!")]

        public string Position { get; set; }
        [Display(Name = "Departman")]
        [StringLength(70, ErrorMessage = "Harf Sınırını Aştınız !!")]
        public string Department { get; set; }
        [Display(Name = "Bölüm")]
        public string Chapter { get; set; }
        [Display(Name = "Kadro")]
        public string Staff { get; set; }
        [Display(Name = "Eğitim Durumu ")]
        public string EducationalStatus { get; set; }
        [Display(Name = "Yüksek Lisans")]
        public string Degree { get; set; }
        [Display(Name = "Tercih Edilen Okullar")]
        [StringLength(70, ErrorMessage = "Harf Sınırını Aştınız !!")]
        public string PreferredSchools { get; set; }
        [Display(Name = "Uzmanlık Alanı")]
        [StringLength(70, ErrorMessage = "Harf Sınırını Aştınız !!")]
        public string Specialty { get; set; }
        [Display(Name = "Deneyim")]
        [StringLength(70, ErrorMessage = "Harf Sınırını Aştınız !!")]
        public string Experience { get; set; }
        [Display(Name = "Yabancı Dil")]
        [StringLength(70, ErrorMessage = "Harf Sınırını Aştınız !!")]
        public string ForeignLanguage { get; set; }
        [Display(Name = "Bilgisayar ")]
        [StringLength(70, ErrorMessage = "Harf Sınırını Aştınız !!")]
        public string ComputerSkills { get; set; }
        [Display(Name = "Askerlik")]
        [StringLength(70, ErrorMessage = "Harf Sınırını Aştınız !!")]
        public string MilitaryService { get; set; }

        [Display(Name = "Cinsiyet")]
        public string Sex { get; set; }
        [Display(Name = "Yaş Grubu")]
        [StringLength(70, ErrorMessage = "Harf Sınırını Aştınız !!")]
        public string AgeGroup { get; set; }
        [Display(Name = "Diğer Teknil Bilgi Beceriler ve adlığı sertifikasyonlar ")]
        [StringLength(70, ErrorMessage = "Harf Sınırını Aştınız !!")]
        public string AbilityCertification { get; set; }
        [Display(Name = "İş Tanımı")]
        [StringLength(500, ErrorMessage = "Harf Sınırını Aştınız !!")]
        public string JobDefinition { get; set; }
        [Display(Name = "Talep Eden")]
        [StringLength(70, ErrorMessage = "Harf Sınırını Aştınız !!")]
        public string RequestedBy { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Talep Tarihi")]
        public DateTime RequestDate { get; set; }

        public virtual ICollection<Approval> Approvals { get; set; }
    }

    public class Approval
    {
        [Key]
        public int Id { get; set; }
        public int RequestId { get; set; }
        public string ApproverEmail { get; set; }
        public bool IsApproved { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public virtual Request Request { get; set; }
    }

}