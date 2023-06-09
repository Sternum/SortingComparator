using SortingComparator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingComparator.Sortings
{
    public class BubbleSort : SortingStrategy
    {
        public override string GetName()
        {
            return "Sortowanie Bąbelkopwe";
        }

        public override string GetTag()
        {
            return "BUBBLE_SORT";
        }

        public override SortData Sort(int[] arrayToSort)
        {
           base.Sort(arrayToSort);
            int n = arrayToSort.Length;
            do
            {
                counter++;
                for (int i = 0; i < n - 1; i++)
                {
                    counter++;
                    if (arrayToSort[i] > arrayToSort[i + 1])
                    {
                        
                        int tmp = arrayToSort[i];
                        arrayToSort[i] = arrayToSort[i + 1];
                        arrayToSort[i + 1] = tmp;
                    }
                }
                n--;
            }
            while (n > 1);

            return new SortData() { Size = arrayToSort.Length, Steps = counter };
        }
    }
}
