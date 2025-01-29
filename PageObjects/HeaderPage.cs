using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webdriver_task_3.DriverAddition;

namespace _Task__Selenium_WebDriver.PageObjects
{
    public partial class HeaderPage
    {

        public HeaderPage(DriverManager driverManager) 
        { 
            this.driver = driverManager;
        }

        public void ClickCareersLink()
        {
            var careersButton = driver.longWait.Until(ExpectedConditions.ElementToBeClickable(
                By.XPath("//span/a[text()='Careers']")
            ));
            careersButton.Click();
        }

    }
}
