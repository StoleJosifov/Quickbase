using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Backend.Database.Models;

namespace Backend.Database
{
    public class DatabaseContext : DbContext
    {

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<State> States { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Country>().HasKey(c => c.CountryId);
            modelBuilder.Entity<Country>().HasMany(s => s.States);

            modelBuilder.Entity<City>().HasKey(c => c.CityId);

            modelBuilder.Entity<State>().HasKey(c => c.StateId);
            modelBuilder.Entity<State>().HasMany(s => s.Cities);
        }
    }
}
