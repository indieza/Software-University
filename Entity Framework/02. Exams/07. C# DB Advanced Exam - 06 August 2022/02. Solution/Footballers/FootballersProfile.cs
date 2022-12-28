namespace Footballers
{
    using AutoMapper;

    using Footballers.Data.Models;
    using Footballers.DataProcessor.ImportDto;

    using System;
    using System.Globalization;
    using System.Linq;

    public class FootballersProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE OR RENAME THIS CLASS
        public FootballersProfile()
        {
            this.CreateMap<FootballerImportDto, Footballer>()
                .ForMember(x => x.ContractStartDate, y => y.MapFrom(src => DateTime.ParseExact(
                    src.ContractStartDate,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture)))
                .ForMember(x => x.ContractEndDate, y => y.MapFrom(src => DateTime.ParseExact(
                    src.ContractEndDate,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture)));
            this.CreateMap<CoachImportDto, Coach>()
                .ForMember(x => x.Footballers, y => y.Ignore());
            this.CreateMap<TeamImportDto, Team>()
                .ForMember(x => x.TeamsFootballers, y => y.Ignore());
        }
    }
}