using Selenium_WebDriver.Core.Core;
using Selenium_WebDriver.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_WebDriver.Business.PageObjects.DetailPage
{
    public partial class DetailPage
    {
        public DetailPage(IDriverContext driverContext)
        {
            if (driverContext is null)
            {
                throw new ArgumentNullException(nameof(driverContext));
            }

            this.driverContext = driverContext;
        }

        public string GetHeaderTitleText()
        {
            var titleElement = this.driverContext.ShortWait.WaitUntilElementIsVisible(this.detailHeaderTitleBy);
            return titleElement.Text;
        }
    }
}
