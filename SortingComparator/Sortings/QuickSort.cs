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
            return "Sortowanie szybkie";
        }

        public override string GetTag()
        {
            return "QUICK_SORT";
        }
		
		public override SortData Sort(int[] arrayToSort)
        	{
			base.Sort(arrayToSort);
			QuickSort(arrayToSort, 0, arrayToSort.Lenght -1);
			return new SortData { Size = arrayToSort.Length, Steps = this.counter };
		}
		
		private void QuickSort(int[] array, int left, int right)
		{
			int i = left;
			int j = right;
			int pivot = array[(left + right) / 2];
			
		
			while(i < j)
			{
				while(array[i] < pivot) i++;
				while(array[j] > pivot) j--;
				if (i <=j)
				{
				int tmp = array[i];
				array[i++] = array[j];
				array[j--] = tmp;
				}
			}
			if (left < j) QuickSort(array, left, j);
			if (i < right) QuickSort (array, i, right);
			this.counter++;
	
		}
	}
}