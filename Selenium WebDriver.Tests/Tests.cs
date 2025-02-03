using Selenium_WebDriver.Business.PageObjects;
using Selenium_WebDriver.Business.PageObjects.AboutPage;
using Selenium_WebDriver.Business.PageObjects.CareersPage;
using Selenium_WebDriver.Business.PageObjects.DetailPage;
using Selenium_WebDriver.Business.PageObjects.HeaderPage;
using Selenium_WebDriver.Business.PageObjects.InsightPage;
using Selenium_WebDriver.Business.PageObjects.JobPage;
using Selenium_WebDriver.Core.Core;
using Selenium_WebDriver.Core.Utils;

using Selenium_WebDriver.PageObjects.SearchPage;

namespace Selenium_WebDriver.Tests
{
    public class Tests
    {
        private DriverContext driverContext;
        private DownloadUtils downloadUtil;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            this.driverContext = DriverContext.Instance; 
        }

        [SetUp]
        public void Setup()
        {
            this.driverContext.GoToUrl("https://www.epam.com/");
            this.downloadUtil = new DownloadUtils();
        }

        [TestCase("Java", "All Locations")]
        [TestCase("Python", "All Locations")]
        [TestCase("C#", "All Locations")]
        public void Test1(string programmingLanguage, string location)
        {
            var header = new HeaderPage(this.driverContext);
            header.ClickCareersLink();

            var careersPage = new CareerPage(this.driverContext);
            careersPage.EnterSearchKeyword(programmingLanguage);
            careersPage.SelectLocationFromDropdown(location);
            careersPage.ClickRemoteLabel();
            careersPage.ClickSearchButton();
            this.driverContext.AcceptCookies();
            careersPage.SortJobsByDate();
            careersPage.ApplyToFirstJob();

            var jobPage = new JobPage(this.driverContext);
            var result = jobPage.ValidateJobPageContains(programmingLanguage);
            Assert.That(result, Is.True);
        }

        [TestCase("Automation")]
        [TestCase("Cloud")]
        [TestCase("BLOCKCHAIN")]
        public void Test2(string searchValue)
        {
            var header = new HeaderPage(this.driverContext);
            header.ClickHeaderMagnifier();
            header.WaitHeaderSearchPanelToDeploy();
            this.driverContext.AcceptCookies();
            header.EnterHeaderPanelSearch(searchValue);
            header.ClickHeaderPanelSearchButton();

            var searchPage = new SearchPage(this.driverContext);
            var result = searchPage.ValidateLinksContain(searchValue);
            Assert.That(result, Is.True, $"Not all links contain the inputted word: {searchValue}");
        }

        [TestCase("EPAM_Corporate_Overview_Q4_EOY")]
        public void Test3(string fileName)
        {
            var header = new HeaderPage(this.driverContext);
            var aboutPage = new AboutPage(this.driverContext);

            header.ClickAboutLink();
            aboutPage.ScrollToAtAGlance();
            this.driverContext.AcceptCookies();
            aboutPage.ClickDownloadButton();

            bool isFileDownloaded = this.downloadUtil.WaitForFileDownload(fileName);

            Assert.IsTrue(isFileDownloaded, $"File '{fileName}' was not downloaded.");
        }

        [TestCase(2)]
        public void Test4(int numSwipes)
        {
            var header = new HeaderPage(this.driverContext);
            var insightPage = new InsightPage(this.driverContext);
            var detailPage = new DetailPage(this.driverContext);

            header.ClickInsightsLink();
            insightPage.SwipeFirstCarouselNTimes(numSwipes);
            var carouselTitle = insightPage.GetCarouselCurrentActiveElementText();
            insightPage.ClickCarouselReadMore();

            var detailPageTitle = detailPage.GetHeaderTitleText();

            Assert.That(detailPageTitle, Is.EqualTo(carouselTitle));
        }

        [TearDown]
        public void EndTest()
        {
            this.downloadUtil.EmptyDownloadsFolder();
            this.driverContext.ReleaseDriver();
        }
    }
}