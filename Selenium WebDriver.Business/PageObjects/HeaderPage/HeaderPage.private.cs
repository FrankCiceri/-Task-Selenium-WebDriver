using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium_WebDriver.Core.Core;
using Selenium_WebDriver.Core.Interfaces;

namespace Selenium_WebDriver.Business.PageObjects.HeaderPage
{
    public partial class HeaderPage
    {
        private readonly IDriverContext _driverContext;

        private void WaitHeaderSearchPanelToDeploy()
        {
            this._driverContext.LongWait.WaitUntilElementExists(_headerSearchPanelBy);
        }
    }
}
