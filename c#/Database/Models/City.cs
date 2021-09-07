using System.ComponentModel.DataAnnotations;

namespace Backend.Database.Models
{
    public class City
    {
       public int CityId { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }
        //Had problem with the Population property because SqLite is not strongly typed and accepts empty value for nullable int columns,
        //but the model binder does not accept empty values because it was failing to validate the affinity of the field as int,
        //but empty values are considered as empty strings. 

        //This issue is resolved in EF Core, but I decided to stick with EF6. I could write custom ModelBinder
        //and do something like PropertyBuilder.HasConversion but it would take more time, so I just replaced all '' with null in the DB
        public int? Population { get; set; }

        public virtual State State { get; set; }
    }
}
