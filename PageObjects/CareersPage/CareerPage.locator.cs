using OpenQA.Selenium;

namespace Task__Selenium_WebDriver.PageObjects.CareersPage;

public partial class CareerPage
{
    private static readonly string CareerSearchKeywordFieldLocator = "new_form_job_search-keyword";
    private static readonly string CareerSuggestionsMenuLocator = "form > .recruiting-search__column > .autocomplete-suggestions";
    private static readonly string CareerLocationDropdownLocator = "recruiting-search__location";
    private static readonly string CareerRemoteLabelLocator = "label[for*='remote']";
    private static readonly string CareerSearchButtonLocator = "form[id='jobSearchFilterForm'] > button";

    private readonly By careerSearchKeywordFieldBy = By.Id(CareerSearchKeywordFieldLocator);
    private readonly By careerSuggestionsMenuBy = By.CssSelector(CareerSuggestionsMenuLocator);
    private readonly By careerLocationDropdownBy = By.ClassName(CareerLocationDropdownLocator);
    private readonly By careerRemoteLabelBy = By.CssSelector(CareerRemoteLabelLocator);
    private readonly By careerSearchButtonBy = By.CssSelector(CareerSearchButtonLocator);
}