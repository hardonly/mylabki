using System;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace lab_14
{
    [Serializable]
    public abstract class GeneralСharacteristics
    {
        public string Name { get; set; }
        public int Area { get; set; }
    }
    [Serializable]
    [DataContract]
    public class Water : GeneralСharacteristics
    {
        [DataMember]
        public bool Salinity { get; set; }
        public void Info()
        {
            Console.WriteLine("Water");
            Console.WriteLine("salinity - " + Salinity);
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Water water = new Water() { Salinity = true };
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            Console.WriteLine("Binary:");
            using (FileStream fs = new FileStream("water.dat", FileMode.Create))
            {
                binaryFormatter.Serialize(fs, water);
                Console.WriteLine("Object serialized to binary.");
            }
            using (FileStream fs = new FileStream("water.dat", FileMode.Open))
            {
                Water binaryWater = (Water)binaryFormatter.Deserialize(fs);
                Console.WriteLine("Object deserialized from binary.");
                Console.WriteLine("Info about object:");
                binaryWater.Info();
            }
            SoapFormatter soapFormatter = new SoapFormatter();
            Console.WriteLine("\nSoap:");
            using (FileStream fs = new FileStream("water.soap", FileMode.Create))
            {
                soapFormatter.Serialize(fs, water);
                Console.WriteLine("Object serialized to soap.");
            }
            using (FileStream fs = new FileStream("water.soap", FileMode.Open))
            {
                Water soapWater = (Water)soapFormatter.Deserialize(fs);
                Console.WriteLine("Object deserialized from soap.");
                Console.WriteLine("Info about object:");
                soapWater.Info();
            }
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Water));
            Console.WriteLine("\nXml:");
            using (FileStream fs = new FileStream("water.xml", FileMode.Create))
            {
                xmlSerializer.Serialize(fs, water);
                Console.WriteLine("Object serialized to xml.");
            }
            using (FileStream fs = new FileStream("water.xml", FileMode.Open))
            {
                Water xmlWater = (Water)xmlSerializer.Deserialize(fs);
                Console.WriteLine("Object deserialized from xml.");
                Console.WriteLine("Info about object:");
                xmlWater.Info();
            }
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Water));
            Console.WriteLine("\nJson:");
            using (FileStream fs = new FileStream("water.json", FileMode.Create))
            {
                jsonSerializer.WriteObject(fs, water);
                Console.WriteLine("Object serialized to json.");
            }
            using (FileStream fs = new FileStream("water.json", FileMode.Open))
            {
                Water jsonWater = (Water)jsonSerializer.ReadObject(fs);
                Console.WriteLine("Object deserialized from json.");
                Console.WriteLine("Info about object:");
                jsonWater.Info();
            }
            Console.ReadLine();
            Console.ReadLine();
            Console.Clear();
            Water secondWater = new Water() { Salinity = false };
            Water thirdWater = new Water() { Salinity = true };
            Water[] waters = new Water[] { water, secondWater, thirdWater };
            using (FileStream fs = new FileStream("waters.dat", FileMode.Create))
            {
                binaryFormatter.Serialize(fs, waters);
                Console.WriteLine("Array serialized to binary");
            }
            using (FileStream fs = new FileStream("waters.dat", FileMode.Open))
            {
                Console.WriteLine("Array deserialized from binary.\n");
                Water[] binaryWaters = (Water[])binaryFormatter.Deserialize(fs);
                foreach (Water w in binaryWaters)
                {
                    w.Info();
                }
            }
            using (FileStream fs = new FileStream("waters.soap", FileMode.Create))
            {
                soapFormatter.Serialize(fs, waters);
                Console.WriteLine("\nArray serialized to soap");
            }
            using (FileStream fs = new FileStream("waters.soap", FileMode.Open))
            {
                Console.WriteLine("Array deserialized from soap.\n");
                Water[] soapWaters = (Water[])soapFormatter.Deserialize(fs);
                foreach (Water w in soapWaters)
                {
                    w.Info();
                }
            }
            XmlSerializer xmlArraySerializer = new XmlSerializer(typeof(Water[]));
            using (FileStream fs = new FileStream("waters.xml", FileMode.Create))
            {
                xmlArraySerializer.Serialize(fs, waters);
                Console.WriteLine("\nArray serialized to xml.");
            }
            using (FileStream fs = new FileStream("waters.xml", FileMode.Open))
            {
                Console.WriteLine("Array deserialized from xml.\n");
                Water[] xmlWaters = (Water[])xmlArraySerializer.Deserialize(fs);
                foreach (Water w in xmlWaters)
                {
                    w.Info();
                }
            }
            DataContractJsonSerializer jsonArraySerializer = new DataContractJsonSerializer(typeof(Water[]));
            using (FileStream fs = new FileStream("waters.json", FileMode.OpenOrCreate))
            {
                jsonArraySerializer.WriteObject(fs, waters);
                Console.WriteLine("\nArray serialized to json.");
            }
            using (FileStream fs = new FileStream("waters.json", FileMode.OpenOrCreate))
            {
                Water[] jsonWaters = (Water[])jsonArraySerializer.ReadObject(fs);

                foreach (Water w in jsonWaters)
                {
                    w.Info();
                }
            }
            Console.ReadLine();
            Console.ReadLine();
            Console.Clear();
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("waters.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNodeList childNodes = xRoot.SelectNodes("//Water/Salinity");
            Console.WriteLine("First xml request:\n");
            foreach(XmlNode n in childNodes)
            {
                Console.WriteLine(n.InnerText);
            }
            XmlNodeList nodeList = xRoot.SelectNodes("*");
            Console.WriteLine("\n\nSecond xml request:\n");
            foreach(XmlNode xml in nodeList)
            {
                Console.WriteLine(xml.OuterXml);
            }
            Console.ReadLine();
            Console.ReadLine();
            Console.Clear();
            XDocument xdoc = new XDocument(new XElement("phones",
                new XElement("phone", new XAttribute("name", "iPhone X"),
                new XElement("company", "Apple"), new XElement("price", "40000")),
                new XElement("phone", new XAttribute("name", "Samsung Galaxy S8"),
                new XElement("company", "Samsung"), new XElement("price", "33000"))));
            xdoc.Save("phones.xml");
            XDocument xmldoc = XDocument.Load("phones.xml");
            Console.WriteLine("1-st Linq to Xml request:\n");
            foreach (XElement phoneElement in xmldoc.Element("phones").Elements("phone"))
            {
                XAttribute nameAttribute = phoneElement.Attribute("name");
                XElement companyElement = phoneElement.Element("company");
                XElement priceElement = phoneElement.Element("price");
                if (nameAttribute != null && companyElement != null && priceElement != null)
                {
                    Console.WriteLine("Phone: {0}", nameAttribute.Value);
                    Console.WriteLine("Company: {0}", companyElement.Value);
                    Console.WriteLine("Price: {0}", priceElement.Value);
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n2-st Linq to Xml request:\n");
            foreach (XElement phoneElement in xmldoc.Element("phones").Elements("phone"))
            {
                XAttribute nameAttribute = phoneElement.Attribute("name");
                XElement companyElement = phoneElement.Element("company");
                XElement priceElement = phoneElement.Element("price");
                if (nameAttribute != null && companyElement != null && priceElement.Value == "40000")
                {
                    Console.WriteLine("Phone: {0}", nameAttribute.Value);
                    Console.WriteLine("Company: {0}", companyElement.Value);
                    Console.WriteLine("Price: {0}", priceElement.Value);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
