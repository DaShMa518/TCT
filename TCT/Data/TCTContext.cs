using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using Microsoft.EntityFrameworkCore;
using TCT.Models;

namespace TCT.Data
{
    public class TCTContext : DbContext
    {
        public TCTContext (DbContextOptions<TCTContext> options)
            : base(options)
        {
        }

        public DbSet<Terminal> Terminals { get; set; }
        public DbSet<Tool> Tools { get; set; }
        public DbSet<TermToolXref> TermToolXrefs { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<EquipType> EquipTypes { get; set; }
        public DbSet<TermClass> TermClasses { get; set; }
        public DbSet<Crimp> Crimps { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Terminal>().ToTable("Terminal");
            modelBuilder.Entity<Tool>().ToTable("Tool");
            modelBuilder.Entity<TermToolXref>().ToTable("TermToolXref");
            modelBuilder.Entity<Manufacturer>().ToTable("Manufacturer");
            modelBuilder.Entity<EquipType>().ToTable("EquipType");
            modelBuilder.Entity<TermClass>().ToTable("TermClass");
            //modelBuilder.Entity<Crimp>().ToTable("Crimp");

            modelBuilder.Entity<Crimp>()
                .HasOne(e => e.Terminal)
                .WithMany(e => e.Crimps)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
