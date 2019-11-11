using AutoMapper;
using Cinema.Data.Models;
using Cinema.DataProcessor.ImportDto;

namespace Cinema
{
    public class CinemaProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public CinemaProfile()
        {
            this.CreateMap<ImportMovieDto, Movie>();
            this.CreateMap<ImportHallsSeatsDto, Hall>();
            this.CreateMap<ImportProjectionDto, Projection>();
        }
    }
}