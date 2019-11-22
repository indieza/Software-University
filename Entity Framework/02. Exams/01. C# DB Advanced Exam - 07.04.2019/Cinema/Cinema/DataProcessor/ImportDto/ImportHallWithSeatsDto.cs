using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Cinema.DataProcessor.ImportDto
{
    public class ImportHallWithSeatsDto
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Is4Dx")]
        public bool Is4Dx { get; set; }

        [JsonProperty("Is3D")]
        public bool Is3D { get; set; }

        [JsonProperty("Seats")]
        [Range(1, int.MaxValue)]
        public int SeatsCount { get; set; }
    }
}