using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Selenium_WebDriver.Core.Core;
using Selenium_WebDriver.Core.Interfaces;

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

            this.driverContext = driverContext;
        }

        public void SwipeFirstCarouselNTimes(int numberOfSwipes)
        {
            var activeSlide = this.WaitCarouselToBeClickable();
            var actions = new Actions(this.driverContext.GetDriver());
            var slider = activeSlide.FindElement(By.XPath("//div[contains(@class, 'media-content')]//div[contains(@class, 'owl-item active')]//img[contains(@class, 'single-slide__image')]"));
            for (int i = 0; i < numberOfSwipes; i++)
            {
                actions.ClickAndHold(slider)
                       .MoveByOffset(-100, 0)
                       .Release()
                       .Perform();

                this.driverContext.ShortWait.Until(d => !activeSlide.GetAttribute("class").Contains("active"));

                activeSlide = this.WaitCarouselToBeClickable();
            }
        }

        public string GetCarouselCurrentActiveElementText()
        {
            var carouselCurrentActiveElement = this.driverContext.ShortWait.WaitUntilElementIsVisible(this.insightCarouselCurrentActiveTextBy);
            return carouselCurrentActiveElement.Text;
        }

        public void ClickCarouselReadMore()
        {
            var readMoreButton = this.driverContext.ShortWait.WaitUntilElementIsClickable(this.insightCarouselReadMoreBy);
            readMoreButton.Click();
        }
    }
}
