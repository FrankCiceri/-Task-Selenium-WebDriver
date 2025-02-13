using log4net.Repository.Hierarchy;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium_WebDriver.Core.Core;
using Selenium_WebDriver.Core.Interfaces;
using Selenium_WebDriver.Core.Utils;

namespace Selenium_WebDriver.Business.PageObjects.HeaderPage
{
    public partial class HeaderPage
    {
        private readonly IDriverContext _driverContext;

        private void WaitHeaderSearchPanelToDeploy()
        {
            this._driverContext.LongWait.WaitUntilElementExists(_headerSearchPanelBy);
        }

        private IWebElement? GetServiceItem(string service)
        {
            try
            {
                var serviceElement = ServicesDropdownItems.FirstOrDefault(elem => elem.Text.Trim().Equals(service.Trim(), StringComparison.InvariantCultureIgnoreCase));
                return serviceElement;
            }
            catch (Exception ex)
            {
                LoggerUtil.Error("Service Name not found", ex);

                throw;
            }
        }
    }
}
