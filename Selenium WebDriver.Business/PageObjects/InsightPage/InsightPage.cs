using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Selenium_WebDriver.Core.Core;
using Selenium_WebDriver.Core.Interfaces;
using Selenium_WebDriver.Core.Utils;

namespace Selenium_WebDriver.Business.PageObjects.InsightPage
{
    public partial class InsightPage
    {
        public InsightPage(IDriverContext driverContext)
        {
            if (driverContext is null)
            {
                throw new ArgumentNullException(nameof(driverContext));
            }

            this._driverContext = driverContext;
        }

        public void NextSlide(int numberOfSwipes)
        {
            var currentSlide = CurrentActiveSlide;
            for (int i = 0; i < numberOfSwipes; i++)
            {
                ClickNextSlideButton();

                this._driverContext.ShortWait.Until(d => !currentSlide.GetAttribute("class").Contains("active"));
                currentSlide = CurrentActiveSlide;
            }
        }

        public string GetCarouselCurrentActiveElementTitle()
        {
            try
            {
                _driverContext.ShortWait.WaitUntilElementIsVisible(_insightCarouselTitleBy);
                var title = CurrentActiveSlideTitle.Text;
                LoggerUtil.Info($"Obtained Current Slide Title: {title}");

                return title;
            }
            catch (Exception ex)
            {
                LoggerUtil.Error("Failed to retrieve the current slide title in the carousel.", ex);
                throw;
            }
        }

        public void ClickCarouselReadMore()
        {
            try
            {
                _driverContext.ShortWait.WaitUntilElementIsClickable(_insightFirstCarouselReadMoreBy);

                CurrentActiveSlideReadMoreButton.Click();

                LoggerUtil.Info("Clicked on 'Read More' button in the carousel.");
            }
            catch (Exception ex)
            {
                LoggerUtil.Error("Failed to click on 'Read More' button in the carousel.", ex);
                throw;
            }
        }
    }
}
