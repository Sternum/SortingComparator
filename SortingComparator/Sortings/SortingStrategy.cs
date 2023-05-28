using SortingComparator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingComparator.Sortings
{
    public abstract class SortingStrategy
    {
        protected ulong counter = 0;
        public virtual SortData Sort(int[] arrayToSort)
        {
            counter = 0;
            return new SortData();
        }
        public abstract string GetTag();
        public abstract string GetName();
    }
}
