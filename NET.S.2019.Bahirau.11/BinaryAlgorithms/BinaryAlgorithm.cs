using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryAlgorithms
{
    public class BinaryAlgorithm
    {
        public int Search<T>(T[] array, T key, IComparer<T> comparer)
        {
            return Search(array, key, 0, array.Length - 1, comparer);
        }

        private int Search<T>(T[] array, T key, int left, int right, IComparer<T> comparer)
        {
            ValidateParameters(array, left, right, comparer);

            if (array.Length == 0)
            {
                return -1;
            }

            while (left != right)
            {
                var index = (right - left) / 2 + left;
                var compareResult = comparer.Compare(key, array[index]);

                if (compareResult == 0)
                {
                    return index;
                }
                else if (compareResult < 0)
                {
                    right = index;
                }
                else if (compareResult > 0)
                {
                    left = index;
                }
            }

            return -1;
        }

        private void ValidateParameters<T>(T[] array, int left, int right, IComparer<T> comparer)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Array must be not null.");
            }

            if (comparer == null)
            {
                throw new ArgumentNullException("Array must be not null.");
            }

            if (left > right || left < 0 || right > array.Length - 1)
            {
                throw new ArgumentException("Left border must be less (or equal) than right border.");
            }
        }
    }
}
