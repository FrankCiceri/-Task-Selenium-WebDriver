using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace webdriver_task_3.DriverAddition
{
    public static class DriverExtensionMethod
    { 

        public static void WaitElementToBeVisible(this WebDriverWait wait, By locator) {
            
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public static void WaitForElementToExist(this WebDriverWait wait, By locator)
        {
            wait.Until(ExpectedConditions.ElementExists(locator));
        }

        public static void WaitUntilElementIsClickable(this WebDriverWait wait, By locator)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(locator));          
        }

    }
}
