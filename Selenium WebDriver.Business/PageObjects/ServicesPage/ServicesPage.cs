using OpenQA.Selenium;
using Selenium_WebDriver.Core.Core;
using Selenium_WebDriver.Core.Interfaces;

namespace Selenium_WebDriver.Business.PageObjects.ServicesPage
{
    public partial class ServicesPage
    {
        public ServicesPage(IDriverContext driverContext)
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

        public bool IsDisplayedOurExpertiseSection()
        {
            return OurExpertiseSection.Displayed;
        }
    }
}
