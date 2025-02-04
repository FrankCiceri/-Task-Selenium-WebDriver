using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Selenium_WebDriver.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Selenium_WebDriver.Core.Utils
{
    public static class TestHandler
    {
        public static void TestFinished(TestContext.ResultAdapter result, IDriverContext driverContext)
        {
            if (driverContext is null)
            {
                throw new ArgumentNullException(nameof(driverContext));
            }

            var outcome = result.Outcome;
            if (outcome == ResultState.Success)
            {
                LoggerUtil.Info($"Test Finished: {outcome.Label} - Success");
            }
            else
            {
                LoggerUtil.Warn($"Test Finished: {result} - {outcome} - {result.Message} \n");

                ScreenshotMaker.TakeScreenshot(driverContext);
            }
        }
    }
}
