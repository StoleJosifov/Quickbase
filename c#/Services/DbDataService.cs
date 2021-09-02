using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Backend.Database.Models;
using Backend.Database.Repositories;
using System.Linq;

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
            var query = _dataRepository.GetCountries().Include("States");

            return await query.ToListAsync();
        }
    }
}
