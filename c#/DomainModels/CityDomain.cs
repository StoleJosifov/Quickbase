namespace Backend.DomainModels
{
    public class CityDomain
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }
        public int? Population { get; set; }

        public virtual StateDomain State { get; set; }
    }
}
