using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Selenium_WebDriver.Business.PageObjects.CareersPage;

public partial class CareerPage
{
    private readonly By _careerSearchTextFieldBy = By.Id("new_form_job_search-keyword");
    private readonly By _careerSuggestionsMenuBy = By.CssSelector("form > .recruiting-search__column > .autocomplete-suggestions");
    private readonly By _careerLocationDropdownBy = By.ClassName("recruiting-search__location");
    private readonly By _careerRemoteLabelBy = By.CssSelector("label[for*='remote']");
    private readonly By _careerSearchButtonBy = By.CssSelector("form[id='jobSearchFilterForm'] > button");
    private readonly By _careerDateFilterButtonBy = By.CssSelector("[title='Date']");
    private readonly By _careerPreloaderBy = By.ClassName("preloader");
    private readonly By _careerFirstResultBy = By.CssSelector("li.search-result__item:first-of-type");
    private readonly By _careerFirstResultApplyBy = By.CssSelector("li.search-result__item:first-of-type .search-result__item-apply-23");

    private IWebElement SearchKeywordField => _driverContext.GetDriver().FindElement(_careerSearchTextFieldBy);

    private IWebElement LocationDropdown => _driverContext.GetDriver().FindElement(_careerLocationDropdownBy);

    private IWebElement RemoteLabel => _driverContext.GetDriver().FindElement(_careerRemoteLabelBy);

    private IWebElement SearchButton => _driverContext.GetDriver().FindElement(_careerSearchButtonBy);

    private IWebElement DateFilterButton => _driverContext.GetDriver().FindElement(_careerDateFilterButtonBy);

    private IWebElement FirstResult => _driverContext.GetDriver().FindElement(_careerFirstResultBy);

    private IWebElement FirstResultApplyButton => _driverContext.GetDriver().FindElement(_careerFirstResultApplyBy);
}