using System.Collections.Generic;
using Backend.Database.Models;

namespace Backend.DomainModels.AutoMapper
{
    public interface IAutoMapperService
    {
        IEnumerable<CountryDomain> MapToCountryDomain(IEnumerable<Country> dbCountries);
    }
}
