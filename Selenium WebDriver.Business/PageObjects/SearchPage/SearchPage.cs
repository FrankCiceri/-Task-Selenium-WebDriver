using OpenQA.Selenium;
using Selenium_WebDriver.Core.Core;
using Selenium_WebDriver.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_WebDriver.Business.PageObjects.SearchPage
{
    public partial class SearchPage
    {
        public SearchPage(IDriverContext driverContext)
        {
            if (driverContext is null)
            {
                throw new ArgumentNullException(nameof(driverContext));
            }

            this._driverContext = driverContext;
        }

        //TODO:
        //This method should be on tests, and create methods to get the links
        public bool ValidateLinksContain(string searchString)
        {
            WaitSearchResults();
            this._driverContext.ShortWait.WaitFindElements(_searchResultLinksBy);
            var result = SearchResultLinks.All(a => a.Text.Contains(searchString, StringComparison.InvariantCultureIgnoreCase));

            return result;
        }

        public bool ValidateTextContain(string searchString)
        {
            WaitSearchResults();
            this._driverContext.ShortWait.WaitFindElements(_searchResultTextBy);
            var result = SearchResultTexts.All(a => a.Text.Contains(searchString, StringComparison.InvariantCultureIgnoreCase));

            return result;
        }
    }
}
