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

            this.driverContext = driverContext;
        }

        public bool ValidateLinksContain(string searchString)
        {
            this.WaitSearchResults();

            var links = this.driverContext.ShortWait.WaitFindElements(this.searchResultLinksBy);
            var result = links.All(a => a.Text.Contains(searchString, StringComparison.InvariantCultureIgnoreCase));

            return result;
        }
    }
}
