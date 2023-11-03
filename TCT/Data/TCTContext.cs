using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using Microsoft.EntityFrameworkCore;
using TCT.Models;
//using TCT.Pages.Terminals;

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
        //public DbSet<Crimp> Crimps { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Terminal>().ToTable("Terminal");
            //modelBuilder.Entity<Tool>().ToTable("Tool");
            //modelBuilder.Entity<TermToolXref>().ToTable("TermToolXref");
            //modelBuilder.Entity<Manufacturer>().ToTable("Manufacturer");
            //modelBuilder.Entity<EquipType>().ToTable("EquipType");
            //modelBuilder.Entity<TermClass>().ToTable("TermClass");
            //modelBuilder.Entity<Crimp>().ToTable("Crimp");


            modelBuilder.Entity<Terminal>()
                .ToTable(nameof(Terminal));
            //    .HasMany(x => x.Tools)
            //    .WithMany(y => y.Terminals);
            //.HasMany(x => x.Tools)
            //.WithMany(y => y.Terminals)
            //.UsingEntity<TermToolXref>(
            //    //e => e.HasOne(typeof(Tool)).WithMany().OnDelete(DeleteBehavior.NoAction),
            //    //o => o.HasOne(typeof(Terminal)).WithMany().OnDelete(DeleteBehavior.NoAction));
            //    e => e.HasOne<Tool>(x => x.Tool).WithMany(x => x.TermToolXrefs).OnDelete(DeleteBehavior.Cascade),
            //    o => o.HasOne<Terminal>(y => y.Terminal).WithMany(y => y.TermToolXrefs).OnDelete(DeleteBehavior.Cascade));



            //.HasOne(e => e.Manufacturer)
            //.WithMany(e => e.Terminals)
            //.OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<Terminal>()
            //    .HasOne(e => e.TermClass)
            //    .WithMany(e => e.Terminals)
            //    .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Tool>()
                .ToTable(nameof(Tool));
            //.HasMany(x => x.TermToolXrefs)
            //.WithOne(y => y.Tool);

            //.OnDelete(DeleteBehavior.Cascade);
            //.HasOne(e => e.Manufacturer)
            //.WithMany(e => e.Tools)
            //.OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<Tool>()
            //    .HasOne(e => e.EquipType)
            //    .WithMany(e => e.Tools)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<TermToolXref>()
            //    .HasOne(e => e.Terminal)
            //    .WithMany(e => e.TermToolXrefs)
            //    .OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<TermToolXref>()
            //    .HasOne(e => e.Tool)
            //    .WithMany(e => e.TermToolXrefs)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Manufacturer>()
            //    .ToTable(nameof(Manufacturer));
            //.HasMany(t => t.Terminals)
            //.WithOne(m => m.Manufacturer);

            //modelBuilder.Entity<EquipType>()
            //    .ToTable(nameof(EquipType))
            //    .HasMany(y => y.Tools)
            //    .WithOne(y => y.EquipType);
            ////modelBuilder.Entity<TermClass>().ToTable("TermClass");

            //modelBuilder.Entity<Crimp>()
            //    .HasOne(e => e.Terminal)
            //    .WithMany(e => e.Crimps)
            //    .OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<Crimp>()
            //    .HasOne(e => e.Tool)
            //    .WithMany(e => e.Crimps)
            //    .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
