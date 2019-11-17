namespace SoftJail.DataProcessor.ImportDto
{
    using SoftJail.Data.Models;
    using System.Collections.Generic;

    public class ImportDepartmentCellsDto
    {
        public string Name { get; set; }

        public ICollection<Cell> Cells { get; set; }
    }
}