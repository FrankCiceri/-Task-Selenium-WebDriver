using OpenQA.Selenium.Interactions;
using Selenium_WebDriver.Core.Core;
using Selenium_WebDriver.Core.Interfaces;
using Selenium_WebDriver.Core.Utils;

namespace Selenium_WebDriver.Business.PageObjects.HeaderPage
{
    public partial class HeaderPage
    {
        public HeaderPage(IDriverContext driverContext)
        {
            if (driverContext is null)
            {
                throw new ArgumentNullException(nameof(driverContext));
            }

            this._driverContext = driverContext;
        }

        public void ClickCareersLink()
        {
            try
            {
                _driverContext.LongWait.WaitUntilElementIsClickable(_headerCareersButtonBy);
                CareersButton.Click();
                LoggerUtil.Info("Clicked on Careers link.");
            }
            catch (Exception ex)
            {
                LoggerUtil.Error("Failed to click on Careers link.", _headerCareersButtonBy, ex);
                throw;
            }
        }

        public void HoverServicesLink()
        {
            try
            {
                _driverContext.LongWait.WaitUntilElementIsVisible(_headerServicesButton);
                _driverContext.LongWait.WaitUntilElementIsClickable(_headerServicesButton);

                new Actions(_driverContext.GetDriver())
                    .MoveToElement(ServicesButton)
                    .Pause(TimeSpan.FromSeconds(1))
                    .Perform();
                LoggerUtil.Info("Moved to Services link.");
            }
            catch (Exception ex)
            {
                LoggerUtil.Error("Failed to move to Services link.", _headerServicesButton, ex);
                throw;
            }
        }

        public void ClickServiceMenuItem(string service)
        {
            try
            {
                if (_driverContext.IsElementVisible(_headerServicesDropdownItems))
                {
                    var serviceElement = GetServiceItem(service);

                    serviceElement.Click();
                }
            }
            catch (Exception ex)
            {
                LoggerUtil.Error("Failed to click Service item", ex);
                throw;
            }
        }

        public void ClickAboutLink()
        {
            try
            {
                _driverContext.LongWait.WaitUntilElementIsClickable(_headerAboutButtonBy);
                AboutButton.Click();
                LoggerUtil.Info("Clicked on About link.");
            }
            catch (Exception ex)
            {
                LoggerUtil.Error("Failed to click on About link.", _headerAboutButtonBy, ex);
                throw;
            }
        }

        public void ClickInsightsLink()
        {
            try
            {
                _driverContext.LongWait.WaitUntilElementIsClickable(_headerInsightsButtonBy);
                InsightsButton.Click();
                LoggerUtil.Info("Clicked on Insights link.");
            }
            catch (Exception ex)
            {
                LoggerUtil.Error("Failed to click on Insights link.", _headerInsightsButtonBy, ex);
                throw;
            }
        }

        public void ClickHeaderMagnifier()
        {
            try
            {
                _driverContext.LongWait.WaitUntilElementIsClickable(_headerMagnifierBy);
                MagnifierButton.Click();
                LoggerUtil.Info("Clicked on Header Magnifier.");
                WaitHeaderSearchPanelToDeploy();
            }
            catch (Exception ex)
            {
                LoggerUtil.Error("Failed to click on Header Magnifier.", _headerMagnifierBy, ex);
                throw;
            }
        }

        public void EnterHeaderPanelSearch(string searchString)
        {
            try
            {
                _driverContext.ShortWait.WaitUntilElementIsClickable(_headerSearchTextfieldBy);
                this._driverContext.GoToElementAndClick(SearchTextField);

                new Actions(this._driverContext.GetDriver())
                    .Pause(TimeSpan.FromSeconds(1))
                    .SendKeys(searchString)
                    .Perform();
            }
            catch (Exception ex)
            {
                LoggerUtil.Error("Failed to enter search on Header SearchPanel.", _headerMagnifierBy, ex);
                throw;
            }
        }

        public void ClickHeaderPanelSearchButton()
        {
            _driverContext.ShortWait.WaitUntilElementIsClickable(_headerPanelFindButtonBy);
            FindButton.Click();
        }
    }
}
