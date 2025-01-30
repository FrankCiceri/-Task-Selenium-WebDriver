using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V130.Debugger;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Selenium_WebDriver.DriverUtils;
using Selenium_WebDriver.PageObjects;
using Selenium_WebDriver.PageObjects.CareersPage;
using Selenium_WebDriver.PageObjects.JobPage;
using SeleniumExtras.WaitHelpers;
using Task__Selenium_WebDriver;

namespace Selenium_WebDriver
{
    public class Tests
    {
        private DriverManager driverManager;
        private HelpingMethods helper;

        [SetUp]
        public void Setup()
        {
            this.driverManager = new DriverManager();
            this.driverManager.GoToUrl("https://www.epam.com/");
        }

        [TestCase("Java", "All Locations")]
        [TestCase("Python", "All Locations")]
        [TestCase("C#", "All Locations")]
        public void Test1(string programmingLanguage, string location)
        {
            var header = new HeaderPage(this.driverManager);
            header.ClickCareersLink();

            var careersPage = new CareerPage(this.driverManager);
            careersPage.PerformJobSearch(programmingLanguage, location);
            this.driverManager.AcceptCookies();
            careersPage.SortJobsByDate();
            careersPage.ApplyToFirstJob();

            var jobPage = new JobPage(this.driverManager);
            var result = jobPage.ValidateJobPageContains(programmingLanguage);
            Assert.That(result ,Is.True);
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
            driverManager.ReleaseDriver();
        }
    }
}