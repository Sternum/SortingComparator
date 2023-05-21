using SortingComparator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingComparator.Sortings
{
    public interface ISortingStrategy
    {
        SortData Sort(int[] arrayToSort);
        string getTag();
        string getName();
    }
}
