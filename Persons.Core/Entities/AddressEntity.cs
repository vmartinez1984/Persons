namespace Persons.Core.Entities
{
    public class AddressEntity: BaseEntity
    {       
        public string StreetAndNumber { get; set; }

        public string Settlement { get; set; }

        public string TownHall { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }
    }
}