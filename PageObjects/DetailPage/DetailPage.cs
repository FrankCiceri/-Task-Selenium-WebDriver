using Selenium_WebDriver.DriverUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_WebDriver.PageObjects.DetailPage
{
    public partial class DetailPage
    {
        public DetailPage(DriverManager driverManager)
        {
            if (driverManager is null)
            {
                throw new ArgumentNullException(nameof(driverManager));
            }

            this.driverManager = driverManager;
            this.shortWait = driverManager.ShortWait;
            this.longWait = driverManager.LongWait;
        }

        public string GetHeaderTitleText()
        {
            var titleElement = this.shortWait.WaitUntilElementIsVisible(this.detailHeaderTitleBy);
            return titleElement.Text;
        }
    }
}
