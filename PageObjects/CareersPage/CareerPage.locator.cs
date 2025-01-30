using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Selenium_WebDriver.PageObjects.CareersPage;

public partial class CareerPage
{
    private static readonly string CareerSearchKeywordFieldLocator = "new_form_job_search-keyword";
    private static readonly string CareerSuggestionsMenuLocator = "form > .recruiting-search__column > .autocomplete-suggestions";
    private static readonly string CareerLocationDropdownLocator = "recruiting-search__location";
    private static readonly string CareerRemoteLabelLocator = "label[for*='remote']";
    private static readonly string CareerSearchButtonLocator = "form[id='jobSearchFilterForm'] > button";
    private static readonly string CareerDateFilterButtonLocator = "[title='Date']";
    private static readonly string CareerPreloaderLocator = "preloader";
    private static readonly string CareerFirstResultLocator = "li.search-result__item:first-of-type";
    private static readonly string CareerFirstResultApplyLocator = "li.search-result__item:first-of-type .search-result__item-apply-23";

    private readonly By careerSearchKeywordFieldBy = By.Id(CareerSearchKeywordFieldLocator);
    private readonly By careerSuggestionsMenuBy = By.CssSelector(CareerSuggestionsMenuLocator);
    private readonly By careerLocationDropdownBy = By.ClassName(CareerLocationDropdownLocator);
    private readonly By careerRemoteLabelBy = By.CssSelector(CareerRemoteLabelLocator);
    private readonly By careerSearchButtonBy = By.CssSelector(CareerSearchButtonLocator);
    private readonly By careerDateFilterButtonBy = By.CssSelector(CareerDateFilterButtonLocator);
    private readonly By careerPreloaderBy = By.ClassName(CareerPreloaderLocator);
    private readonly By careerFirstResultBy = By.CssSelector(CareerFirstResultLocator);
    private readonly By careerFirstResultApplyBy = By.CssSelector(CareerFirstResultApplyLocator);
}