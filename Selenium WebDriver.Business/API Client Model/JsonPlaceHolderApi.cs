using RestSharp;
using RestSharp.Serializers.Json;
using Selenium_WebDriver.Business.API_BusinessModels;
using Selenium_WebDriver.Core.API_Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace Selenium_WebDriver.Business.API_Client_Model
{
    public class JsonPlaceHolderApi : IJsonPlaceHolderApi, IDisposable
    {
        private string usersCall = "/users";
        private string invalidEndpointCall = "/invalidendpoint";
        private IRestClient _restClient;

        public JsonPlaceHolderApi()
        {
            var serializerOptions = new JsonSerializerOptions()
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            };

            _restClient = new RestClient(
                options: new() { BaseUrl = new($"https://jsonplaceholder.typicode.com") },
                configureSerialization: s => s.UseSystemTextJson(serializerOptions));
        }

        public void Dispose()
        {
            _restClient?.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<RestResponse<User>> AddUserAsync(string name, string username)
        {
            var request = new RestRequest(usersCall, Method.Post);
            var user = new User()
            {
                   Name = name,
                   Username = username,
            };
            request.AddJsonBody(user);

            var response = await _restClient.ExecuteAsync<User>(request);

            return response;
        }

        public async Task<RestResponse<User[]>> GetUsersAsync()
        {
            var request = new RestRequest(usersCall, Method.Get);

            var response = await _restClient.ExecuteAsync<User[]>(request);

            return response;
        }

        public async Task<RestResponse> GetInvalidEndPointAsync()
        {
            var request = new RestRequest(invalidEndpointCall, Method.Get);

            var response = await _restClient.ExecuteAsync(request);

            return response;
        }
    }
}
