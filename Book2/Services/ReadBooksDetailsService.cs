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
using System.Collections.Generic;
using System.IO;
using InforBooks.Models;

namespace InforBooks.Services
{
    public class ReadBooksDetailsService : IReadBooksDetailsService
    {
        private bool isFirstLine;
        private List<Book> books;
        private string[] lines;
        private BookListFormat bookListFormat;

        private IBookListFormatService bookListFormatController;
        private ILoggingService logger;

        public ReadBooksDetailsService(IBookListFormatService bookListFormatController, ILoggingService logger)
        {
            this.bookListFormatController = bookListFormatController;
            this.logger = logger;
        }

        // Read book details.
        public List<Book> Handle(string appDataFile)
        {
            isFirstLine = true;
            books = new List<Book>();

            try
            {
                lines = File.ReadAllLines(appDataFile);
            }

            catch (IOException exception)
            {
                logger.Handle("Error while opening file: " + appDataFile + "\n" + exception.Message);
            }

            catch (Exception exception)
            {
                logger.Handle("Error while reading file: " + appDataFile + "\n" + exception.Message);
            }

            foreach (string line in lines)
            {
                // First line contains FormatIndicator.
                if (isFirstLine)
                {
                    logger.Handle("Processing List of Books - " + appDataFile);
                    isFirstLine = false;

                    try
                    {
                        // Read BookListFormat based on FormatIndicator.
                        bookListFormat = bookListFormatController.Handle(line);
                    }
                    catch (Exception exception)
                    {
                        if (exception.Message.Contains("Value cannot be null"))
                        {
                            logger.Handle("Error reading File format details for " + line + " from App.config - wrong key value");
                            Environment.Exit(0);
                        }
                        else
                        {
                            logger.Handle("Error reading File format details for " + line + " from App.config - " + exception.Message);
                            Environment.Exit(0);
                        }
                    }

                    // First line contains only FormatIndicator and no book details, so skip this iteration.
                    continue;
                }

                try
                {
                    // Read Book Name, ISBN, Author based on the index values mentioned in App.config for this FormatIndicator.
                    books.Add(new Book() { 
                    Name = line.Substring(bookListFormat.NameStartIndex - 1, bookListFormat.NameEndIndex).Trim(),
                    ISBN = line.Substring(bookListFormat.ISBNStartIndex - 1, bookListFormat.ISBNEndIndex - bookListFormat.ISBNStartIndex).Trim(),
                    Author = line.Substring(bookListFormat.AuthorStartIndex - 1, bookListFormat.AuthorEndIndex - bookListFormat.AuthorStartIndex).Trim()
                    });

                }
                catch (Exception exception)
                {
                    logger.Handle("Error reading Book details from file: " + appDataFile+", Line: " + line
                        +"\nPlease check if start & end indexes mentioned in App.config matches with the file: " + appDataFile);
                }

            }
            logger.Handle("Finished processing List of Books - " + appDataFile + "\n");
            return books;
        }

    }
}
