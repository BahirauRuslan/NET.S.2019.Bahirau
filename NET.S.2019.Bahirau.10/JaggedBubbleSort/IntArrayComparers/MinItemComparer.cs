﻿using System.Collections.Generic;
using System.Linq;

namespace JaggedBubbleSort.IntArrayComparers
{
    public class MinItemComparer : IComparer<int[]>
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
                return x.Min().CompareTo(y.Min());
            }
        }
    }
}
