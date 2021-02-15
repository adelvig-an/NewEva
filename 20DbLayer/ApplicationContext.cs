using Microsoft.EntityFrameworkCore;
using NewEva.Model;
using NewEva.VM;
using NewEva.Model.Contractor;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NewEva.DbLayer
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<InsurancePolicie> InsurancePolicies { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<PrivatePerson> PrivatePersons { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<OrganizationAppraiser> OrganizationsAppraisers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<QualificationCertificate> QualificationCertificates { get; set; }
        public DbSet<Appraiser> Appraisers { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Report> Reports { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        { 
            options.UseSqlite("Data Source=EvaDataBase.db");
            options.UseLazyLoadingProxies();
            base.OnConfiguring(options);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("People");
            modelBuilder.Entity<PrivatePerson>().ToTable("PrivatePersons");
            modelBuilder.Entity<Director>().ToTable("Directors");
            modelBuilder.Entity<Appraiser>().ToTable("Appraisers");
            modelBuilder.Entity<Organization>().ToTable("Organizations");
            modelBuilder.Entity<OrganizationAppraiser>().ToTable("OrganizationsAppraisers");
            
            modelBuilder.Entity<Contract>()
                .Property(e => e.Target)
                .HasConversion(v => v.ToString(),
                v => (Target)Enum.Parse(typeof(Target), v));
            modelBuilder.Entity<Customer>()
                .Property(e => e.TypeCustomer)
                .HasConversion(v => v.ToString(),
                v => (TypeCustomer)Enum.Parse(typeof(TypeCustomer), v));
            modelBuilder.Entity<QualificationCertificate>()
                .Property(e => e.Speciality)
                .HasConversion(v => v.ToString(),
                v => (Speciality)Enum.Parse(typeof(Speciality), v));  
        }

        public void WriteDb(ReportVM reportVM, ApplicationContext context)
        {
            var report = new Report
            {
                Id = reportVM.Id,
                Number = reportVM.Number,
                VulationDate = reportVM.VulationDate,
                CompilationDate = reportVM.CompilationDate,
                InspectionDate = reportVM.InspectionDate,
                InspectionFeaures = reportVM.InspectionFeaures
            };
            context.Reports.Add(report);
            context.SaveChanges();
        }

        public void UpdateDb(ReportVM reportVM, ApplicationContext context)
        {
            var report = context.Reports.First();
            report.Id = reportVM.Id;
        }

    }
}
