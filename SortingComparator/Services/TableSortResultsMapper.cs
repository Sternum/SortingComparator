using OxyPlot;
using SortingComparator.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingComparator.Services
{
    public class TableSortResultsMapper
    {

        public static List<TableSortResults> Map(ObservableCollection<SortingsResults> sortings)
        {
            List<TableSortResults> gridData = new List<TableSortResults>();

            foreach (SortingsResults results in sortings)
            {
                foreach(DataPoint point in results.DataPoints)
                {
                    TableSortResults data = gridData.FirstOrDefault(data => data.Size == point.X);
                    if(data == null)
                    {
                        data = new TableSortResults();
                        data.Size = point.X;
                        data.Data.Add(results.Name, point.Y);
                        gridData.Add(data);
                    } else
                    {
                        data.Data.Add(results.Name, point.Y);
                    }
                }
            }

            return gridData;
        }
    }
}
