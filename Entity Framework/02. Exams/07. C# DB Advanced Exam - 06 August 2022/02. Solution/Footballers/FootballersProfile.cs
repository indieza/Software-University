namespace Footballers
{
    using AutoMapper;

    using Footballers.Data.Models;
    using Footballers.DataProcessor.ImportDto;

    public class FootballersProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE OR RENAME THIS CLASS
        public FootballersProfile()
        {
            this.CreateMap<Footballer, FootballerImportDto>();
            this.CreateMap<Coach, CoachImportDto>();
        }
    }
}