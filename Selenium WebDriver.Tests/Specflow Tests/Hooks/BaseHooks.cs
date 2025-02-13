using BoDi;
using Microsoft.Extensions.DependencyInjection;
using Selenium_WebDriver.Core.Core;
using Selenium_WebDriver.Core.Interfaces;
using Selenium_WebDriver.Core.Utils;
using TechTalk.SpecFlow;

namespace Selenium_WebDriver.Tests.Specflow_Tests
{
    [Binding]
    public class BaseHooks
    {
        protected static IServiceProvider _serviceProvider;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IDriverFactory, DriverFactory>();
            services.AddSingleton<IWaitFactory, WaitFactory>();
            services.AddSingleton<IDriverContext, DriverContext>();
            services.AddTransient<DownloadUtils>();

            _serviceProvider = services.BuildServiceProvider();
        }

        [AfterTestRun]
        public static void EndTest()
        {
            Console.WriteLine("AfterScenario: Cleaning up...");

            if (_serviceProvider is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
    }
}
