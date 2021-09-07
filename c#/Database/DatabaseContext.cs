using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;
using Backend.Database.Models;

namespace Backend.Database
{
    [DbConfigurationType(typeof(SqLiteConfiguration))]
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(string connString)
            : base(new SQLiteConnection(connString), true)
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<State> States { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            #region Country
            modelBuilder.Entity<Country>().ToTable("Country").HasKey(c => c.CountryId);
            modelBuilder.Entity<Country>().Property(e => e.CountryId)
                .HasColumnType("int");
            modelBuilder.Entity<Country>().Property(e => e.CountryName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(2000);
            #endregion

            #region City
            modelBuilder.Entity<City>().ToTable("City").HasKey(c => c.CityId);
            modelBuilder.Entity<City>().Property(e => e.CityId)
                .HasColumnType("int");
            modelBuilder.Entity<City>().Property(e => e.CityName)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(2000);
            modelBuilder.Entity<City>().Property(e => e.Population).HasColumnType("int").IsOptional();
            modelBuilder.Entity<City>().Property(e => e.StateId).HasColumnType("int");
            modelBuilder.Entity<City>().HasRequired(c => c.State).WithMany(s => s.Cities).HasForeignKey(c => c.StateId);
            #endregion

            #region State
            modelBuilder.Entity<State>().ToTable("State").HasKey(s => s.StateId);
            modelBuilder.Entity<State>().Property(e => e.StateId)
                .HasColumnType("int");
            modelBuilder.Entity<State>().Property(e => e.CountryId).HasColumnType("int");
            modelBuilder.Entity<State>().Property(e => e.StateName)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(2000);
            modelBuilder.Entity<State>().HasRequired(c => c.Country).WithMany(s => s.States).HasForeignKey(c => c.CountryId);
            #endregion

            
        }
    }
}
