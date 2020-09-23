using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace CatalogSerializer
{
    public static class MySerializer
    {
        private static XmlSerializer _xmlFormatter = new XmlSerializer(typeof(MyDirectory));
        private static BinaryFormatter _binaryFormatter = new BinaryFormatter();

        public static void SerializeXml(MyDirectory dir, string fileName)
        {
            string newFileName = FileNameBuild(fileName, ".xml");

            using (FileStream fs = new FileStream($"{newFileName}", FileMode.Create))
            {
                _xmlFormatter.Serialize(fs, dir);
            }
        }

        private static string FileNameBuild(string fileName, string expansion)
        {
            if (fileName.TrimEnd('.').Contains("."))
            {
                return fileName.TrimEnd('.');
            }
            else
            {
                return fileName.TrimEnd('.') + $"{expansion}";
            }
        }

        private static MyDirectory DeserializeXml(string fileName)
        {
            using (FileStream fs = new FileStream($"{fileName}", FileMode.Open))
            {
                var desDirectory = _xmlFormatter.Deserialize(fs);

                return desDirectory as MyDirectory;
            }
        }

        public static void SerializeBinary(MyDirectory dir, string fileName)
        {
            string newFileName = FileNameBuild(fileName, ".dat");

            using (FileStream fs = new FileStream($"{newFileName}", FileMode.Create))
            {
                _binaryFormatter.Serialize(fs, dir);
            }
        }

        private static MyDirectory DeserializeBinary(string fileName)
        {
            using (FileStream fs = new FileStream($"{fileName}", FileMode.Open))
            {
                var desDirectory = _binaryFormatter.Deserialize(fs);

                return desDirectory as MyDirectory;
            }
        }

        public static MyDirectory DeserializeFromFile(string fileName, string format)
        {
            if (File.Exists($"{fileName}"))
            {
                if (format == "-xml")
                {
                    return DeserializeXml(fileName);
                }
                else if (format == "-bin")
                {
                    return DeserializeBinary(fileName);
                }
            }

            return null;
       
        }

       
    }
}

