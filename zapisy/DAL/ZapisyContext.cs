using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zapisy.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace zapisy.DAL
{
    public class ZapisyContext :DbContext
    {

        public ZapisyContext() : base("ZapisyContext")
        {
        }

        public DbSet<Student> Studenci { get; set; }
        public DbSet<Firma> Firmy { get; set; }
        public DbSet<Projekt> Projekty { get; set; }
        public DbSet<Uzytkownik> Uzytkownicy { get; set; }
        public DbSet<Zespol> Zespoly { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}