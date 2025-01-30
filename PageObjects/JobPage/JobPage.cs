using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Selenium_WebDriver.DriverUtils;

namespace Selenium_WebDriver.PageObjects.JobPage
{
    public partial class JobPage
    {
        public JobPage(DriverManager driverManager)
        {
            if (driverManager is null)
            {
                throw new ArgumentNullException(nameof(driverManager));
            }

            this.driverManager = driverManager;
            this.shortWait = driverManager.ShortWait;
            this.longWait = driverManager.LongWait;
        }

        public bool ValidateJobPageContains(string expectedText)
        {
            var titleElement = this.longWait.WaitUntilElementIsVisible(this.jobTitleBy);

            if (titleElement.Text.Contains(expectedText, StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }

            var listOfRequirementElements = this.longWait.WaitFindElements(this.jobResponsabilitiesAndRequirementsBy);

            foreach (var li in listOfRequirementElements)
            {
                if (li.Text.Contains(expectedText, StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
