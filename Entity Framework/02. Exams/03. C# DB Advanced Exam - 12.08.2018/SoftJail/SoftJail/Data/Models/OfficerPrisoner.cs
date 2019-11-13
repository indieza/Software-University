namespace SoftJail.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    public class OfficerPrisoner
    {
        [ForeignKey("Prisoner"), Required]
        public int PrisonerId { get; set; }

        public Prisoner Prisoner { get; set; }

        [ForeignKey("Officer"), Required]
        public int OfficerId { get; set; }

        public Officer Officer { get; set; }
    }
}