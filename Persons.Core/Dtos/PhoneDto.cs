using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Persons.Core.Dtos
{
    public class PhoneDto
    {

        [JsonIgnoreAttribute]
        public string Id { get; set; }

        [Required]
        [MaxLength(10)]
        [MinLength(10)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(25)]
        public string Type { get; set; }
    }
}