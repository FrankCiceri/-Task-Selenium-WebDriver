﻿using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Selenium_WebDriver.DriverUtils;
using System.Runtime.CompilerServices;

namespace Selenium_WebDriver.DriverUtils;

public static class DriverExtensionMethod
{
    public static IWebElement WaitUntilElementIsVisible(this WebDriverWait wait, By locator)
    {
        return wait.Until(ExpectedConditions.ElementIsVisible(locator));
    }

    public static IWebElement WaitUntilElementExists(this WebDriverWait wait, By locator)
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

    public static IEnumerable<IWebElement> WaitFindElements(this WebDriverWait wait, By locator)
    {
        return wait.Until(d => d.FindElements(locator));
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

    public static void ScrollToElement(this DriverManager driverManager, IWebElement elem)
    {
        IJavaScriptExecutor je = (IJavaScriptExecutor)driverManager.GetDriver();
        je.ExecuteScript("arguments[0].scrollIntoView(false);", elem);
    }

    public static bool IsElementVisible(this DriverManager driverManager, By locator)
    {
        try
        {
            var elements = driverManager.GetDriver().FindElements(locator);

            if (elements.Count == 0)
            {
                return false;
            }

            return elements[0].Displayed;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public static void AcceptCookies(this DriverManager driverManager)
    {
        By acceptCookieButton = By.Id("onetrust-accept-btn-handler");
        try
        {
            var acceptButton = driverManager.ShortWait
                .Until(ExpectedConditions.ElementToBeClickable(acceptCookieButton));

            bool isVisible = true;
            while (isVisible)
            {
                acceptButton.Click();
                isVisible = driverManager.LongWait
                                    .Until(ExpectedConditions.InvisibilityOfElementLocated(acceptCookieButton));
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Cookies did not appear");
        }
    }
}