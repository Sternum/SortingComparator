using SortingComparator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingComparator.Sortings
{
    public class SelectionSort : ISortingStrategy
    {
        public string getName()
        {
            return "Sortowanie przez wybieranie";
        }

        public string getTag()
        {
            return "SELECTION_SORT";
        }

        public SortData Sort(int[] arrayToSort)
        {
            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();
            int length = arrayToSort.Length;
            for(int i = 0; i < length; i++)
            {
                int min = i;
                for( int j = i + 1; j < length; j++)
                {
                    if (arrayToSort[j] < arrayToSort[min])
                    {
                        min = j;
                    }
                }

                if(min != i)
                {
                    int tmp = arrayToSort[i];
                    arrayToSort[i] = arrayToSort[min];
                    arrayToSort[min] = tmp;
                }
            }
            watch.Stop();
            
            return new SortData { Size = arrayToSort.Length, Time = watch.Elapsed.TotalSeconds };
        }
    }
}
