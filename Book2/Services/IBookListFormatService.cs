/* ===============================
* Author       : Cijoy Francis
* Create Date  : 08/03/2016
* Purpose      : Infor Coding Assignment
* ===============================
* Change History:
*
* ================================
*/

using InforBooks.Models;

namespace InforBooks.Services
{
    public interface IBookListFormatService
    {
        BookListFormat Handle(string formatIndicator);
    }
}
