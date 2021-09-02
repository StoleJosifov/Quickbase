using System.Collections.Generic;
using Backend.Database.Models;

namespace Backend.DomainModels
{
    public class StateDomain
    {

        public StateDomain()
        {
            Cities = new HashSet<Database.Models.City>();
        }

        public int StateId { get; set; }
        public string StateName { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }

        public virtual ICollection<Database.Models.City> Cities { get; set; }
    }
}
