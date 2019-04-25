using NUnit.Framework;

namespace CustomMatrix.Tests
{
    public class SumExtensionTests
    {
        private static readonly string[,] Rectangle =
        {
            { "12", "24", "45", "83" },
            { "82", "ab", "Cd", "nu" }
        };

        private static readonly object[] PositiveCases =
        {
            new object[]
            {
                new StaticMatrix<string>(Rectangle),
                new StaticMatrix<string>(Rectangle),
                new StaticMatrix<string>(new string[,]
                {
                    { "1212", "2424", "4545", "8383" },
                    { "8282", "abab", "CdCd", "nunu" }
                })
            },
            new object[]
            {
                new RectangleMatrix<string>(Rectangle),
                new RectangleMatrix<string>(Rectangle),
                new StaticMatrix<string>(new string[,]
                {
                    { "1212", "2424", "4545", "8383" },
                    { "8282", "abab", "CdCd", "nunu" }
                })
            },
            new object[]
            {
                new RectangleMatrix<string>(Rectangle),
                new StaticMatrix<string>(Rectangle),
                new StaticMatrix<string>(new string[,]
                {
                    { "1212", "2424", "4545", "8383" },
                    { "8282", "abab", "CdCd", "nunu" }
                })
            }
        };

        [TestCaseSource(nameof(PositiveCases))]
        public void TestSum_RectanglePlusRectangle_Rectangle(
            StaticMatrix<string> firstMatrix, StaticMatrix<string> secondMatrix, StaticMatrix<string> expected)
        {
            var actual = firstMatrix.Sum(secondMatrix);

            CollectionAssert.AreEqual(expected.ToRectangleArray(), actual.ToRectangleArray());
        }
    }
}
