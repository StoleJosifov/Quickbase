using System;
using System.Collections.Generic;
using System.Linq;
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
            try
            {
                var query = _dataRepository.GetCountries().FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            return new List<Country>();
        }
    }
}
