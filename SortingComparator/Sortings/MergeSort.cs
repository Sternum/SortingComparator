using SortingComparator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingComparator.Sortings
{
    public class MergeSort : SortingStrategy
    {

        public override string GetName()
        {
            return "Sortowanie przez scalanie";
        }

        public override string GetTag()
        {
            return "MERGE_SORT";
        }

        public override SortData Sort(int[] arrayToSort)
        {
            base.Sort(arrayToSort);
            Split(arrayToSort, 0, arrayToSort.Length - 1);
            return new SortData { Size = arrayToSort.Length, Steps = this.counter };
        }

        private void Split(int[] array, int left, int right)
        {
            if(left < right) { 
                this.counter++;
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
                this.counter++;
                leftArray[leftIndex] = array[left + leftIndex];
            }

            for(rightIndex = 0; rightIndex < rightSize; rightIndex++)
            {
                this.counter++;
                rigthArray[rightIndex] = array[mid + 1 + rightIndex];
            }

            leftIndex = 0;
            rightIndex = 0;
            mergeIndex = left;

            while (leftIndex < leftSize && rightIndex < rightSize)
            {
                this.counter++;
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

            while(leftIndex < leftSize)
            {
                this.counter++;
                array[mergeIndex] = leftArray[leftIndex];
                leftIndex++;
                mergeIndex++;
            }

            while(rightIndex < rightSize)
            {
                this.counter++;
                array[mergeIndex] = rigthArray[rightIndex];
                rightIndex++;
                mergeIndex++;
            }
            
        }
    }
}
