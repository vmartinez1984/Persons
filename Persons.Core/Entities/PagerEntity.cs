namespace Persons.Core.Entities
{
    public class PagerEntity
    {
        public int PageCurrent { get; set; }

        public int RecordsPerPage { get; set; }

        public string Search { get; set; }

        public string SortColumn { get; set; }

        public string SortColumnDir { get; set; }

        public int TotalRecords { get; set; }

        public int TotalRecordsFiltered { get; set; }
    }
}