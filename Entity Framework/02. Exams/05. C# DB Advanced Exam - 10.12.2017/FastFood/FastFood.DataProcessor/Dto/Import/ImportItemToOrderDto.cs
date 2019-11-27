using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace FastFood.DataProcessor.Dto.Import
{
    [XmlType("Item")]
    public class ImportItemToOrderDto
    {
        [XmlElement(ElementName = "Name")]
        [Required]
        public string Name { get; set; }

        [XmlElement(ElementName = "Quantity")]
        [Range(1, int.MaxValue), Required]
        public int Quantity { get; set; }
    }
}