﻿using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace Selenium_WebDriver.Business.PageObjects.SearchPage
{
    public partial class SearchPage
    {
        private readonly By _searchResultBy = By.CssSelector(".search-results__items");
        private readonly By _searchPartialResultArticleBy = By.TagName("article");
        private readonly By _searchResultLinksBy = By.CssSelector(".search-results__items a");
        private readonly By _searchResultTextBy = By.CssSelector(".search-results__items p");

        private IWebElement ResultsContainer => _driverContext.GetDriver().FindElement(_searchResultBy);

        private IEnumerable<IWebElement> SearchResultLinks => _driverContext.GetDriver().FindElements(_searchResultLinksBy);

        private IEnumerable<IWebElement> SearchResultTexts => _driverContext.GetDriver().FindElements(_searchResultTextBy);

        private ReadOnlyCollection<IWebElement> ArticleTagsInResultsContainer => ResultsContainer.FindElements(_searchPartialResultArticleBy);
    }
}
