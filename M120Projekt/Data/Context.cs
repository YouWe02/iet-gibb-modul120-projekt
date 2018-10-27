using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace M120Projekt.Data
{
    class Context : DbContext
    {
        public Context() : base("Pokemon")
        {
            this.Configuration.LazyLoadingEnabled = true;
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Data.Context, M120Projekt.Migrations.Configuration>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pokemon>();
            modelBuilder.Entity<Typ>();
        }
        public DbSet<Pokemon> Pokemon { get; set; }
        public DbSet<Typ> Typ { get; set; }

    }
}
