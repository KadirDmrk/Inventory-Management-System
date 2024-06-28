using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inventory_Management_System.Models.Class.Hardware
{
    public class Computer
    {
        [Key]
        [Display(Name = "Laptop")]
        public string Laptop { get; set; }
        [Display(Name = "Masa Üstü")]
        public string Desktop { get; set; }

        public ICollection<Ram> Rams { get; set; }   
        public ICollection<GraphicsCard> GraphicsCards { get; set; }
        public ICollection<Monitor> Monitors { get; set; }
        public ICollection<Processor> Processors { get; set; }
        public ICollection<Model> Models { get; set; }
        public ICollection<HardDrive> HardDrives { get; set; }
        public ICollection<Brand> Brands { get; set; }
    
    }
}