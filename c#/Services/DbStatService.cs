using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Backend.DomainModels.AutoMapper;

namespace Backend.Services
{
    public class DbStatService: IDbStatService
    {
        private readonly IDataService _dbDataService;
        private readonly IAutoMapperService _autoMapperService;


        public DbStatService(IDataService dbDataService, IAutoMapperService autoMapperService)
        {
            _dbDataService = dbDataService;
            _autoMapperService = autoMapperService;
        }
        
        public async Task<List<Tuple<string, int>>> GetCountryPopulationsAsync()
        {
            var dbCountries = await _dbDataService.GetCountries();
            List<Tuple<string, int>> newResults = new List<Tuple<string, int>>();

            try
            {
                var results = _autoMapperService.MapToCountryDomain(dbCountries).ToList();
                newResults = results.Select(x => new Tuple<string, int>(x.Name, x.Population)).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return newResults;
        }
    }
}
