using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium_WebDriver.Core.Core;
using Selenium_WebDriver.Core.Interfaces;
using Selenium_WebDriver.Core.Utils;

namespace Selenium_WebDriver.Business.PageObjects.CareersPage
{
    public partial class CareerPage
    {
        private readonly IDriverContext _driverContext;

        private IWebElement SelectLocation(string location)
        {
            string locationLocator = $"//li[contains(text(), '{location}')]";
            By locationBy = By.XPath(locationLocator);
            return _driverContext.GetDriver().FindElement(locationBy);
        }

        private void CloseSuggestionsMenuIfVisible()
        {
            if (_driverContext.IsElementVisible(_careerSuggestionsMenuBy))
            {
                _driverContext.ActionPressEscape();
            }
        }

        private void DeployLocationDropdown()
        {
            try
            {
                _driverContext.ShortWait.WaitUntilElementIsClickable(_careerLocationDropdownBy);
                LocationDropdown.Click();
                LoggerUtil.Info("Clicked on Location Dropdown to deploy");
            }
            catch (Exception ex)
            {
                LoggerUtil.Error("Failed to Deploy Location Dropdown", _careerLocationDropdownBy, ex);
                throw;
            }
        }

        private void SelectDropdownLocation(string location)
        {
            try
            {
                var selectedLocationElement = SelectLocation(location);
                selectedLocationElement.Click();
                LoggerUtil.Info($"Clicked on {location} Location from Dropdown");
            }
            catch (Exception ex)
            {
                LoggerUtil.Error("Failed to Deploy Location Dropdown", _careerLocationDropdownBy, ex);
                throw;
            }
        }
    }
}
