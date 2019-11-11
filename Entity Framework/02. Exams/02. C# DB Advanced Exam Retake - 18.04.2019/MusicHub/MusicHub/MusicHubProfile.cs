namespace MusicHub
{
    using AutoMapper;
    using MusicHub.Data.Models;
    using MusicHub.DataProcessor.DTO.ImportDtos;

    public class MusicHubProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public MusicHubProfile()
        {
            this.CreateMap<ImportWriterDto, Writer>();
            this.CreateMap<ImportProducerDto, Producer>();
            this.CreateMap<ImportSongDto, Song>();
        }
    }
}