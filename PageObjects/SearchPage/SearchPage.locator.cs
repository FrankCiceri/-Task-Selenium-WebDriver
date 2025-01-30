using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_WebDriver.PageObjects.SearchPage
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
