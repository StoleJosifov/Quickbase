using System.Linq;
using Backend.Database.Models;

namespace Backend.DomainModels
{
    public class CountryDomain
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public int Population { get; set; }

    }
}
