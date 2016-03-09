/* ===============================
* Author       : Cijoy Francis
* Create Date  : 08/03/2016
* Purpose      : Infor Coding Assignment
* ===============================
* Change History:
*
* ================================
*/

namespace InforBooks.Models
{
    public class BookListFormat
    {
        public string FormatIndicator { get; set; }

        public int NameStartIndex { get; set; }
        public int NameEndIndex { get; set; }

        public int ISBNStartIndex { get; set; }
        public int ISBNEndIndex { get; set; }

        public int AuthorStartIndex { get; set; }
        public int AuthorEndIndex { get; set; }

    }
}
