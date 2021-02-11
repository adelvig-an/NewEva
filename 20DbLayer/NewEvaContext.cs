using Microsoft.EntityFrameworkCore;
using NewEva.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEva.DbLayer
{
    public class NewEvaContext : DbContext
    {
        public DbSet<TempData> TempDatas { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<PrivatePerson> PrivatePersons { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Report> Reports { get; set; }

        public NewEvaContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
           => options.UseSqlite("Data Sourse=EvaDataBase.db");
    }
}
