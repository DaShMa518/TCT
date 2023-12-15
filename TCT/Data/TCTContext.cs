using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
<<<<<<< HEAD
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using Microsoft.Build.Evaluation;
=======
using Microsoft.AspNetCore.Razor.Language.Intermediate;
>>>>>>> 881d7f11e5023fb96b845d9f26e3badbcea7d18f
using Microsoft.EntityFrameworkCore;
using TCT.Models;

namespace TCT.Data
{
    //public class TCTContext : DbContext
    public class TCTContext : IdentityDbContext<TCTUser>
    {
        public TCTContext (DbContextOptions<TCTContext> options)
            : base(options)
        {
        }

        //public DbSet<TCTUser> TCTUsers {  get; set; }
        public DbSet<Terminal> Terminals { get; set; }
        public DbSet<Tool> Tools { get; set; }
<<<<<<< HEAD
=======
        public DbSet<TermToolXref> TermToolXrefs { get; set; }
>>>>>>> 881d7f11e5023fb96b845d9f26e3badbcea7d18f
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<EquipType> EquipTypes { get; set; }
        public DbSet<TermClass> TermClasses { get; set; }
        public DbSet<Crimp> Crimps { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
<<<<<<< HEAD
            base.OnModelCreating(modelBuilder);

=======
>>>>>>> 881d7f11e5023fb96b845d9f26e3badbcea7d18f
            modelBuilder.Entity<Terminal>()
                .ToTable(nameof(Terminal));

            modelBuilder.Entity<Tool>()
                .ToTable(nameof(Tool));

            modelBuilder.Entity<Crimp>()
                .ToTable(nameof(Crimp));
        }
    }
}
