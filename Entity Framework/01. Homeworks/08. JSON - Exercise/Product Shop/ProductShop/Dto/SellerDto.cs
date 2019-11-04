namespace ProductShop.Dto
{
    using Newtonsoft.Json;
    using ProductShop.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SellerDto
    {
        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "soldProducts")]
        public IList<SoldProductDto> SoldProducts { get; set; }
    }
}