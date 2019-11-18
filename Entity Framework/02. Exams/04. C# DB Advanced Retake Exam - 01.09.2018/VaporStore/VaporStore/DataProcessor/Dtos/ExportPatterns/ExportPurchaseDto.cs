using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dtos.ExportPatterns
{
    [XmlType("Purchase")]
    public class ExportPurchaseDto
    {
        [XmlElement("Card")]
        public string Card { get; set; }

        [XmlElement("Cvc")]
        public string Cvc { get; set; }

        [XmlElement("Date")]
        public string Date { get; set; }

        public ExportGameDto Game { get; set; }
    }
}