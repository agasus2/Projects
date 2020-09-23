using CatalogSerializer;
using NUnit.Framework;
using System.IO;

namespace CatalogSerializerTests
{
    public class CatalogSerializerTests
    {
        
        private MyDirectory _desDir;
     

        [OneTimeSetUp]
        public void SetUp()
        {
            TestCatalog.Create();
        }

        [Category("Serializarion/Deserialization tests")]
        [TestCase("catalogD.xml")]
        public void Xml_Serialization_Deserialization_Equal_Test(string serFileName)
        {
      
            MySerializer.SerializeXml(TestCatalog.StandardDir, serFileName);
            _desDir = MySerializer.DeserializeFromFile(serFileName, "-xml");
            File.Delete(serFileName);

            Assert.That(_desDir, Is.EqualTo(TestCatalog.StandardDir));
        }

        [Category("Serializarion/Deserialization tests")]
        [TestCase("catalogD.dat")]
        public void Binary_Serialization_Deserialization_Equal_Test(string serFileName)
        {
            MySerializer.SerializeBinary(TestCatalog.StandardDir, serFileName);
            _desDir = MySerializer.DeserializeFromFile(serFileName, "-bin");
            File.Delete(serFileName);

            Assert.That(_desDir, Is.EqualTo(TestCatalog.StandardDir));
        }

        [OneTimeTearDown]
        public void DeleteTestCatalogs()
        { 
           TestCatalog.Delete();
        }
    }
}
