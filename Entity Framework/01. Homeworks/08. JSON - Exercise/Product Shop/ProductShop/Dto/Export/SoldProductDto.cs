namespace ProductShop.Dto.Export
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SoldProductDto
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }

        [JsonProperty(PropertyName = "buyerFirstName")]
        public string BuyerFirstName { get; set; }

        [JsonProperty(PropertyName = "buyerLastName")]
        public string BuyerLastName { get; set; }
    }
}