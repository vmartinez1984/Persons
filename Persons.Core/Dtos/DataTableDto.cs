namespace Persons.Core.Dtos
{
    public class DataTableDto
    {
        public string SortColumn
        {
            get
            {
                int order;

                if (Order is null)
                    order = 0;
                else
                    order = Convert.ToInt32(Order[0]["column"]);
                return this.Columns is null ? string.Empty : this.Columns[order]["data"];
            }
        }

        public string SortColumnDir { get { return this.Order is null ? string.Empty : this.Order[0]["dir"]; } }
        public int Draw { get; set; }
        public int Length { get; set; } = 0;

        public string Name { get; set; }

        public int Start { get; set; }

        public List<Dictionary<string, string>> Order { get; set; }

        public List<Dictionary<string, string>> Columns { get; set; }

        public int RecordsPerPage
        {
            get
            {
                return Length;
            }
        }

        public int PageCurrent
        {
            get
            {
                return Start == 0 && Length == 0 ? 1 : (Start / Length) + 1;
            }
        }

        public Dictionary<string, string> Search { get; set; }

        public string SearchValue
        {
            get
            {
                return this.Search is null? string.Empty: this.Search["value"];
            }
        }
    }
}
