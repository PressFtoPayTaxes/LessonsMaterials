using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlParsingLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            //XmlDocument xmlDocument = new XmlDocument();
            //xmlDocument.Load("data.xml");

            //XmlElement rootElement = xmlDocument.DocumentElement;

            //for(int i = 0; i < rootElement.ChildNodes.Count; i++)
            //{
            //    var currentCityElement = rootElement.ChildNodes[i] as XmlElement;

            //    var idElement = currentCityElement.GetElementsByTagName("id")[0] as XmlElement;
            //    if (idElement.GetAttribute("type") != "Guid") continue;

            //    var nameElement = currentCityElement.GetElementsByTagName("name")[0] as XmlElement;
            //    var latitudeElement = currentCityElement.GetElementsByTagName("latitude")[0] as XmlElement;
            //    var longitudeElement = currentCityElement.GetElementsByTagName("longitude")[0] as XmlElement;

            //    var city = new City()
            //    {
            //        Id = Guid.Parse(idElement.InnerText),
            //        Name = nameElement.InnerText,
            //        Latitude = double.Parse(latitudeElement.InnerText),
            //        Longitude = double.Parse(longitudeElement.InnerText)
            //    };
            //}

            City city = new City()
            {
                Name = "Астана",
                Latitude = 55.2,
                Longitude = 24.98
            };

            XmlDocument xmlDocument = new XmlDocument();
            var rootElement = xmlDocument.CreateElement("city");

            var idElement = xmlDocument.CreateElement("id");
            idElement.SetAttribute("type", "Guid");
            idElement.InnerText = city.Id.ToString();
            rootElement.AppendChild(idElement);

            var nameElement = xmlDocument.CreateElement("name");
            nameElement.InnerText = city.Name;
            rootElement.AppendChild(nameElement);

            var latitudeElement = xmlDocument.CreateElement("latitude");
            latitudeElement.InnerText = city.Latitude.ToString();
            rootElement.AppendChild(latitudeElement);

            var longitudeElement = xmlDocument.CreateElement("longitude");
            longitudeElement.InnerText = city.Longitude.ToString();
            rootElement.AppendChild(longitudeElement);

            xmlDocument.AppendChild(xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null));
            xmlDocument.AppendChild(rootElement);

            xmlDocument.Save("data2.xml");
        }
    }
}
