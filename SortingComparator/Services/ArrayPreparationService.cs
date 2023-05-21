using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingComparator.Services
{
    public class ArrayPreparationService
    {
        Random random = new Random();

        public int[][] Prepare(int maxLength)
        {
            int numberOfArray = maxLength - 2;
            int[][] arraysToTest = new int[numberOfArray][];
            int size = 3;
            for(int i = 0; i < numberOfArray; i++) {
                arraysToTest[i] = new int[size];
                for(int j =0; j < size; j++)
                {
                    arraysToTest[i][j] = random.Next(1, 1000);
                }
                size++;
            }
            return arraysToTest;
        }
    }
}
