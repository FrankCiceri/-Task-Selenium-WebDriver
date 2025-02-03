using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Selenium_WebDriver.Core.Core;
using Selenium_WebDriver.Core.Interfaces;

namespace Selenium_WebDriver.Business.PageObjects.JobPage
{
    public partial class JobPage
    {
        public JobPage(IDriverContext driverContext)
        {
            if (driverContext is null)
            {
                throw new ArgumentNullException(nameof(driverContext));
            }

            this.driverContext = driverContext;
        }

        public bool ValidateJobPageContains(string expectedText)
        {
            var titleElement = this.driverContext.LongWait.WaitUntilElementIsVisible(this.jobTitleBy);

            if (titleElement.Text.Contains(expectedText, StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }

            var listOfRequirementElements = this.driverContext.LongWait.WaitFindElements(this.jobResponsabilitiesAndRequirementsBy);

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
