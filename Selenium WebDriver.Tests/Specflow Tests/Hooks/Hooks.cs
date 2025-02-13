using BoDi;
using Microsoft.Extensions.DependencyInjection;
using Selenium_WebDriver.Core.Interfaces;
using Selenium_WebDriver.Core.Utils;
using TechTalk.SpecFlow;

namespace Selenium_WebDriver.Tests.Specflow_Tests
{
    [Binding]
    public class Hooks : BaseHooks
    {
        private static IDriverContext _driverContext;
        private static DownloadUtils _downloadUtil;

        private readonly IObjectContainer _objectContainer;

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            LoggerUtil.InitializeLoggerUtil();
            _driverContext = _serviceProvider.GetRequiredService<IDriverContext>();
            LoggerUtil.Info("Initializing Driver");
            _downloadUtil = _serviceProvider.GetRequiredService<DownloadUtils>();

            _objectContainer.RegisterInstanceAs(_driverContext);
            _objectContainer.RegisterInstanceAs(_downloadUtil);
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            var result = TestContext.CurrentContext.Result;
            TestHandler.TestFinished(result, _driverContext);

            _downloadUtil.EmptyDownloadsFolder();
            _driverContext.ReleaseDriver();
        }
    }
}
