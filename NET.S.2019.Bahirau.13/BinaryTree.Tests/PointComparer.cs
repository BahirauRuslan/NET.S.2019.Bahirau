using System;
using System.Collections.Generic;

namespace BinaryTree.Tests
{
    public class PointComparer : IComparer<Point>
    {
        public int Compare(Point p1, Point p2)
        {
            var length1 = Math.Sqrt((p1.X * p1.X) + (p1.Y * p1.Y) + (p1.Z * p1.Z));
            var length2 = Math.Sqrt((p2.X * p2.X) + (p2.Y * p2.Y) + (p2.Z * p2.Z));
            return length1.CompareTo(length2);
        }
    }
}
