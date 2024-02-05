using System.Xml.Serialization;

namespace XMLParser.XML;

[Serializable, XmlRoot("orders")]
public class ShoppingCartEntity
{
    [XmlElement("order")] public List<OrderEntity> order { get; set; }
    
}