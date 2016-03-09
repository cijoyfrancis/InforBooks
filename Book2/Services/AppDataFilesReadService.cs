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
using System.IO;

namespace InforBooks.Services
{

    public class AppDataFilesReadService : IAppDataFilesReadService
    {

        ILoggingService logger;
        public AppDataFilesReadService(ILoggingService logger)
        {
            this.logger = logger;
        }

        // Read App Data Files (List of books) based on the location mentioned in AppDataLocation in App.config
        public string[] Handle()
        {
            string appDataLocation = null;
            string[] appDataFiles = null;

            try
            {
                appDataLocation = ConfigurationManager.AppSettings.Get("AppDataLocation");
            }
            catch (Exception exception)
            {
                logger.Handle("Error while accessing AppDataLocation setting from App.config: \n" 
                    + exception.Message + "\nPlease provide a valid path for AppDataLocation in App.config.");
                Environment.Exit(0);
            }

            try
            {
                // Read App Data input files here.
                appDataFiles = Directory.GetFiles(@appDataLocation);

                if (appDataFiles.Length == 0)
                {
                    logger.Handle("No files exists in " + appDataLocation + ". Please provide input files in this location");
                    Environment.Exit(0);
                }
            }
            catch (Exception exception)
            {
                logger.Handle("Exception while reading app data files from "+ appDataLocation + " : " + exception);
                Environment.Exit(0);
            }

            return appDataFiles;
        }
    }
}
