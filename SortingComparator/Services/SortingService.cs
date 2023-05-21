using OxyPlot;
using SortingComparator.Models;
using SortingComparator.Sortings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingComparator.Services
{
    public class SortingService
    {
        private ArrayPreparationService preparationService;
        private List<ISortingStrategy> sortingStrategies;

        public SortingService()
        {
            preparationService = new ArrayPreparationService();
            sortingStrategies = new List<ISortingStrategy>();
            sortingStrategies.Add(new MergeSort());
            sortingStrategies.Add(new SelectionSort());
            
        }

        public List<SortingsResults> RunTest(int maxArrayLength)
        {
            List<SortingsResults> results = new List<SortingsResults>();
            int[][] arraysToTest = preparationService.Prepare(maxArrayLength);
            foreach(ISortingStrategy strategy in sortingStrategies)
            {
                SortingsResults sortResult = new SortingsResults();
                sortResult.Name = strategy.getName();
                sortResult.Tag = strategy.getTag();
                foreach (int[] value in arraysToTest)
                {
                    int[] clonedArray = new int[value.Length];
                    Array.Copy(value, clonedArray, value.Length);
                    SortData data = strategy.Sort(clonedArray);
                    sortResult.DataPoints.Add(new DataPoint(data.Size, data.Time));
                }
                results.Add(sortResult);
            }

         
            return results;
        }
    }
}
