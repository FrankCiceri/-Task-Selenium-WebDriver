using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Selenium_WebDriver.Core.Interfaces;
using Selenium_WebDriver.Core.Utils;

namespace Selenium_WebDriver.Core.Core
{
    public class DriverContext : IDriverContext
    {
        private readonly WebDriverWait shortWait;
        private readonly WebDriverWait longWait;
        private readonly IWebDriver driver;

        public DriverContext(IDriverFactory driverFactory, IWaitFactory waitFactory)
        {
            this.driver = driverFactory.CreateDriver();
            this.driver.Manage().Window.Maximize();

            this.shortWait = waitFactory.CreateShortWait(this.driver);
            this.longWait = waitFactory.CreateLongWait(this.driver);
        }

        public WebDriverWait LongWait => this.longWait;

        public WebDriverWait ShortWait => this.shortWait;

        public IWebDriver GetDriver()
        {
            if (this.driver == null)
            {
                throw new InvalidOperationException("WebDriver has not been initialized");
            }

            return this.driver;
        }

        public void GoToUrl(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException(nameof(url), "url is empty or null");
            }

            LoggerUtil.Info($"Navigating to {url}");
            this.driver.Navigate().GoToUrl(url);
        }

        public void ReleaseDriver()
        {
            if (this.driver != null)
            {
                LoggerUtil.Info($"Stopping Driver Execution");
                this.driver.Quit();
                LoggerUtil.Info($"Driver Execution Stopped");
            }
        }
    }
}
