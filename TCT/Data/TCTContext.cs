﻿using System;
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
            modelBuilder.Entity<Terminal>()
                .ToTable(nameof(Terminal));

            modelBuilder.Entity<Tool>()
                .ToTable(nameof(Tool));

            modelBuilder.Entity<Crimp>()
                .ToTable(nameof(Crimp));
        }
    }
}
