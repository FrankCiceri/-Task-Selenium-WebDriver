using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_WebDriver.PageObjects.DetailPage
{
    public partial class DetailPage
    {
        private static readonly string DetailHeaderTitleLocator = "//div[contains(@class,'detail-page23__header')]//div[contains(@class, 'scaling-of-text-wrapper')]";

        private readonly By detailHeaderTitleBy = By.XPath(DetailHeaderTitleLocator);
    }
}
