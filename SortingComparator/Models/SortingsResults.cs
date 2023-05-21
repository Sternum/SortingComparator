using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingComparator.Models
{
    public class SortingsResults
    {
        public string Name { get; set; }
        public string Tag { get; set; }
        public List<DataPoint> DataPoints { get; set; }

        public SortingsResults() { 
            DataPoints = new List<DataPoint>();
        }

    }
}
