using OpenQA.Selenium;
using Selenium_WebDriver.Business.PageObjects.ServicesPage;
using Selenium_WebDriver.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace Selenium_WebDriver.Tests.Specflow_Tests.Steps
{
    [Binding]
    public class ServicesPageSteps
    {
        private readonly ServicePage _servicePage;

        public ServicesPageSteps(IDriverContext driverContext)
        {
            _servicePage = new ServicePage(driverContext);
        }

        [Then(@"the page title should be ""(.*)""")]
        public void ThenThePageTitleShouldBe(string expectedTitle)
        {
            string actualTitle = _servicePage.GetServicePageTitle();
            Assert.That(actualTitle.Contains(expectedTitle), Is.True, $"Expected title '{expectedTitle}', but got '{actualTitle}'");
        }

        [Then(@"the ""Our Related Expertise"" section should be visible")]
        public void ThenTheOurRelatedExpertiseSectionShouldBeVisible()
        {
            var expertiseSection = _servicePage.GetOurExpertiseSection();
            Assert.That(expertiseSection.Displayed, Is.True, "The 'Our Related Expertise' section is not visible.");
        }
    }
}
