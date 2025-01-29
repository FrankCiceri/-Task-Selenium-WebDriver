using OpenQA.Selenium;
using Selenium_WebDriver.DriverUtils;
using SeleniumExtras.WaitHelpers;
using Task__Selenium_WebDriver.DriverUtils;
using static webdriver_task_3.ExtraClass.ArgumentChecker;

namespace Task__Selenium_WebDriver.PageObjects
{
    public partial class HeaderPage
    {
        public HeaderPage(DriverManager driverManager)
        {
            if (driverManager is null)
            {
                throw new ArgumentNullException(nameof(driverManager));
            }

            this.driverManager = driverManager;
            this.shortWait = driverManager.ShortWait;
            this.longWait = driverManager.LongWait;
        }

        public void ClickCareersLink()
        {
            var careersButton = this.longWait.WaitUntilElementIsClickable(this.headerCareersButtonBy);
            careersButton.Click();
        }
    }
}
