using OpenQA.Selenium.DevTools;
using RestSharp;
using Selenium_WebDriver.Business.API_BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_WebDriver.Core.API_Model.Interfaces
{
    public interface IJsonPlaceHolderApi
    {
        Task<RestResponse<User>> AddUserAsync(string name, string username);

        Task<RestResponse<User[]>> GetUsersAsync();

        Task<RestResponse> GetInvalidEndPointAsync();

    }
}
