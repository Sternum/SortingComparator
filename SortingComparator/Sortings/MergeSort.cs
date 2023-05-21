using SortingComparator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingComparator.Sortings
{
    public class MergeSort : ISortingStrategy
    {
        public string getName()
        {
            return "Sortowanie przez scalanie";
        }

        public string getTag()
        {
            return "MERGE_SORT";
        }

        public SortData Sort(int[] arrayToSort)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            Split(arrayToSort, 0, arrayToSort.Length - 1);
            watch.Stop();

            return new SortData { Size = arrayToSort.Length, Time = watch.Elapsed.TotalSeconds };
        }

        private void Split(int[] array, int left, int right)
        {
            if(left < right) { 
                int mid = (left + right) / 2;
                Split(array, left, mid);
                Split(array, mid + 1, right);
                Merge(array, left, mid, right);
            }
        }

        private void Merge(int[] array, int left, int mid, int right)
        {
            int leftIndex, rightIndex, mergeIndex;
            int leftSize = mid - left + 1;
            int rightSize = right - mid;

            int[] leftArray = new int[leftSize];
            int[] rigthArray = new int[rightSize];

            for(leftIndex = 0; leftIndex < leftSize; leftIndex++)
            {
                leftArray[leftIndex] = array[left + leftIndex];
            }

            for(rightIndex = 0; rightIndex < rightSize; rightIndex++)
            {
                rigthArray[rightIndex] = array[mid + 1 + rightIndex];
            }

            leftIndex = 0;
            rightIndex = 0;
            mergeIndex = left;

            while (leftIndex < leftSize && rightIndex < rightSize)
            {
                if (leftArray[leftIndex] <= rigthArray[rightIndex])
                {
                    array[mergeIndex] = leftArray[leftIndex];
                    leftIndex++;
                } 
                else
                {
                    array[mergeIndex] = rigthArray[rightIndex];
                    rightIndex++;
                }
                mergeIndex++;
            }

            while(rightIndex < rightSize)
            {
                array[mergeIndex] = rigthArray[rightIndex];
                rightIndex++;
                mergeIndex++;
            }
        }
    }
}
