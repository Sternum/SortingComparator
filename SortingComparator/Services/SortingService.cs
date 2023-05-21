using OxyPlot;
using SortingComparator.Models;
using SortingComparator.Sortings;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            sortingStrategies.Add(new SelectionSort());
            sortingStrategies.Add(new MergeSort());
            
            
        }

        public async Task<List<SortingsResults>> RunTest(int maxArrayLength)
        {
            
            int[][] arraysToTest = preparationService.Prepare(maxArrayLength);

            List<Task<SortingsResults>> tasks = new List<Task<SortingsResults>>();

            foreach(ISortingStrategy strategy in sortingStrategies)
            {
                tasks.Add(Task.Run(() => SortTask(arraysToTest, strategy)));
            }
            
            SortingsResults[] results = await Task.WhenAll(tasks);
               
            return results.ToList<SortingsResults>();
        }

        private SortingsResults SortTask(int[][] arraysToTest, ISortingStrategy strategy)
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
            Trace.WriteLine(sortResult.Tag);
            return sortResult;
        }
    }
}
