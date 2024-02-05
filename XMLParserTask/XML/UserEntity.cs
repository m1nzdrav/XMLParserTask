using System.Xml.Serialization;

namespace XMLParser.XML;

public class UserEntity
{
    [XmlElement("fio")] public string fio { get; set; }
    [XmlElement("email")] public string email { get; set; }
}