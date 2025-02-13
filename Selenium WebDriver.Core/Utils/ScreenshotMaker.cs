using OpenQA.Selenium;
using Selenium_WebDriver.Core.Interfaces;

namespace Selenium_WebDriver.Core.Utils
{
    public static class ScreenshotMaker
    {
        private static string NewScreenshotName
        {
            get { return "_" + DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss-fff") + ".png"; }
        }

        public static void TakeScreenshot(IDriverContext driverManager)
        {
            try
            {
                var screenshot = ((ITakesScreenshot)driverManager.GetDriver()).GetScreenshot();

                var projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var directory = Path.Combine(projectDirectory, "FailedTestScreenshots");

                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                var filePath = Path.Combine(directory, $"Screen_{NewScreenshotName}");
                screenshot.SaveAsFile(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while taking the screenshot: " + ex.Message);
            }
        }
    }
}
