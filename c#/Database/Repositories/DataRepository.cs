using System;
using System.Data.Entity;
using Backend.Database.Models;

namespace Backend.Database.Repositories
{
    public class DataRepository : IDataRepository
    {
        private readonly DatabaseContext _context;
        public DataRepository(DatabaseContext newContext)
        {
            if (newContext.Database.Exists())
            {
                _context = newContext;
            }
        }

        public DbSet<Country> GetCountries()
        {
            return _context.Countries;
        }
        public DbSet<State> GetStates()
        {
            return _context.States;
        }
        public DbSet<City> GetCities()
        {
            return _context.Cities;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

}
}
