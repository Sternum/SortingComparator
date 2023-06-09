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
        private List<SortingStrategy> sortingStrategies;

        public SortingService()
        {
            preparationService = new ArrayPreparationService();
            sortingStrategies = new List<SortingStrategy>();
            sortingStrategies.Add(new SelectionSort());
            sortingStrategies.Add(new MergeSort());
            sortingStrategies.Add(new BubbleSort());
            sortingStrategies.Add(new QuickSort());
            sortingStrategies.Add(new BucketSort());    
        }

        public async Task<List<SortingsResults>> RunTest(int maxArrayLength)
        {
            
            int[][] arraysToTest = preparationService.Prepare(maxArrayLength);

            List<Task<SortingsResults>> tasks = new List<Task<SortingsResults>>();

            foreach(SortingStrategy strategy in sortingStrategies)
            {
                tasks.Add(Task.Run(() => SortTask(arraysToTest, strategy)));
            }
            
            SortingsResults[] results = await Task.WhenAll(tasks);
               
            return results.ToList<SortingsResults>();
        }

        private SortingsResults SortTask(int[][] arraysToTest, SortingStrategy strategy)
        {
            SortingsResults sortResult = new SortingsResults();
            sortResult.Name = strategy.GetName();
            sortResult.Tag = strategy.GetTag();
            foreach (int[] value in arraysToTest)
            {
                
                int[] clonedArray = new int[value.Length];
                Array.Copy(value, clonedArray, value.Length);
                SortData data = strategy.Sort(clonedArray);
                sortResult.DataPoints.Add(new DataPoint(data.Size, data.Steps));
            }
            Trace.WriteLine(sortResult.Tag);
            return sortResult;
        }
    }
}
