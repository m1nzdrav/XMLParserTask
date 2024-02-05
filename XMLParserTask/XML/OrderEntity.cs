using System.Xml.Serialization;

namespace XMLParser.XML;

[Serializable, XmlRoot("order")]
public class OrderEntity
{
    [XmlElement("no")] public int No { get; set; }
    [XmlElement("reg_date")] public DateOnly Reg_date { get; set; }
    [XmlElement("sum")] public decimal Sum { get; set; }
    [XmlElement("product")] public List<ProductEntity> Products { get; set; }
    [XmlElement("user")] public UserEntity User { get; set; }
}