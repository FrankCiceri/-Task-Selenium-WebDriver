using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using Selenium_WebDriver.Core.Interfaces;

namespace Selenium_WebDriver.Core.Core
{
    public class DriverFactory : IDriverFactory
    {
        public IWebDriver CreateDriver(string downloadDirectory = "C:\\Downloads")
        {
            var browser = TestContext.Parameters["driver"] ?? "chrome";
            var headless = bool.Parse(TestContext.Parameters["headless"] ?? "false");
            switch (browser.ToLower())
            {
                case "chrome":
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddUserProfilePreference("download.default_directory", downloadDirectory);
                    if (headless)
                    {
                        chromeOptions.AddArgument(DriverHeadless.GetChromeParameter());
                    }

                    return new ChromeDriver(chromeOptions);
                case "msedge":
                    var edgeOptions = new EdgeOptions();
                    edgeOptions.AddUserProfilePreference("download.default_directory", downloadDirectory);

                    if (headless)
                    {
                        edgeOptions.AddArgument(DriverHeadless.GetEdgeParameter());
                    }

                    return new EdgeDriver(edgeOptions);
                case "firefox":
                    var firefoxOptions = new FirefoxOptions();
                    firefoxOptions.AddAdditionalOption("download.default_directory", downloadDirectory);

                    if (headless)
                    {
                        firefoxOptions.AddArgument(DriverHeadless.GetFirefoxParameter());
                    }

                    return new FirefoxDriver(firefoxOptions);
                default:
                    throw new NotSupportedException($"Unsupported browser: {browser}, check .runsettings");
            }
        }
    }
}
