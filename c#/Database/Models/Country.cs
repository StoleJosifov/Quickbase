using System.Collections.Generic;

namespace Backend.Database.Models
{
    public class Country
    {
        public Country()
        {
            States = new HashSet<State>();
        }

        public string CountryName { get; set; }
        public int CountryId { get; set; }

        public virtual ICollection<State> States { get; set; }
    }
}
