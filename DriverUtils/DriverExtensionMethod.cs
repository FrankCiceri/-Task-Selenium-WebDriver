﻿using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Task__Selenium_WebDriver.DriverUtils;

namespace Selenium_WebDriver.DriverUtils;

public static class DriverExtensionMethod
{
    public static IWebElement WaitElementToBeVisible(this WebDriverWait wait, By locator)
    {
        return wait.Until(ExpectedConditions.ElementIsVisible(locator));
    }

    public static IWebElement WaitForElementToExist(this WebDriverWait wait, By locator)
    {
        return wait.Until(ExpectedConditions.ElementExists(locator));
    }

    public static IWebElement WaitUntilElementIsClickable(this WebDriverWait wait, By locator)
    {
        return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
    }

    public static IWebElement WaitFindElement(this WebDriverWait wait, By locator)
    {
        return wait.Until(d => d.FindElement(locator));
    }

    public static void GoToElement(this DriverManager driverManager, IWebElement webElement)
    {
        new Actions(driverManager.GetDriver())
            .MoveToElement(webElement)
            .Perform();
    }

    public static void GoToElementAndClick(this DriverManager driverManager, IWebElement webElement)
    {
        new Actions(driverManager.GetDriver())
            .MoveToElement(webElement)
            .Click()
            .Perform();
    }

    public static void WaitUntilAttributeContains(this WebDriverWait wait, By locator, string attribute, string value)
    {
        wait.Until(d =>
        {
            var element = d.FindElement(locator);
            return element.GetAttribute(attribute).Contains(value);
        });
    }

    public static void ActionPressEscape(this DriverManager driverManager)
    {
        new Actions(driverManager.GetDriver())
            .SendKeys(Keys.Escape)
            .Perform();
    }
}