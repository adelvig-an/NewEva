using Microsoft.EntityFrameworkCore;
using NewEva.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEva.DbLayer
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<PrivatePerson> PrivatePersons { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Customer> Customers { get; set; }
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
            //    modelBuilder.Entity<Contract>()
            //        .Property(e => e.Target)
            //        .HasConversion(v => v.ToString(),
            //        v => (Target)Enum.Parse(typeof(Target), v));
            //    modelBuilder.Entity<Customer>()
            //        .Property(e => e.TypeCustomer)
            //        .HasConversion(v => v.ToString(),
            //        v => (TypeCustomer)Enum.Parse(typeof(TypeCustomer), v));
            //    modelBuilder.Entity<Director>()
            //        .Property(e => e.PowerOfAttorney)
            //        .HasConversion(v => v.ToString(),
            //        v => (PowerOfAttorney)Enum.Parse(typeof(PowerOfAttorney), v));
        }
    }
}
