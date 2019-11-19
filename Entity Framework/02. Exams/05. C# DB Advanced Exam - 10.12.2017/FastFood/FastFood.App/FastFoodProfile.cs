using AutoMapper;
using FastFood.DataProcessor.Dto.Import;
using FastFood.Models;
using FastFood.Models.Enums;
using System;
using System.Globalization;

namespace FastFood.App
{
    public class FastFoodProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public FastFoodProfile()
        {
            this.CreateMap<ImportEmployeeDto, Employee>();

            this.CreateMap<ImportItemDto, Item>();

            this.CreateMap<ImportOrderDto, Order>()
                .ForMember(x => x.DateTime, y => y.MapFrom(
                    x => DateTime.ParseExact(x.DateTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)))
                .ForMember(x => x.Type, y => y.MapFrom(
                    x => Enum.Parse(typeof(OrderType), x.Type)));
        }
    }
}