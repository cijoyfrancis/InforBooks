using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InforBooks.Models;
using InforBooks.Services;
using NFluent;

namespace InforBooksUnitTest
{

    [TestClass]
    public class BookListFormatServiceTest
    {
 
        [TestMethod]
        public void TestBookListFormatServiceHandle()
        {

            BookListFormat bookListFormatExpectedValue = new BookListFormat
            {
                FormatIndicator = "A",
                NameStartIndex = 1,
                NameEndIndex = 20,
                ISBNStartIndex = 21,
                ISBNEndIndex = 41,
                AuthorStartIndex = 42,
                AuthorEndIndex = 62
            };

            BookListFormat bookListFormat = new BookListFormatService().Handle("A");
            Check.That(bookListFormat).HasFieldsWithSameValues(bookListFormatExpectedValue);


            BookListFormat bookListFormatExpectedValueB = new BookListFormat
            {
                FormatIndicator = "B",
                NameStartIndex = 1,
                NameEndIndex = 30,
                ISBNStartIndex = 31,
                ISBNEndIndex = 51,
                AuthorStartIndex = 52,
                AuthorEndIndex = 72
            };

            BookListFormat bookListFormatB = new BookListFormatService().Handle("B");
            Check.That(bookListFormatB).HasFieldsWithSameValues(bookListFormatExpectedValueB);


        }

    }
}
