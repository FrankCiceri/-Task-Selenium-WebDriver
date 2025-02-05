using Selenium_WebDriver.Core.Core;
using Selenium_WebDriver.Core.Interfaces;
using Selenium_WebDriver.Core.Utils;
using static Selenium_WebDriver.Core.ExtraClass.ArgumentChecker;

namespace Selenium_WebDriver.Business.PageObjects.CareersPage
{
    public partial class CareerPage
    {
        public CareerPage(IDriverContext driverContext)
        {
            if (driverContext is null)
            {
                throw new ArgumentNullException(nameof(driverContext));
            }

            this._driverContext = driverContext;
        }

        public void EnterSearchKeyword(string keyword)
        {
            CheckArgumentIsNull(keyword, nameof(keyword));
            try
            {
                SearchKeywordField.SendKeys(keyword);
                CloseSuggestionsMenuIfVisible();
                LoggerUtil.Info($"Entered {keyword} into SearchTextField");
            }
            catch (Exception ex)
            {
                LoggerUtil.Error("Failed to Enter text into SearchTextField", _careerSearchTextFieldBy, ex);

                throw;
            }
        }

        public void SelectLocationFromDropdown(string location)
        {
            CheckArgumentIsNull(location, nameof(location));
            DeployLocationDropdown();
            SelectDropdownLocation(location);
        }

        public void ClickRemoteLabel()
        {
            try
            {
                _driverContext.ShortWait.WaitUntilElementIsClickable(_careerRemoteLabelBy);
                RemoteLabel.Click();
                LoggerUtil.Info($"Clicked on RemoteLabel");
            }
            catch (Exception ex)
            {
                LoggerUtil.Error("Failed to Click on RemoteLabel", _careerSearchTextFieldBy, ex);

                throw;
            }
        }

        public void ClickSearchButton()
        {
            try
            {
                _driverContext.ShortWait.WaitUntilElementIsClickable(_careerSearchButtonBy);
                SearchButton.Click();
                LoggerUtil.Info($"Clicked on SearchButton");
            }
            catch (Exception ex)
            {
                LoggerUtil.Error("Failed to Click on SearchButton", _careerSearchButtonBy, ex);

                throw;
            }
        }

        public void SortJobsByDate()
        {
            this._driverContext.LongWait.WaitUntilElementIsClickable(_careerDateFilterButtonBy);
            this._driverContext.GoToElementAndClick(DateFilterButton);

            _driverContext.ShortWait.WaitUntilAttributeContains(_careerPreloaderBy, "style", "display: block;");
            _driverContext.ShortWait.WaitUntilAttributeContains(_careerPreloaderBy, "style", "display: none;");
        }

        public void ApplyToFirstJob()
        {
            this._driverContext.LongWait.WaitUntilElementIsClickable(_careerFirstResultBy);
            this._driverContext.GoToElement(FirstResult);

            this._driverContext.LongWait.WaitUntilElementIsClickable(_careerFirstResultApplyBy);
            this._driverContext.GoToElementAndClick(FirstResultApplyButton);
        }
    }
}