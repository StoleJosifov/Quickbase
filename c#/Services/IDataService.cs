using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Database.Models;

namespace Backend.Services
{
    public interface IDataService
    {
        Task<List<Country>> GetCountries();
    }
}
