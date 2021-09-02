using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Services
{
    public interface IStatService
    {
        Task<List<Tuple<string, int>>> GetCountryPopulationsAsync();
    }
}
