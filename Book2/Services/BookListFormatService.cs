/* ===============================
* Author       : Cijoy Francis
* Create Date  : 08/03/2016
* Purpose      : Infor Coding Assignment
* ===============================
* Change History:
*
* ================================
*/

using System;
using System.Configuration;
using InforBooks.Models;

namespace InforBooks.Services
{
    public class BookListFormatService : IBookListFormatService
    {
        // Read BookListFormat from App.config based on FormatIndicator.
        public BookListFormat Handle(string formatIndicator)
        {
            return new BookListFormat
            {
                FormatIndicator = formatIndicator,
                NameStartIndex = Int32.Parse(ConfigurationManager.AppSettings.Get(formatIndicator + ":NameStartIndex")),
                NameEndIndex = Int32.Parse(ConfigurationManager.AppSettings.Get(formatIndicator + ":NameEndIndex")),
                ISBNStartIndex = Int32.Parse(ConfigurationManager.AppSettings.Get(formatIndicator + ":ISBNStartIndex")),
                ISBNEndIndex = Int32.Parse(ConfigurationManager.AppSettings.Get(formatIndicator + ":ISBNEndIndex")),
                AuthorStartIndex = Int32.Parse(ConfigurationManager.AppSettings.Get(formatIndicator + ":AuthorStartIndex")),
                AuthorEndIndex = Int32.Parse(ConfigurationManager.AppSettings.Get(formatIndicator + ":AuthorEndIndex"))
            };
        }
    }
}
