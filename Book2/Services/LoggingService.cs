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

namespace InforBooks.Services
{
    public class LoggingService : ILoggingService
    {
        private string appDataLocation;
        private string logFileDirectory;
        private string logFileURL;

        public LoggingService()
        {
            try
            {
                appDataLocation = ConfigurationManager.AppSettings.Get("AppDataLocation");
            }
            catch (Exception exception)
            {
                this.Handle("Error while accessing AppDataLocation setting from App.config: \n"
                    + exception.Message + "\nPlease provide a valid path for AppDataLocation in App.config.");
                Environment.Exit(0);
            }

            try
            {
                logFileDirectory = appDataLocation + "\\Logs";
                System.IO.Directory.CreateDirectory(logFileDirectory);
            }
            catch (Exception exception)
            {
                this.Handle("Error creating Log file directory: " + logFileDirectory +"\n"
                    + exception.Message);
            }

            logFileURL = logFileDirectory + "\\Log.txt";

        }

        public void Handle(string log)
        {
            try
            {
                System.IO.File.AppendAllText(@logFileURL, log + "\n");
                Console.WriteLine(log);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error writing to log file: " + logFileURL);
            }
        }
    }
}
