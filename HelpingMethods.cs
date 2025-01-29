using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace Task__Selenium_WebDriver
{
    public class HelpingMethods
    {
        private IWebDriver driver;
        private WebDriverWait shortWait;
        private WebDriverWait longWait;

        public HelpingMethods(IWebDriver webDriver)
        {
            this.driver = webDriver;
            shortWait = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
            {
                PollingInterval = TimeSpan.FromSeconds(0.25)
            };

            longWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromSeconds(0.5)
            };
        }

        public void AcceptCookies()
                {
                    try
                    {
                        var acceptButton = shortWait.Until(ExpectedConditions.ElementToBeClickable(
                                        By.Id("onetrust-accept-btn-handler")
                                    ));
                        acceptButton.Click();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Cookies did not appear");
                    }
                }

        #region Helper Methods 1
        public void ClickCareersLink()
        {
            var careersButton = longWait.Until(ExpectedConditions.ElementToBeClickable(
                By.XPath("//span/a[text()='Careers']")
            ));
            careersButton.Click();
        }

        public void PerformJobSearch(string keyword, string location)
        {
            var searchField = shortWait.Until(d => d.FindElement(By.Id("new_form_job_search-keyword")));
            searchField.SendKeys(keyword);
            var menuIsDeployed = false;
            try
            {
                var suggestionsMenu = By.CssSelector("form > .recruiting-search__column > .autocomplete-suggestions");
                shortWait.Until(ExpectedConditions.ElementIsVisible(suggestionsMenu));

            }
            catch (Exception)
            {
                menuIsDeployed = true;
            }

            if (menuIsDeployed)
            {
                new Actions(driver)
                    .SendKeys(Keys.Escape)
                    .Perform();
            }

            var locationDropdown = driver.FindElement(By.ClassName("recruiting-search__location"));
            locationDropdown.Click();

            var allLocations = shortWait.Until(d => d.FindElement(By.XPath($"//li[contains(text(), '{location}')]")));
            allLocations.Click();

            var remoteLabelLocator = By.CssSelector("label[for*='remote']");
            var remoteLabel = shortWait.Until(ExpectedConditions.ElementToBeClickable(remoteLabelLocator));
            remoteLabel.Click();

            var searchButton = driver.FindElement(By.CssSelector("form[id='jobSearchFilterForm'] > button"));
            searchButton.Click();
        }

        public void SortJobsByDate()
        {
            var dateSortingButton = longWait.Until(
                ExpectedConditions.ElementToBeClickable(By.CssSelector("[title='Date']"))
            );
            GoToElementAndClick(dateSortingButton);

            shortWait.Until(d =>
            {
                var element = d.FindElement(By.ClassName("preloader"));
                return element.GetAttribute("style").Contains("display: block;");
            });

            shortWait.Until(d =>
            {
                var element = d.FindElement(By.ClassName("preloader"));
                return element.GetAttribute("style").Contains("display: none;");
            });
        }

        public void ApplyToFirstJob()
        {
            var firstElement = longWait.Until(
                ExpectedConditions.ElementToBeClickable(
                    By.CssSelector("li.search-result__item:first-of-type")
                )
            );

            GoToElement(firstElement);

            var applyButton = longWait.Until(
                ExpectedConditions.ElementToBeClickable(
                    By.CssSelector("li.search-result__item:first-of-type .search-result__item-apply-23")
                )
            );
            GoToElementAndClick(applyButton);
        }

        public bool ValidateJobPageContains(string expectedText)
        {
            var titleElement = longWait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("vacancy-details-23__job-title")));

            if (titleElement.Text.ToLowerInvariant().Contains(expectedText.ToLowerInvariant()))
            {
                return true;
            }

            var listOfRequirementElements = driver.FindElements(By.XPath("//*[not(preceding-sibling::h3[text()= 'We offer']) and contains(@class, 'vacancy-details-23__bullet-list') and contains(@class, 'bullet-list')]/li"));


            foreach (var li in listOfRequirementElements)
            {
                if (li.Text.ToLowerInvariant().Contains(expectedText.ToLowerInvariant()))
                {
                    return true;
                }
            }

            return false;
        }
        #endregion
        public void ClickMainPageMagnifier()
        {
            var careersButton = longWait.Until(ExpectedConditions.ElementToBeClickable(
                By.CssSelector(".header-search__button")
            ));
            careersButton.Click();
        }

        public void WaitMainPageSearchPanelToDeploy()
        {
            longWait.Until(ExpectedConditions.ElementExists(
                By.CssSelector(".header-search__panel.opened")
            ));           
        }

        public void EnterMainPageSearch(string searchString)
        {
            var searchField = driver.FindElement(By.Name("q"));
            GoToElementAndClick(searchField);
            new Actions(driver)
                .Pause(TimeSpan.FromSeconds(1))
                .SendKeys(searchString)
                .Perform();
        }

        public void ClickMainPageSearchButton()
        {
            var searchButton = shortWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(@class, 'custom-search-button')]")));
            searchButton.Click();
        }

        public bool ValidateLinksContain(string searchString)
        {

            WaitSearchResults();

            var links = driver.FindElements(By.CssSelector(".search-results__items a"));
            var result = links.All(a => a.Text.ToLowerInvariant().Contains(searchString.ToLowerInvariant()));

            return result;
        }

        private void WaitSearchResults()
        {
            longWait.Until(driver =>
            {
                var divResults = driver.FindElement(By.CssSelector(".search-results__items"));
                var elementsInsideDiv = divResults.FindElements(By.TagName("article"));
                return elementsInsideDiv.Count > 0;
            });
        }


        #region HelperMethods 2

        #endregion
        private void GoToElementAndClick(IWebElement webElement)
        {
            new Actions(driver)
                .MoveToElement(webElement)
                .Click()
                .Perform();
        }

        private void GoToElement(IWebElement webElement)
        {
            new Actions(driver)
                .MoveToElement(webElement)
                .Perform();
        }
    }
}
