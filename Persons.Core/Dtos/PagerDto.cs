using System.Text.Json.Serialization;

namespace Persons.Core.Dtos
{
    public class PagerDto
    {
        public int PageCurrent { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 10;
        public string Search { get; set; }
        public string SortColumn { get; set; } = "Id";
        public string SortColumnDir { get; set; } = "Desc";

        [JsonIgnoreAttribute]
        public int TotalRecords { get; set; }

        [JsonIgnoreAttribute]
        public int TotalRecordsFiltered { get; set; }
    }
}