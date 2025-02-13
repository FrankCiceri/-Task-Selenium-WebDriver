using System.Text.Json;

namespace Selenium_WebDriver.Tests.TestData
{
    public class TestDataLoader
    {
        public static IEnumerable<object[]> LoadTestDataForTest1()
        {
            var json = LoadJsonData();
            if (!string.IsNullOrEmpty(json))
            {
                using (JsonDocument doc = JsonDocument.Parse(json))
                {
                    if (doc.RootElement.TryGetProperty("Test1", out JsonElement test1Data))
                    {
                        foreach (var data in test1Data.EnumerateArray())
                        {
                            string programmingLanguage = data.GetProperty("ProgrammingLanguage").GetString()!;
                            string location = data.GetProperty("Location").GetString()!;
                            yield return new object[] { programmingLanguage, location };
                        }
                    }
                }
            }
        }

        public static IEnumerable<string> LoadTestDataForTest2()
        {
            var json = LoadJsonData();
            if (!string.IsNullOrEmpty(json))
            {
                using (JsonDocument doc = JsonDocument.Parse(json))
                {
                    if (doc.RootElement.TryGetProperty("Test2", out JsonElement test2Data))
                    {
                        foreach (var data in test2Data.EnumerateArray())
                        {
                            string searchValue = data.GetProperty("SearchValue").GetString()!;
                            yield return searchValue;
                        }
                    }
                }
            }
        }

        private static string LoadJsonData()
        {
            var environment = TestContext.Parameters["environment"];
            var testDataFile = !string.IsNullOrEmpty(environment) ? SelectJsonEnvironment(environment) : "testdataQA.json";
            return !string.IsNullOrEmpty(testDataFile) ? File.ReadAllText(testDataFile) : string.Empty;
        }

        private static string SelectJsonEnvironment(string environment)
        {
            return environment switch
            {
                "QA" => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", "TestDataResources", "testdataQA.json"),
                "PROD" => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", "TestDataResources", "testdataProd.json"),
                _ => throw new ArgumentException($"Unsupported environment: {environment}"),
            };
        }
    }
}
