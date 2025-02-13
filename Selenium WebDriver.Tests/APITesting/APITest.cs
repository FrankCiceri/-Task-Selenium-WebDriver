using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using RestSharp.Serializers.Json;
using System.Net;
using Selenium_WebDriver.Business.API_BusinessModels;
using Selenium_WebDriver.Core.API_Model.Interfaces;
using Selenium_WebDriver.Business.API_Client_Model;

namespace Selenium_WebDriver.Tests.APITesting
{
    [TestFixture]
    public class APITest
    {
        private JsonPlaceHolderApi _jsonPlaceHolderClient;

        [SetUp]
        public void SetUp()
        {
            _jsonPlaceHolderClient = new JsonPlaceHolderApi();
        }

        [Test]
        [Category("API")]
        public async Task VerifyThatGetAllUnicornsResourceReturnsOkStatusCode()
        {
            var response = await _jsonPlaceHolderClient.GetUsersAsync();

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Expected HTTP 200 OK response.");

            var containsAllFields = UsersContainAllFields(response.Content);
            Assert.That(containsAllFields, Is.True, "One or more user objects are missing required fields.");
        }

        [Test]
        [Category("API")]
        public async Task VerifyThatGetAllUsersReturnsOkAndValidContentType()
        {
            var response = await _jsonPlaceHolderClient.GetUsersAsync();

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Expected HTTP 200 OK response.");

            var containsContentType = response.ContentHeaders?
                .Any(header => header.Name.Equals("Content-Type", StringComparison.OrdinalIgnoreCase));
            Assert.That(containsContentType, Is.True, "Content-Type header is missing in the response.");

            var contentType = response.ContentHeaders?
                .First(h => h.Name.Equals("Content-Type", StringComparison.OrdinalIgnoreCase))
                ?.Value?.ToString();

            Assert.That(contentType, Is.EqualTo("application/json; charset=utf-8"), $"Expected Content-Type 'application/json; charset=utf-8', but got '{contentType}'.");
        }

        [Test]
        [Category("API")]
        public async Task VerifyThatListOfUsersValuesAreNotEmptyReturnsOKStatusCode()
        {
            var response = await _jsonPlaceHolderClient.GetUsersAsync();

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Expected HTTP 200 OK response.");

            Assert.That(response.Data?.Length, Is.EqualTo(10));

            var uniqueId = UsersHaveUniqueID(response.Data);

            Assert.That(uniqueId, Is.True);

            Assert.That(
                response.Data.All(
                user => !string.IsNullOrWhiteSpace(user.Name) && !string.IsNullOrWhiteSpace(user.Username)),
                Is.True,
                "Some users have an empty Name or Username.");

            Assert.That(
                response.Data.All(user => !string.IsNullOrWhiteSpace(user.Company?.Name)),
                Is.True,
                "Some user companies have an empty Name.");
        }

        [TestCase("Frank", "FRK")]
        [Category("API")]
        public async Task VerifyThatUserCanBeCreated(string name, string username)
        {
            var response = await _jsonPlaceHolderClient.AddUserAsync(name, username);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));

            Assert.That(response.Data, Is.Not.Null, "Response data should not be null.");

            Assert.That(response.Data.Id, Is.GreaterThan(0), "User ID should be greater than 0.");

            Assert.That(response.Data.Name, Is.EqualTo(name), "User name does not match.");
            Assert.That(response.Data.Username, Is.Not.Null.And.Not.Empty, "Username should not be null or empty.");
        }

        [Test]
        [Category("API")]
        public async Task VerifyThatResourceDoesNotExists()
        {
            var response = await _jsonPlaceHolderClient.GetInvalidEndPointAsync();

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        private static bool UsersHaveUniqueID(User[] users)
        {
            return users.Select(user => user.Id).Distinct().Count() == users.Length;
        }

        private static bool UsersContainAllFields(string json)
        {
            JsonDocument doc = JsonDocument.Parse(json);

            if (doc.RootElement.ValueKind != JsonValueKind.Array)
            {
                return false;
            }

            foreach (JsonElement user in doc.RootElement.EnumerateArray())
            {
                if (!user.TryGetProperty("id", out _) ||
                    !user.TryGetProperty("name", out _) ||
                    !user.TryGetProperty("username", out _) ||
                    !user.TryGetProperty("email", out _) ||
                    !user.TryGetProperty("address", out _) ||
                    !user.TryGetProperty("phone", out _) ||
                    !user.TryGetProperty("website", out _) ||
                    !user.TryGetProperty("company", out _))
                {
                    return false;
                }
            }

            return true;
        }

        [TearDown]
        public void TestEnd()
        {
            _jsonPlaceHolderClient.Dispose();
        }
    }
}
