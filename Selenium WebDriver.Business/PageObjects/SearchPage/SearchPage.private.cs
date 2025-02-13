using Selenium_WebDriver.Core.Interfaces;

namespace Selenium_WebDriver.Business.PageObjects.SearchPage
{
    public partial class SearchPage
    {
        private readonly IDriverContext _driverContext;

        private void WaitSearchResults()
        {
            this._driverContext.LongWait.Until(driver =>
            {
                var elementsInsideDiv = ArticleTagsInResultsContainer;
                return elementsInsideDiv.Count > 0;
            });
        }
    }
}
