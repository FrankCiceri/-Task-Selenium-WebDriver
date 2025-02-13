using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_WebDriver.Business.PageObjects.JobPage
{
    public partial class JobPage
    {

        private readonly By _jobTitleBy = By.ClassName("vacancy-details-23__job-title");
        private readonly By _jobResponsabilitiesAndRequirementsBy = By.XPath("//*[not(preceding-sibling::h3[text()= 'We offer']) and contains(@class, 'vacancy-details-23__bullet-list') and contains(@class, 'bullet-list')]/li");

        private IWebElement JobTitle => _driverContext.GetDriver().FindElement(_jobTitleBy);
        private IEnumerable<IWebElement> JobResponsabilitiesAndRequirements => _driverContext.GetDriver().FindElements(_jobResponsabilitiesAndRequirementsBy);
    }
}
