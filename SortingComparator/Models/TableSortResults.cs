using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingComparator.Models
{
    public class TableSortResults
    {
        public double Size { get; set; }
        public Dictionary<string, double> Data { get; set; }

        public TableSortResults() {
            Data = new Dictionary<string, double>();
        }
    }
}
