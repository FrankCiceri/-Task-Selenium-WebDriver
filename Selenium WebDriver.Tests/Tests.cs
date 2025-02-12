using log4net.Config;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework.Interfaces;
using Selenium_WebDriver.Business.PageObjects;
using Selenium_WebDriver.Business.PageObjects.AboutPage;
using Selenium_WebDriver.Business.PageObjects.CareersPage;
using Selenium_WebDriver.Business.PageObjects.DetailPage;
using Selenium_WebDriver.Business.PageObjects.HeaderPage;
using Selenium_WebDriver.Business.PageObjects.InsightPage;
using Selenium_WebDriver.Business.PageObjects.JobPage;
using Selenium_WebDriver.Business.PageObjects.SearchPage;
using Selenium_WebDriver.Core.Core;
using Selenium_WebDriver.Core.Interfaces;
using Selenium_WebDriver.Core.Utils;
using Selenium_WebDriver.Tests.TestData;

namespace Selenium_WebDriver.Tests
{
    [TestFixture]
    public class Tests : TestBase
    {
        private IDriverContext _driverContext;
        private DownloadUtils downloadUtil;

        [SetUp]
        public void Setup()
        {
            LoggerUtil.InitializeLoggerUtil();
            this._driverContext = this.ServiceProvider.GetRequiredService<IDriverContext>();
            LoggerUtil.Info("Initializing Driver");
            this._driverContext.GoToUrl("https://www.epam.com/");
            this.downloadUtil = this.ServiceProvider.GetRequiredService<DownloadUtils>();
        }

        [TestCaseSource(typeof(TestDataLoader), nameof(TestDataLoader.LoadTestDataForTest1))]
        public void Test1(string programmingLanguage, string location)
        {
            var header = new HeaderPage(this._driverContext);
            header.ClickCareersLink();

            var careersPage = new CareerPage(this._driverContext);
            careersPage.EnterSearchKeyword(programmingLanguage);
            careersPage.SelectLocationFromDropdown(location);
            careersPage.ClickRemoteLabel();
            careersPage.ClickSearchButton();
            this._driverContext.AcceptCookies();
            careersPage.SortJobsByDate();
            careersPage.ApplyToFirstJob();

            var jobPage = new JobPage(this._driverContext);
            var result = jobPage.ValidateJobPageContains(programmingLanguage);
            Assert.That(result, Is.True);
        }

        [TestCaseSource(typeof(TestDataLoader),nameof(TestDataLoader.LoadTestDataForTest2))]
        public void Test2(string searchValue)
        {
            var header = new HeaderPage(this._driverContext);
            header.ClickHeaderMagnifier();
            this._driverContext.AcceptCookies();
            header.EnterHeaderPanelSearch(searchValue);
            header.ClickHeaderPanelSearchButton();

            var searchPage = new SearchPage(this._driverContext);
            var result = searchPage.ValidateLinksContain(searchValue);
            Assert.That(result, Is.True, $"Not all links contain the inputted word: {searchValue}");
        }

        [TestCase("EPAM_Corporate_Overview_Q4_EOY")]
        public void Test3(string fileName)
        {
            var header = new HeaderPage(this._driverContext);
            var aboutPage = new AboutPage(this._driverContext);

            header.ClickAboutLink();
            aboutPage.ScrollToAtAGlance();
            this._driverContext.AcceptCookies();
            aboutPage.ClickDownloadButton();

            bool isFileDownloaded = this.downloadUtil.WaitForFileDownload(fileName);

            Assert.That(isFileDownloaded, Is.True, $"File '{fileName}' was not downloaded.");
        }

        [TestCase(2)]
        public void Test4(int numSwipes)
        {
            var header = new HeaderPage(this._driverContext);
            var insightPage = new InsightPage(this._driverContext);
            var detailPage = new DetailPage(this._driverContext);

            header.ClickInsightsLink();
            insightPage.NextSlide(numSwipes);
            var carouselTitle = insightPage.GetCarouselCurrentActiveElementTitle();
            insightPage.ClickCarouselReadMore();

            var detailPageTitle = detailPage.GetHeaderTitleText();

            Assert.That(detailPageTitle, Is.EqualTo(carouselTitle));
        }

        [OneTimeTearDown]
        public void EndTest()
        {
            var result = TestContext.CurrentContext.Result;
            TestHandler.TestFinished(result, this._driverContext);

            this.downloadUtil.EmptyDownloadsFolder();
            this._driverContext.ReleaseDriver();
        }
    }
}