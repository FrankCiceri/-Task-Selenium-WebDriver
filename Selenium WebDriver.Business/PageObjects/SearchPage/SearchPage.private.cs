using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium_WebDriver.Core.Core;
using Selenium_WebDriver.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_WebDriver.PageObjects.SearchPage
{
    public partial class SearchPage
    {
        private readonly IDriverContext driverContext;

        private void WaitSearchResults()
        {
            this.driverContext.LongWait.Until(driver =>
            {
                var divResults = driver.FindElement(this.searchResultBy);
                var elementsInsideDiv = divResults.FindElements(this.searchResultArticleBy);
                return elementsInsideDiv.Count > 0;
            });
        }
    }
}
