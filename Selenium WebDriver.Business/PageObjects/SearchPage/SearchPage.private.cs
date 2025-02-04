using Selenium_WebDriver.Core.Interfaces;

namespace Selenium_WebDriver.Business.PageObjects.SearchPage
{
    public partial class SearchPage
    {
        private readonly IDriverContext driverContext;

        private void WaitSearchResults()
        {
            this.driverContext.LongWait.Until(driver =>
            {
                var divResults = driver.FindElement(this.searchResultBy);
                var elementsInsideDiv = divResults.FindElements(this.searchResultArticleBy);
                return elementsInsideDiv.Count > 0;
            });
        }
    }
}
