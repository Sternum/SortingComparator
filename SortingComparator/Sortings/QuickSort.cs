using SortingComparator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingComparator.Sortings
{
    public class QuickSort : SortingStrategy
    {

        public override string GetName()
        {
            return "Sortowanie szybkie";
        }

        public override string GetTag()
        {
            return "QUICK_SORT";
        }
		
		public override SortData Sort(int[] arrayToSort)
        	{
			base.Sort(arrayToSort);
            ExecuteQuickSort(arrayToSort, 0, arrayToSort.Length - 1);
			return new SortData { Size = arrayToSort.Length, Steps = this.counter };
		}

        private void ExecuteQuickSort(int[] array, int left, int right)
        {
            counter++;
            if (left < right)
            {
                int partitionIndex = Partition(array, left, right);
                ExecuteQuickSort(array, left, partitionIndex - 1);
                ExecuteQuickSort(array, partitionIndex + 1, right);
            }
        }

        private int Partition(int[] array, int left, int right)
        {
            int pivot = array[right];
            int i = left - 1;

            for (int j = left; j <= right - 1; j++)
            {
                counter++;
                if (array[j] < pivot)
                {
                    i++;
                    Swap(array, i, j);
                }
            }

            Swap(array, i + 1, right);
            return i + 1;
        }

        private void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}