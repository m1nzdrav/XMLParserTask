using System.Xml.Serialization;

namespace XMLParser.XML;

public class ProductEntity
{
    [XmlElement("quantity")] public int Quantity { get; set; }
    [XmlElement("name")] public string Name { get; set; }
    [XmlElement("price")] public float Price { get; set; }
}