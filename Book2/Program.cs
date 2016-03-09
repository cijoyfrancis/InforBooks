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
using System.Linq;
using System.Collections.Generic;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Castle.MicroKernel.Registration;
using InforBooks.Services;

namespace InforBooks
{
    class Program
    {

        private static List<Book> books = new List<Book>();

        static void Main(string[] args)
        {
            // Windsor registration
            IWindsorContainer container = new WindsorContainer();
            container.Install(FromAssembly.This());
            container.Register(Classes.FromThisAssembly().Pick().WithServiceAllInterfaces());

            // Read App Data Files 
            var appDataFiles = container.Resolve<IAppDataFilesReadService>().Handle();
            var logger = container.Resolve<ILoggingService>();

            // Iterate App Data input files and process one by one.
            foreach (string appDataFile in appDataFiles)
            {
                logger.Handle("File: " + appDataFile);
                // Book details from each file is appended to this list.
              books = books.Concat(container.Resolve<IReadBooksDetailsService>().Handle(appDataFile)).ToList();
            }

            logger.Handle("\n\nList of Books: ");
            foreach (Book book in books)
            {
                logger.Handle("Name: " + book.Name + "\nISBN: " + book.ISBN + "\nAuthor: " + book.Author + "\n\n");
            }
            logger.Handle("\nTotal number of books imported: " + books.Count + "\n");

        }

    }
}
