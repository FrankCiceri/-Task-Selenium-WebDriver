using Selenium_WebDriver.Core.Core;
using Selenium_WebDriver.Core.Interfaces;
using Selenium_WebDriver.Core.Utils;

namespace Selenium_WebDriver.Business.PageObjects.DetailPage
{
    public partial class DetailPage
    {
        public DetailPage(IDriverContext driverContext)
        {
            if (driverContext is null)
            {
                throw new ArgumentNullException(nameof(driverContext));
            }

            this._driverContext = driverContext;
        }

        public string GetHeaderTitleText()
        {
            try
            {
                _driverContext.ShortWait.WaitUntilElementIsVisible(_detailHeaderTitleBy);
                LoggerUtil.Info($"Header Title text Obtained");
                return HeaderTitle.Text;
            }
            catch (Exception ex)
            {
                LoggerUtil.Error("Failed to Get Header Title text", _detailHeaderTitleBy, ex);

                throw;
            }
        }
    }
}
