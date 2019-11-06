namespace ProductShop.Dto.Export
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class UserDto
    {
        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "soldProducts")]
        public ICollection<SoldProductDto> SoldProducts { get; set; }
    }
}