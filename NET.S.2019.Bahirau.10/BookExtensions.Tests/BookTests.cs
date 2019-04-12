using System;
using System.Globalization;
using NUnit.Framework;

namespace BookExtensions.Tests
{
    [TestFixture]
    public class BookTests
    {
        private Book _book;

        [SetUp]
        public void Setup()
        {
            if (_book == null)
            {
                _book = new Book
                {
                    ISBN = "978-0-7356-6745-7",
                    Author = "Jeffrey Richter",
                    Title = "CLR via C#",
                    Publisher = "Microsoft Press",
                    PublishingYear = 2012,
                    PagesCount = 826,
                    Price = 59.99m
                };
            }
        }

        #region Book IFormattable.ToString Tests

        [TestCase("AT", "Jeffrey Richter, CLR via C#")]
        [TestCase("ATPY", "Jeffrey Richter, CLR via C#, \"Microsoft Press\", 2012")]
        [TestCase("IATPYC", "ISBN 13: 978-0-7356-6745-7, Jeffrey Richter, CLR via C#, \"Microsoft Press\", 2012, P. 826")]
        [TestCase("IATPYCS", "ISBN 13: 978-0-7356-6745-7, Jeffrey Richter, CLR via C#, \"Microsoft Press\", 2012, P. 826, $59.99")]
        public void TestToString_FormatCombineFormatProviderEnUS_ExpectedString(string format, string expected)
        {
            var actual = _book.ToString(format, new CultureInfo("en-US"));

            Assert.AreEqual(expected, actual);
        }

        [TestCase("G", "CLR via C#")]
        [TestCase("T", "CLR via C#")]
        [TestCase("I", "ISBN 13: 978-0-7356-6745-7")]
        [TestCase("A", "Jeffrey Richter")]
        [TestCase("P", "\"Microsoft Press\"")]
        [TestCase("Y", "2012")]
        [TestCase("C", "P. 826")]
        [TestCase("S", "$59.99")]
        public void TestToString_FormatSingleFormatProviderEnUS_ExpectedOneString(string format, string expected)
        {
            var actual = _book.ToString(format, new CultureInfo("en-US"));

            Assert.AreEqual(expected, actual);
        }

        [TestCase(null, "CLR via C#")]
        [TestCase("", "CLR via C#")]
        public void TestToString_FormatNullOrEmtptyFormatProviderNull_ExpectedTitle(string format, string expected)
        {
            var actual = _book.ToString(format, null);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestToString_FormatIncorrectCurrentFormatProvider_ExpectedFormatException()
        {
            Assert.Throws<FormatException>(() => _book.ToString("ABC", CultureInfo.CurrentCulture));
        }

        #endregion
    }
}