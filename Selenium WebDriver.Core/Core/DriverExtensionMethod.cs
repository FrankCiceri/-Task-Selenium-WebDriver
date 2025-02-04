using log4net.Repository.Hierarchy;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.BrowsingContext;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Selenium_WebDriver.Core.Interfaces;
using Selenium_WebDriver.Core.Utils;
using SeleniumExtras.WaitHelpers;

using System.Runtime.CompilerServices;

namespace Selenium_WebDriver.Core.Core;

public static class DriverExtensionMethod
{
    public static IWebElement WaitUntilElementIsVisible(this WebDriverWait wait, By locator)
    {
        LoggerUtil.Debug($"Waiting for element to be visible: {locator}");
        try
        {
            var element = wait.Until(ExpectedConditions.ElementIsVisible(locator));
            LoggerUtil.Debug($"Element is now visible: {locator}");
            return element;
        }
        catch (Exception ex)
        {
            LoggerUtil.Error($"Element not visible: {locator}", ex);
            throw;
        }
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

    public static void GoToElement(this IDriverContext driverContext, IWebElement webElement)
    {
        new Actions(driverContext.GetDriver())
            .MoveToElement(webElement)
            .Perform();
    }

    public static void ShortWaitElementAndClick(this IDriverContext driverContext, By locator)
    {
        LoggerUtil.Debug($"Attempting to click element: {locator}");
        try
        {
            var element = driverContext.ShortWait.WaitUntilElementIsClickable(locator);
            element.Click();
            LoggerUtil.Info($"Successfully clicked element: {locator}");
        }
        catch (Exception ex)
        {
            LoggerUtil.Error($"Failed to click element: {locator}", ex);
            throw;
        }
    }

    public static void LongWaitElementAndClick(this IDriverContext driverContext, By locator)
    {
        LoggerUtil.Debug($"Attempting to click element: {locator}");
        try
        {
            var element = driverContext.LongWait.WaitUntilElementIsClickable(locator);
            element.Click();
            LoggerUtil.Info($"Successfully clicked element: {locator}");
        }
        catch (Exception ex)
        {
            LoggerUtil.Error($"Failed to click element: {locator}", ex);
            throw;
        }
    }

    public static void GoToElementAndClick(this IDriverContext driverContext, IWebElement webElement)
    {
        new Actions(driverContext.GetDriver())
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

    public static void ActionPressEscape(this IDriverContext driverManager)
    {
        try
        {
            LoggerUtil.Debug($"Attempting to Press Escape Key");
            new Actions(driverManager.GetDriver())
            .SendKeys(Keys.Escape)
            .Perform();
            LoggerUtil.Info("Escape Key Pressed");
        }
        catch (Exception ex)
        {
            LoggerUtil.Error($"Failed to Press Escape Key", ex);
            throw;
        }
    }

    public static void ScrollToElement(this IDriverContext driverManager, IWebElement elem)
    {
        LoggerUtil.Debug($"Scrolling to element: {elem.Text}");
        try
        {
            IJavaScriptExecutor je = (IJavaScriptExecutor)driverManager.GetDriver();
            je.ExecuteScript("arguments[0].scrollIntoView(false);", elem);
            LoggerUtil.Info($"Successfully scrolled to element: {elem.Text}");
        }
        catch (Exception ex)
        {
            LoggerUtil.Error($"Failed to scroll to element: {elem.Text}", ex);
            throw;
        }
    }

    public static bool IsElementVisible(this IDriverContext driverContext, By locator)
    {
        LoggerUtil.Debug($"Checking visibility of element: {locator}");
        try
        {
            var elements = driverContext.GetDriver().FindElements(locator);

            if (elements.Count == 0)
            {
                LoggerUtil.Info($"Element not found: {locator}");
                return false;
            }

            bool isVisible = elements[0].Displayed;
            LoggerUtil.Info($"Element visibility: {isVisible} for locator: {locator}");
            return isVisible;
        }
        catch (Exception ex)
        {
            LoggerUtil.Error($"Error checking visibility of element: {locator}", ex);
            return false;
        }
    }

    public static void AcceptCookies(this IDriverContext driverContext)
    {
        By acceptCookieButton = By.Id("onetrust-accept-btn-handler");
        try
        {
            var acceptButton = driverContext.ShortWait
                .Until(ExpectedConditions.ElementToBeClickable(acceptCookieButton));

            bool isVisible = true;
            while (isVisible)
            {
                acceptButton.Click();
                isVisible = driverContext.LongWait
                                    .Until(ExpectedConditions.InvisibilityOfElementLocated(acceptCookieButton));
            }

            LoggerUtil.Info("Cookies Accepted");
        }
        catch (Exception)
        {
            LoggerUtil.Info("Cookies did not appear");
        }
    }
}