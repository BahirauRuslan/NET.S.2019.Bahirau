namespace Day4Tasks
{
    public static class IntArrayExtension
    {
        public delegate int Parameter(int[] arr);

        public static int ExtensionCompareTo(this int[] arr, int[] secondArr, Parameter parameter)
        {
            return parameter(arr).CompareTo(parameter(secondArr));
        }
    }
}
