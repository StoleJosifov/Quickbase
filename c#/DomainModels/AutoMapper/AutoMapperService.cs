using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Backend.Database.Models;

namespace Backend.DomainModels.AutoMapper
{
    public class AutoMapperService : IAutoMapperService
    {
        private readonly Mapper _mapper;

        public AutoMapperService()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
                cfg.CreateMap<Country, CountryDomain>()
                    .ForMember(dest => dest.Name, act => act.MapFrom(src => src.CountryName))
                    .ForMember(dest => dest.Id, act => act.MapFrom(src => src.CountryId))
                    .ForMember(dest => dest.Population, act => act.MapFrom(src => src.States.Sum(state => state.Cities.Sum(city => city.Population.GetValueOrDefault()))))
            );
            _mapper = new Mapper(mapperConfiguration);
        }

        public IEnumerable<CountryDomain> MapToCountryDomain(IEnumerable<Country> dbCountries)
        {
            
            var results = _mapper.Map<IEnumerable<Country>, IEnumerable<CountryDomain>>(dbCountries);
            return results;
        }

    }

}
