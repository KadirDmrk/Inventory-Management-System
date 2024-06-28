using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Inventory_Management_System.Models.Class.Hardware;

namespace Inventory_Management_System.Models.Class
{
    public class Context : DbContext // Db context sınıfından miras  aldık
    {
        public DbSet<Department> Department { get; set; }
        public DbSet<DeviceHistory> DeviceHistory { get; set; }
        public DbSet<Devices> Devices { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<ServiceLevelAgreement> ServiceLevelAgreements { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PersonelTalep> PersonelTaleps { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Ram> Rams { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<GraphicsCard> GraphicsCards { get; set; }
        public DbSet<Processor> Processors { get; set; }
        public DbSet<Monitor> Monitors { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<HardDrive> HardDrives { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<OfficeInventory> OfficeInventories { get; set; }
        public DbSet<HardwareInventory> HardwareInventories { get; set; }
        public DbSet<HardwareSparePartsInventory> HardwareSparePartsInventories { get; set; }
        public DbSet<DocumentationInventory> DocumentationInventories { get; set; }
        public DbSet<ProductDebit> ProductDebits { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Approval> Approvals { get; set; }




    }
}