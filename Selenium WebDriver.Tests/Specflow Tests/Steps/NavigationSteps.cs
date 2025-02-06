using Selenium_WebDriver.Core.Interfaces;
using Selenium_WebDriver.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Selenium_WebDriver.Tests.Specflow_Tests.Steps
{
    [Binding]
    public class NavigationSteps
    {
        private readonly IDriverContext _driverContext;

        public NavigationSteps(IDriverContext driverContext)
        {
            _driverContext = driverContext;
        }

        [Given(@"I am on the EPAM homepage")]
        public void GivenIAmOnTheEPAMHomepage()
        {
            _driverContext.GoToUrl("https://www.epam.com/");
        }
    }
}
