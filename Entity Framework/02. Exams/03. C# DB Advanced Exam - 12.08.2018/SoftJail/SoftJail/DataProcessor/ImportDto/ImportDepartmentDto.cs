namespace SoftJail.DataProcessor.ImportDto
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ImportDepartmentDto
    {
        public string Name { get; set; }

        public ICollection<ImportCellDto> Cells { get; set; }
    }
}