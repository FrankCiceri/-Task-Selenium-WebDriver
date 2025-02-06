using OpenQA.Selenium;
using Selenium_WebDriver.Core.Core;
using Selenium_WebDriver.Core.Interfaces;

namespace Selenium_WebDriver.Business.PageObjects.ServicesPage
{
    public partial class ServicePage
    {
        public ServicePage(IDriverContext driverContext)
        {
            if (driverContext is null)
            {
                throw new ArgumentNullException(nameof(driverContext));
            }

            _driverContext = driverContext;
        }

        public string GetServicePageTitle()
        {
            return ServiceTitle.Text;
        }

        public IWebElement GetOurExpertiseSection()
        {
            return OurExpertiseSection;
        }
    }
}
