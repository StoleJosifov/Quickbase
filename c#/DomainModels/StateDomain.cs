using System.Collections.Generic;
using Backend.Database.Models;

namespace Backend.DomainModels
{
    public class StateDomain
    {
        public StateDomain()
        {
        }

        public int StateId { get; set; }
        public string StateName { get; set; }
        public int CountryId { get; set; }

    }
}
