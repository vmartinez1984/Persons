using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons.Core.Dtos
{
    public class DataTableDto
    {
        public string SortColumn
        {
            get
            {
                int order;

                order = Convert.ToInt32(Order[0]["column"]);
                return this.Columns[order]["data"];
            }
        }


        public string SortColumnDir { get { return this.Order[0]["dir"]; } }
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
                return (Start / Length) + 1;
            }
        }

        public Dictionary<string, string> Search { get; set; }

        public string SearchValue
        {
            get
            {
                return this.Search["value"];
            }
        }
    }
}
