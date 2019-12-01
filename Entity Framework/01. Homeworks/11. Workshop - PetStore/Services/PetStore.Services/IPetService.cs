namespace PetStore.Services
{
    using System;
    using Data.Models;

    public interface IPetService
    {
        void BuyPet(Gender gender, DateTime dateOfBirth, decimal price, string description, int breedId, int categoryId);

        void SellPet(int petId, int userId);

        bool Exists(int petId);
    }
}
