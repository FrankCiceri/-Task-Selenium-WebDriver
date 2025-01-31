using Selenium_WebDriver.DriverUtils;
using Selenium_WebDriver.PageObjects;
using Selenium_WebDriver.PageObjects.CareersPage;
using Selenium_WebDriver.PageObjects.DetailPage;
using Selenium_WebDriver.PageObjects.InsightPage;
using Selenium_WebDriver.PageObjects.JobPage;
using Selenium_WebDriver.PageObjects.SearchPage;
using Selenium_WebDriver.Utils;


namespace Selenium_WebDriver
{
    public class Tests
    {
        private readonly string downloadDirectory = "C:\\Downloads";
        private DriverManager driverManager;
        private DownloadUtils downloadUtil;

        [SetUp]
        public void Setup()
        {
            this.driverManager = new DriverManager(this.downloadDirectory);
            this.driverManager.GoToUrl("https://www.epam.com/");
            this.downloadUtil = new DownloadUtils(this.downloadDirectory);
        }

        [TestCase("Java", "All Locations")]
        [TestCase("Python", "All Locations")]
        [TestCase("C#", "All Locations")]
        public void Test1(string programmingLanguage, string location)
        {
            var header = new HeaderPage(this.driverManager);
            header.ClickCareersLink();

            var careersPage = new CareerPage(this.driverManager);
            careersPage.EnterSearchKeyword(programmingLanguage);
            careersPage.SelectLocationFromDropdown(location);
            careersPage.ClickRemoteLabel();
            careersPage.ClickSearchButton();
            this.driverManager.AcceptCookies();
            careersPage.SortJobsByDate();
            careersPage.ApplyToFirstJob();

            var jobPage = new JobPage(this.driverManager);
            var result = jobPage.ValidateJobPageContains(programmingLanguage);
            Assert.That(result, Is.True);
        }

        [TestCase("Automation")]
        [TestCase("Cloud")]
        [TestCase("BLOCKCHAIN")]
        public void Test2(string searchValue)
        {
            var header = new HeaderPage(this.driverManager);
            header.ClickHeaderMagnifier();
            header.WaitHeaderSearchPanelToDeploy();
            this.driverManager.AcceptCookies();
            header.EnterHeaderPanelSearch(searchValue);
            header.ClickHeaderPanelSearchButton();

            var searchPage = new SearchPage(this.driverManager);
            var result = searchPage.ValidateLinksContain(searchValue);
            Assert.That(result, Is.True, $"Not all links contain the inputted word: {searchValue}");
        }

        [TestCase("EPAM_Corporate_Overview_Q4_EOY")]
        public void Test3(string fileName)
        {
            var header = new HeaderPage(this.driverManager);
            var aboutPage = new AboutPage(this.driverManager);

            header.ClickAboutLink();
            aboutPage.ScrollToAtAGlance();
            this.driverManager.AcceptCookies();
            aboutPage.ClickDownloadButton();

            bool isFileDownloaded = this.downloadUtil.WaitForFileDownload(fileName);

            Assert.IsTrue(isFileDownloaded, $"File '{fileName}' was not downloaded.");
        }

        [TestCase(2)]
        public void Test4(int numSwipes)
        {
            var header = new HeaderPage(this.driverManager);
            var insightPage = new InsightPage(this.driverManager);
            var detailPage = new DetailPage(this.driverManager);

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
            this.driverManager.ReleaseDriver();
        }
    }
}