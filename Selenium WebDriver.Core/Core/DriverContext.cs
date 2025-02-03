using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Selenium_WebDriver.Core.Interfaces;

namespace Selenium_WebDriver.Core.Core
{
    public class DriverContext
    {
        private static DriverContext? instance;
        private readonly WebDriverWait shortWait;
        private readonly WebDriverWait longWait;
        private readonly IWebDriver driver;

        private DriverContext(IDriverFactory driverFactory, IWaitFactory waitFactory)
        {
            this.driver = driverFactory.CreateDriver();
            this.driver.Manage().Window.Maximize();

            this.shortWait = waitFactory.CreateShortWait(this.driver);
            this.longWait = waitFactory.CreateLongWait(this.driver);
        }

        public static DriverContext Instance
        {
            get
            {
                if (instance == null)
                {
                    throw new InvalidOperationException("DriverContext has not been initialized. Call Initialize first.");
                }

                return instance;
            }
        }

        public static void Initialize(IDriverFactory driverFactory, IWaitFactory waitFactory)
        {
            if (instance == null)
            {
                instance = new DriverContext(driverFactory, waitFactory);
            }
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

            this.driver.Navigate().GoToUrl(url);
        }

        public void ReleaseDriver()
        {
            if (this.driver != null)
            {
                this.driver.Quit();
            }
        }
    }
}
