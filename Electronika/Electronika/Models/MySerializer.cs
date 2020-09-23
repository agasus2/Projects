using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Electronika.Models
{
    public static class MySerializer
    {
        public static void SerializeXml<T>(object obj, string fileName) where T : class
        {
            XmlSerializer _xmlFormatter = new XmlSerializer(typeof(T));

            using (FileStream fs = new FileStream($"{fileName}", FileMode.Create))
            {
                _xmlFormatter.Serialize(fs, obj);
            }
        }

  
        public static T DeserializeXml<T>(string fileName) where T : class
        {
            XmlSerializer _xmlFormatter = new XmlSerializer(typeof(T));

            using (FileStream fs = new FileStream($"{fileName}", FileMode.Open))
            {
                try
                {
                    var desConfig = _xmlFormatter.Deserialize(fs);

                    return desConfig as T;
                }
                catch (InvalidOperationException)
                {
                    throw;
                }
               
            }
        }

  

    }
}
