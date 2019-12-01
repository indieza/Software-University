namespace PetStore.Services
{
    using Services.Models.Toy;

    public interface IToyService
    {
        void BuyFromDistributor(string name, string description, decimal distributorPrice, double profit, int brandId, int categoryId);

        void BuyFromDistributor(AddingToyServiceModel model);

        void SellToyToUser(int toyId, int userId);

        bool Exists(int toyId);
    }
}
