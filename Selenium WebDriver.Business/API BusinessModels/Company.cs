﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Selenium_WebDriver.Business.API_BusinessModels
{
    public class Company
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("catchPhrase")]
        public string? CatchPhrase { get; set; }

        [JsonPropertyName("bs")]
        public string? Bs { get; set; }
    }

}
