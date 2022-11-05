using System.ComponentModel.DataAnnotations;

namespace Persons.Core.Dto
{
    public class AddressDto: AddressDtoIn
    {
        public string Id { get; set; }
    }

    public class AddressDtoIn
    {
        [Required]
        [MaxLength(255)]
        [MinLength(10)]
        public string StreetAndNumber { get; set; }

        public string Reference { get; set; }

        [Required]
        [MaxLength(255)]
        public string Settlement { get; set; }

        [Required]
        [MaxLength(255)]
        public string TownHall { get; set; }

        [Required]
        [MaxLength(50)]
        public string State { get; set; }

        [Required]
        [MaxLength(5)]
        public string ZipCode { get; set; }
    }
}