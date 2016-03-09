/* ===============================
* Author       : Cijoy Francis
* Create Date  : 08/03/2016
* Purpose      : Infor Coding Assignment
* ===============================
* Change History:
*
* ================================
*/

using System.Collections.Generic;
using InforBooks.Models;

namespace InforBooks.Services
{
    public interface IReadBooksDetailsService
    {
        List<Book> Handle(string appDataFile);
    }
}
