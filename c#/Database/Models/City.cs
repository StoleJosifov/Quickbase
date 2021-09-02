namespace Backend.Database.Models
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }
        public int? Population { get; set; }

        public virtual State State { get; set; }
    }
}
