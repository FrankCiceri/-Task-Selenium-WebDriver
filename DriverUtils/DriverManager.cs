using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webdriver_task_3.DriverAddition
{
        
    public class DriverManager
    {
        protected readonly IWebDriver driver;
        public WebDriverWait shortWait;
        public WebDriverWait longWait;

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


            shortWait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(3))
            {
                PollingInterval = TimeSpan.FromSeconds(0.25)
            };

            longWait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromSeconds(0.5)
            };

            this.driver.Manage().Window.Maximize();
        }


        public IWebDriver GetDriver()
        {
            return this.driver;
        }

        public void GoToUrl(string url)
        {
            if (string.IsNullOrEmpty(url)) { throw new ArgumentNullException(nameof(url), "url is empty or null"); }

            this.driver.Navigate().GoToUrl(url);
        }

        public void ReleaseDriver()
        {
            this.driver.Close();
            this.driver.Dispose();
        }

              

    }
}
