using OpenQA.Selenium;
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
        public SearchPage(DriverManager driverManager)
        {
            if (driverManager is null)
            {
                throw new ArgumentNullException(nameof(driverManager));
            }

            this.driverManager = driverManager;
            this.shortWait = driverManager.ShortWait;
            this.longWait = driverManager.LongWait;
        }


        public bool ValidateLinksContain(string searchString)
        {
            this.WaitSearchResults();

            var links = this.shortWait.WaitFindElements(this.searchResultLinksBy);
            var result = links.All(a => a.Text.Contains(searchString, StringComparison.InvariantCultureIgnoreCase));

            return result;
        }
    }
}
