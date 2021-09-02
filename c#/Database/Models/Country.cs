using System.Collections.Generic;

namespace Backend.Database.Models
{
    public sealed class Country
    {
        public Country()
        {
            States = new HashSet<State>();
        }

        public string CountryName { get; set; }
        public int CountryId { get; set; }

        public ICollection<State> States { get; set; }
    }
}
