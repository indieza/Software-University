namespace PetStore.Services.Models.Brand
{
    using System.Collections.Generic;
    using Toy;

    public class BrandWithToysServiceModel
    {
        public string Name { get; set; }

        public IEnumerable<ToyListingServiceModel> Toys { get; set; }
    }
}
