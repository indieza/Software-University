namespace ProductShop.Dto
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CategoriesDto
    {
        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }

        [JsonProperty(PropertyName = "productsCount")]
        public int ProductsCount { get; set; }

        [JsonProperty(PropertyName = "averagePrice")]
        public decimal AveragePrice { get; set; }

        [JsonProperty(PropertyName = "totalRevenue")]
        public decimal TotalRevenue { get; set; }
    }
}