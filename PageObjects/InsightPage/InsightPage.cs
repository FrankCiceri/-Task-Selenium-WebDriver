using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Selenium_WebDriver.DriverUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_WebDriver.PageObjects.InsightPage
{
    public partial class InsightPage
    {
        public InsightPage(DriverManager driverManager)
        {
            if (driverManager is null)
            {
                throw new ArgumentNullException(nameof(driverManager));
            }

            this.driverManager = driverManager;
            this.shortWait = driverManager.ShortWait;
            this.longWait = driverManager.LongWait;
        }

        public void SwipeFirstCarouselNTimes(int numberOfSwipes)
        {
            var activeSlide = this.WaitCarouselToBeClickable();
            var actions = new Actions(this.driverManager.GetDriver());
            //var slider = activeSlide.FindElement(By.XPath(".//div[contains(@class, 'single-slide__content-container')]"));
            for (int i = 0; i < numberOfSwipes; i++)
            {
                actions.ClickAndHold(activeSlide)
                       .MoveByOffset(-300, 0)
                       .Release()
                       .Perform();

                this.shortWait.Until(d => !activeSlide.GetAttribute("class").Contains("active"));

                activeSlide = this.WaitCarouselToBeClickable();
            }
        }

        public string GetCarouselCurrentActiveElementText()
        {
            var carouselCurrentActiveElement = this.shortWait.WaitUntilElementIsVisible(this.insightCarouselCurrentActiveTextBy);
            return carouselCurrentActiveElement.Text;
        }

        public void ClickCarouselReadMore()
        {
            var readMoreButton = this.shortWait.WaitUntilElementIsClickable(this.insightCarouselReadMoreBy);
            readMoreButton.Click();
        }
    }
}
