namespace VaporStore.DataProcessor.Dtos.Export
{
    using System.Xml.Serialization;

    [XmlType("Purchase")]
    public class ExportPurchaseByTypeDto
    {
        public string Card { get; set; }

        public string Cvc { get; set; }

        public string Date { get; set; }

        [XmlElement(ElementName = "Game")]
        public ExportGameDto Game { get; set; }
    }
}