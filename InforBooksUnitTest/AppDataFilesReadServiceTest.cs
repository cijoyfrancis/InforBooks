using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Castle.MicroKernel.Registration;
using InforBooks.Services;

namespace InforBooksUnitTest
{

    [TestClass]
    public class AppDataFilesReadServiceTest
    {
        //private string[] appDataFiles;

        [TestMethod]
        public void TestAppDataFilesReadServiceTestHandle()
        {
            IWindsorContainer container = new WindsorContainer();
            container.Register(Component.For<ILoggingService>().ImplementedBy<LoggingService>());
            container.Register(Component.For<IAppDataFilesReadService>().ImplementedBy<AppDataFilesReadService>());

            // Read App Data Files 
            var appDataFiles = container.Resolve<IAppDataFilesReadService>().Handle();

            //appDataFiles = new AppDataFilesReadService().Handle();

            string[] fileNames = new string[] { "C:\\InforBooks\\A.TXT", "C:\\InforBooks\\B.TXT" };
            CollectionAssert.AreEqual(fileNames, appDataFiles);

        }

    }
}
