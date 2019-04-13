using System.Collections.Generic;

namespace JaggedBubbleSort.IntArrayComparers
{
    public class FirstItemComparer : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            if (x == null && y == null)
            {
                return 0;
            }
            else if (x == null)
            {
                return -1;
            }
            else if (y == null)
            {
                return 1;
            }
            else
            {
                return x[0].CompareTo(y[0]);
            }
        }
    }
}
