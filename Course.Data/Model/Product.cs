using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Course.Data
{
    public class Product
    {
        [JsonProperty(PropertyName ="id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "price")]
        public double Price { get; set; }
    }
}
