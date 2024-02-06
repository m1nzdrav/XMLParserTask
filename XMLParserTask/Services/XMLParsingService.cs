using System.Xml;
using System.Xml.Serialization;
using XMLParser.XML;
using XMLParserTask.Data;
using XMLParserTask.Model;

namespace XMLParser.Services;

[Serializable]
public class Orders
{
    private List<Order> orders;
}

public class XMLParsingService
{
    public static ShoppingCartEntity ParseData(string nameXml)
    {
        StringReader test = new StringReader(File.ReadAllText(nameXml));
        ShoppingCartEntity? mapperXml =
            (ShoppingCartEntity)new XmlSerializer(typeof(ShoppingCartEntity), new XmlRootAttribute("orders"))
                .Deserialize(
                    new StringReader(File.ReadAllText(nameXml)))!;
        test.Dispose();
        
        return mapperXml;
    }
}