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

            this._driverContext = driverContext;
        }

        //TODO:
        //This method should be on tests, and create methods to get the links
        public bool ValidateJobPageContains(string expectedText)
        {
            _driverContext.LongWait.WaitUntilElementIsVisible(_jobTitleBy);

            if (JobTitle.Text.Contains(expectedText, StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }

            _driverContext.LongWait.WaitUntilElementIsVisible(_jobResponsabilitiesAndRequirementsBy);

            foreach (var li in JobResponsabilitiesAndRequirements)
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
