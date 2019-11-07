namespace ProductShop.Dto.Export
{
    using Newtonsoft.Json;
    using ProductShop.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SoldProductsToUserDto
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("products")]
        public ICollection<SoldProductsDto> Products { get; set; }
    }
}