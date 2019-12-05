namespace VaporStore.DataProcessor.Dtos.Export
{
    using System.Xml.Serialization;

    [XmlType("Purchase")]
    public class ExportPurchaseByTypeDto
    {
        [XmlElement(ElementName = "Card")]
        public string Card { get; set; }

        [XmlElement(ElementName = "Cvc")]
        public string Cvc { get; set; }

        [XmlElement(ElementName = "Date")]
        public string Date { get; set; }

        [XmlElement(ElementName = "Game")]
        public ExportGameDto Game { get; set; }
    }
}