using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite.EF6;
using System.Data.Entity;
using System.Threading.Tasks;
using Backend.Database.Models;
using Backend.Database.Repositories;

namespace Backend.Services
{
    public class DbDataService : IDataService
    {
        private readonly IDataRepository _dataRepository;

        public DbDataService(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public async Task<List<Country>> GetCountries()
        {
            List<Country> query;
            try
            {
                query = await _dataRepository.GetCountries().ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return query;
        }
    }
}
