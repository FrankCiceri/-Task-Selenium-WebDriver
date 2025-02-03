using Microsoft.Extensions.DependencyInjection;
using Selenium_WebDriver.Core.Core;
using Selenium_WebDriver.Core.Interfaces;
using Selenium_WebDriver.Core.Core;
using Selenium_WebDriver.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selenium_WebDriver.Core.Utils;

namespace Selenium_WebDriver.Tests
{
    public class TestBase : IDisposable
    {
        protected IServiceProvider ServiceProvider { get; private set; }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IDriverFactory, DriverFactory>();
            services.AddSingleton<IWaitFactory, WaitFactory>();
            services.AddSingleton<IDriverContext, DriverContext>();
            services.AddTransient<DownloadUtils>();

            services.AddTransient<Tests>();

            ServiceProvider = services.BuildServiceProvider();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Dispose();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
