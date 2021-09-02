using System;
using System.Data.Entity;
using Backend.Database.Models;

namespace Backend.Database.Repositories
{
    public interface IDataRepository : IDisposable
    {
        DbSet<Country> GetCountries();
        DbSet<City> GetCities();
        DbSet<State> GetStates();
    }
}
