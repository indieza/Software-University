namespace SoftJail.DataProcessor.ImportDto
{
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using System.Collections.Generic;

    public class ImportPrisonerDto
    {
        [JsonProperty("FullName")]
        public string FullName { get; set; }

        [JsonProperty("Nickname")]
        public string Nickname { get; set; }

        [JsonProperty("Age")]
        public int Age { get; set; }

        [JsonProperty("IncarcerationDate")]
        public string IncarcerationDate { get; set; }

        [JsonProperty("ReleaseDate")]
        public string ReleaseDate { get; set; }

        [JsonProperty("Bail")]
        public decimal? Bail { get; set; }

        [JsonProperty("CellId")]
        public int? CellId { get; set; }

        [JsonProperty("Mails")]
        public ICollection<Mail> Mails { get; set; }
    }
}