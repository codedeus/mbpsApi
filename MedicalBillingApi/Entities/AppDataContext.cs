using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalBillingApi.Entities
{
    public class AppDataContext : IdentityDbContext<AppUser>
    {
        public AppDataContext() : base()
        {
        }

        public AppDataContext(DbContextOptions options) : base(options) { }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DrugStore> DrugStores { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceItem> InvoiceItems { get; set; }
        public virtual DbSet<Receipt> Receipts { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<AppUser> AppUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Invoice>().HasOne(a => a.Customer)
                          .WithMany(au => au.Invoices)
                          .HasForeignKey(a => a.CustomerId)
                          .IsRequired(false);
        }
    }
}
