using System;
using System.Diagnostics;
using System.Timers;

namespace NumberExtensions
{
    public class FindNextBiggerAlgo
    {
        public int FindNextBiggerNumber(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentException();
            }

            int[] digits = GetDigitsOfPositiveNumber(number);
            digits = ReplaseDigits(digits);
            int result = ConvertDigitsToNumber(digits);

            if (result > number)
            {
                return result;
            }

            return -1;
        }

        public (int, double) FindNextBiggerNumberAndTime(int number)
        {
            Timer timer = new Timer();
            
            int result;
            //var watch = Stopwatch.StartNew();
            timer.Start();
            result = FindNextBiggerNumber(number);
            timer.Stop();
            //watch.Stop();
            return (result, timer.Interval);//watch.ElapsedMilliseconds);
        }

        private int[] ReplaseDigits(int[] digits)
        {
            for (int i = 0; i < digits.Length - 1; i++)
            {
                if (digits[i + 1] < digits[i])
                {
                    digits[i + 1] ^= digits[i];
                    digits[i] ^= digits[i + 1];
                    digits[i + 1] ^= digits[i];
                    SortDescUntil(digits, i);
                    return digits;
                }
            }

            return digits;
        }

        private void SortDescUntil(int[] arr, int index)
        {
            for (int i = 0; i < index; i++)
            {
                for (int j = i + 1; j < index + 1; j++)
                {
                    if (arr[j] > arr[i])
                    {
                        arr[i] ^= arr[j];
                        arr[j] ^= arr[i];
                        arr[i] ^= arr[j];
                    }
                }
            }
        }

        private int ConvertDigitsToNumber(int[] digits)
        {
            int number = 0;

            for (int i = 0; i < digits.Length; i++)
            {
                number += digits[i] * (int)Math.Pow(10, i);
            }

            return number;
        }

        private int[] GetDigitsOfPositiveNumber(int number)
        {
            int[] digits = new int[(int)Math.Floor(Math.Log10(number)) + 1];

            for (int i = 0; i < digits.Length; i++)
            {
                digits[i] = number % 10;
                number /= 10;
            }

            return digits;
        }
    }
}
