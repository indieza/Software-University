namespace PetStore.Services.Models.Toy
{
    public class AddingToyServiceModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public double Profit { get; set; }

        public int BrandId { get; set; }

        public int CategoryId { get; set; }
    }
}
