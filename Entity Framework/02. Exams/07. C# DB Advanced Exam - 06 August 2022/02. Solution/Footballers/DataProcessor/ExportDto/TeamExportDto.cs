using System;
using System.Collections.Generic;
using System.Text;

namespace Footballers.DataProcessor.ExportDto
{
    public class TeamExportDto
    {
        public string Name { get; set; }
        public ICollection<FootballerExportDto> Footballers { get; set; }
    }
}