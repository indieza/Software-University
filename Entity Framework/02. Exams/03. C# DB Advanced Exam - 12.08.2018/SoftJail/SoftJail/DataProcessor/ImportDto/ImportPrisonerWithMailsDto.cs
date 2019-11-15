namespace SoftJail.DataProcessor.ImportDto
{
    using SoftJail.Data.Models;
    using System.Collections.Generic;

    public class ImportPrisonerWithMailsDto
    {
        public string FullName { get; set; }

        public string Nickname { get; set; }

        public int Age { get; set; }

        public string IncarcerationDate { get; set; }

        public string ReleaseDate { get; set; }

        public decimal? Bail { get; set; }

        public int? CellId { get; set; }

        public ICollection<Mail> Mails { get; set; }
    }
}