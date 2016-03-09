using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InforBooks.Models;
using System.Collections.Generic;
using NUnit.Framework;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using InforBooks.Services;

namespace InforBooksUnitTest
{

    [TestClass]
    public class ReadBooksDetailsServiceTest
    {
 
        [TestMethod]
        public void TestReadBooksDetailsServiceHandle()
        {
            IWindsorContainer container = new WindsorContainer();
            container.Register(Component.For<ILoggingService>().ImplementedBy<LoggingService>());
            container.Register(Component.For<IBookListFormatService>().ImplementedBy<BookListFormatService>());
            container.Register(Component.For<IReadBooksDetailsService>().ImplementedBy<ReadBooksDetailsService>());    

            var actualA = container.Resolve<IReadBooksDetailsService>().Handle("C:\\InforBooks\\A.TXT");
            NUnit.Framework.Assert.IsNotNull(actualA);

            var actualB = container.Resolve<IReadBooksDetailsService>().Handle("C:\\InforBooks\\B.TXT");
            NUnit.Framework.Assert.IsNotNull(actualB);


        }

    }
}
