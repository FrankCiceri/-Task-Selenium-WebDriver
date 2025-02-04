using OpenQA.Selenium;

namespace Selenium_WebDriver.Business.PageObjects.SearchPage
{
    public partial class SearchPage
    {
        private static readonly string SearchResultLocator = ".search-results__items";
        private static readonly string SearchResultArticlesLocator = "article";
        private static readonly string SearchResultLinksLocator = ".search-results__items a";

        private readonly By searchResultBy = By.CssSelector(SearchResultLocator);
        private readonly By searchResultArticleBy = By.TagName(SearchResultArticlesLocator);
        private readonly By searchResultLinksBy = By.CssSelector(SearchResultLinksLocator);
    }
}
