using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Persons.Core.Dtos;

namespace Persons.Core.Dto
{
    public class PersonDto : PersonDtoIn
    {
        public string Id { get; set; }
    }

    public class PersonDtoIn
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
        
        public List<AddressDtoIn> ListAddresses { get; set; }

        public List<PhoneDto> ListPhones { get; set; }

        public List<string> ListEmails { get; set; }

        [JsonIgnoreAttribute]
        public string UserId { get; set; }
    }
}