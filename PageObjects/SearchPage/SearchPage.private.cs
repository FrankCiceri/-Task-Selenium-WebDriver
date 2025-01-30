using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium_WebDriver.DriverUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_WebDriver.PageObjects.SearchPage
{
    public partial class SearchPage
    {
        private readonly DriverManager driverManager;
        private WebDriverWait shortWait;
        private WebDriverWait longWait;

        private void WaitSearchResults()
        {
            this.longWait.Until(driver =>
            {
                var divResults = driver.FindElement(this.searchResultBy);
                var elementsInsideDiv = divResults.FindElements(this.searchResultArticleBy);
                return elementsInsideDiv.Count > 0;
            });
        }
    }
}
