using SortingComparator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingComparator.Sortings
{
    internal class BucketSort : SortingStrategy
    {
        public override string GetName()
        {
            return "Sortowanie kubełkowe";
        }

        public override string GetTag()
        {
            return "BUCKET_SORT";
        }

        public override SortData Sort(int[] arrayToSort)
        {
            base.Sort(arrayToSort);

            int n = arrayToSort.Length;

            int maxVal = arrayToSort[0];
            int minVal = arrayToSort[0];

            for (int i = 1; i < n; i++)
            {
                counter++;
                if (arrayToSort[i] > maxVal) { maxVal = arrayToSort[i]; }
                if (arrayToSort[i] < minVal) { minVal = arrayToSort[i]; };
            }

            int range = maxVal - minVal + 1;
            int[][] buckets = new int[range][];

            for (int i = 0; i < range; ++i)
            {
                counter++;
                buckets[i] = new int[0];
            }

            for (int i = 0; i < n; i++)
            {
                counter++;
                int buckertIndex = (arrayToSort[i] - minVal);
                Array.Resize(ref buckets[buckertIndex], buckets[buckertIndex].Length + 1);
                buckets[buckertIndex][buckets[buckertIndex].Length - 1] = arrayToSort[i];
            }

            for (int i = 0; i < range; i++)
            {
                InsertionSort(buckets[i]);
            }

            int index = 0;
            for (int i = 0; i < range; i++)
            {
                counter++;
                for (int j = 0; j < buckets[i].Length; j++)
                {
                    counter++;
                    arrayToSort[index++] = buckets[i][j];
                }
            }

            return new SortData() { Size = arrayToSort.Length, Steps = counter };
        }

        private void InsertionSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; i++)
            {
                counter++;
                int key = arr[i];
                int j = i - 1;
                while (j >= 0 && arr[j] > key)
                {
                    counter++;
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }
    }
}
