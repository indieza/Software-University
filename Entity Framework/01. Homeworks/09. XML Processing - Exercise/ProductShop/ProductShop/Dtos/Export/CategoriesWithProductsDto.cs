namespace ProductShop.Dtos.Export
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml.Serialization;

    [XmlType("Category")]
    public class CategoriesWithProductsDto
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "count")]
        public int Count { get; set; }

        [XmlElement(ElementName = "averagePrice")]
        public decimal? AveragePrice { get; set; }

        [XmlElement(ElementName = "totalRevenue")]
        public decimal? TotalRevenue { get; set; }
    }
}