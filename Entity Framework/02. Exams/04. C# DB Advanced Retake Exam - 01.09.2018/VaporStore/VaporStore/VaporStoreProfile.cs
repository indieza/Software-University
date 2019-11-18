namespace VaporStore
{
    using AutoMapper;
    using System;
    using System.Globalization;
    using VaporStore.Data.Enums;
    using VaporStore.Data.Models;
    using VaporStore.DataProcessor.Dtos.ImportPatterns;

    public class VaporStoreProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public VaporStoreProfile()
        {
            this.CreateMap<ImportUserWithCardsDto, User>();

            this.CreateMap<ImportCardToUserDto, Card>()
                .ForMember(x => x.Type, y => y.MapFrom(x => Enum.Parse(typeof(CardType), x.Type)));

            this.CreateMap<ImportPurchaseDto, Purchase>()
                .ForMember(x => x.Type, y => y.MapFrom(x => Enum.Parse(typeof(PurchaseType), x.Type)))
                .ForMember(x => x.ProductKey, y => y.MapFrom(x => x.Key))
                .ForMember(x => x.Date, y => y.MapFrom(x => DateTime.ParseExact(
                         x.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)));
        }
    }
}