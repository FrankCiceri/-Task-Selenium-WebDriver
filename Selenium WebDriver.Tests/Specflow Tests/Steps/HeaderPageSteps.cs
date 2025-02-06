using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Selenium_WebDriver.Business.PageObjects.HeaderPage;
using Selenium_WebDriver.Core.Interfaces;

namespace Selenium_WebDriver.Tests.Specflow_Tests.Steps
{
    [Binding]
    public class HeaderPageSteps
    {
        private readonly HeaderPage _headerPage;

        public HeaderPageSteps(IDriverContext driverContext)
        {
            _headerPage = new HeaderPage(driverContext);
        }

        [When(@"I hover over the Services menu")]
        public void WhenIHoverOverTheServicesMenu()
        {
            _headerPage.HoverServicesLink();
        }

        [When(@"I select ""(.*)"" from the dropdown")]
        public void WhenISelectServiceCategoryFromTheDropdown(string serviceCategory)
        {
            _headerPage.ClickServiceMenuItem(serviceCategory);
        }
    }
}
