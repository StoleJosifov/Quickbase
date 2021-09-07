using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountriesStatisticsController : ControllerBase
    {
        private readonly ILogger<CountriesStatisticsController> _logger;
        private readonly IApiStatService _apiService;
        private readonly IDbStatService _dbService;

        public CountriesStatisticsController(ILogger<CountriesStatisticsController> logger, IApiStatService apiService, IDbStatService dbStatService )
        {
            _logger = logger;
            _apiService = apiService;
            _dbService = dbStatService;
        }

        [HttpGet]
        public async Task<List<Tuple<string, int>>> Get()
        {
            var dbResults = await GetDbResults();

            var apiResults = await GetApiResults();

            var results = dbResults.Union(apiResults, new CountryEqualityComparer());

            return results.ToList();
        }

        #region Helpers
        [NonAction]
        private async Task<List<Tuple<string, int>>> GetApiResults()
        {
            List<Tuple<string, int>> apiResults = new();
            try
            {
                apiResults = await _apiService.GetCountryPopulationsAsync();
                _logger.LogInformation("Api results retrieved.", apiResults);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _logger.LogError("Api call failed.", e);
            }

            return apiResults;
        }

        [NonAction]
        private async Task<List<Tuple<string, int>>> GetDbResults()
        {
            List<Tuple<string, int>> dbResults = new();

            try
            {
                dbResults = await _dbService.GetCountryPopulationsAsync();
                _logger.LogInformation("Db results retrieved.", dbResults);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _logger.LogError("Db call failed.", e);
            }

            return dbResults;
        }
        #endregion
    }
}
