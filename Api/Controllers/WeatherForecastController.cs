using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Backend.Services;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IApiStatService _apiService;
        private readonly IDbStatService _dbService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IApiStatService apiService, IDbStatService dbStatService )
        {
            _logger = logger;
            _apiService = apiService;
            _dbService = dbStatService;
        }

        [HttpGet]
        public List<Tuple<string, int>> Get()
        {
            var dbTask = _dbService.GetCountryPopulationsAsync();
            dbTask.Wait();
            var dbResult = dbTask.Result;

            var apiTask = _apiService.GetCountryPopulationsAsync();
            apiTask.Wait();
            var apiResult = apiTask.Result;

            var results = dbResult.Union(apiResult,new CountryEqualityComparer());

            return results.ToList();
        }
    }
}
