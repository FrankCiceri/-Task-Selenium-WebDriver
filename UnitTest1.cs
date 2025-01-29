using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V130.Debugger;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace Task__Selenium_WebDriver
{
    public class Tests
    {
        private IWebDriver driver;
        private HelpingMethods helper;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(); 
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.epam.com/");
            helper = new HelpingMethods(driver);
        }

        [TestCase("Java", "All Locations")]
        [TestCase("Python", "All Locations")]
        [TestCase("C#", "All Locations")]
        public void Test1(string programmingLanguage, string location)
        {
            helper.ClickCareersLink();
            helper.AcceptCookies();
            helper.PerformJobSearch(programmingLanguage, location);
            helper.SortJobsByDate();
            helper.ApplyToFirstJob();
            var result = helper.ValidateJobPageContains(programmingLanguage);
            Assert.That(result , Is.True);
        }

        [TestCase("Automation")]
        [TestCase("Cloud")]
        [TestCase("BLOCKCHAIN")]
        public void Test2(string searchValue)
        {            
            helper.ClickMainPageMagnifier();
            helper.WaitMainPageSearchPanelToDeploy();
            helper.AcceptCookies();
            helper.EnterMainPageSearch(searchValue);
            helper.ClickMainPageSearchButton();
            var result = helper.ValidateLinksContain(searchValue);
            Assert.That(result, Is.True, $"Not all links contain the inputted word: {searchValue}");
        }

        [TearDown]
        public void EndTest()
        {
            driver?.Quit();
            driver?.Dispose();
        }
    }
}