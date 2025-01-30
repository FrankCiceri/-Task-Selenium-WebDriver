using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Selenium_WebDriver.DriverUtils
{
    public class DriverManager
    {
        private readonly WebDriverWait shortWait;
        private readonly WebDriverWait longWait;

        private readonly IWebDriver driver;

        public DriverManager()
        {
            var browser = "chrome";
            switch (browser.ToLower())
            {
                case "chrome":
                    var chromeOptions = new ChromeOptions();
                    this.driver = new ChromeDriver(chromeOptions);
                    break;
                default:
                    throw new NotSupportedException($"Unsupported browser: {browser}, check .runsettings");
            }

            this.shortWait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(3))
            {
                PollingInterval = TimeSpan.FromSeconds(0.25),
            };

            this.longWait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromSeconds(0.5),
            };

            this.driver.Manage().Window.Maximize();
        }

        public WebDriverWait LongWait => this.longWait;

        public WebDriverWait ShortWait => this.shortWait;

        public IWebDriver GetDriver()
        {
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
            this.driver.Close();
            this.driver.Dispose();
        }
    }
}
