﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace NetLogDNA.LogDnaApi.Dto
{
    public class Meta
    {
        [JsonProperty("exception")]
        public ExceptionInfo Exception { get; set; }
        
        [JsonProperty("properties")]
        public IDictionary<object, object> Properties { get; set; }

        [JsonProperty("tags")]
        public IList<string> Tags { get; set; }
    }
}