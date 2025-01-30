using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_WebDriver.PageObjects.JobPage
{
    public partial class JobPage
    {
        private static readonly string JobTitleLocator = "vacancy-details-23__job-title";
        private static readonly string TextJobBy = "//*[not(preceding-sibling::h3[text()= 'We offer']) and contains(@class, 'vacancy-details-23__bullet-list') and contains(@class, 'bullet-list')]/li";

        private readonly By jobTitleBy = By.ClassName(JobTitleLocator);
        private readonly By jobResponsabilitiesAndRequirementsBy = By.XPath(TextJobBy);
    }
}
