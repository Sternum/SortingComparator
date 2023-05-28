using SortingComparator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingComparator.Sortings
{
    public class SelectionSort : SortingStrategy
    {

        public override string GetName()
        {
            return "Sortowanie przez wybieranie";
        }

        public override string GetTag()
        {
            return "SELECTION_SORT";
        }

        public override SortData Sort(int[] arrayToSort)
        {
            base.Sort(arrayToSort);
            int length = arrayToSort.Length;
            for(int i = 0; i < length; i++)
            {
                int min = i;
                for( int j = i + 1; j < length; j++)
                {
                    this.counter++;
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
                    this.counter++;
                }
            }
            
            return new SortData { Size = arrayToSort.Length, Steps = this.counter };
        }
    }
}
