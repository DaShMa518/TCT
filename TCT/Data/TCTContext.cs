using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Terminal>().ToTable("Terminal");
            modelBuilder.Entity<Tool>().ToTable("Tool");
            modelBuilder.Entity<TermToolXref>().ToTable("TermToolXref");
        }
    }
}
