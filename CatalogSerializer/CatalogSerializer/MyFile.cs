using System;
using System.IO;
using System.Xml.Serialization;

namespace CatalogSerializer
{
    [Serializable]
    public class MyFile : IEquatable<MyFile>
    {
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("CreationTime")]
        public DateTime CreationTime { get; set; }
        [XmlElement("Attributes")]
        public string Attributes { get; set; }

        [NonSerialized]
        private FileInfo _currentFile;

        public MyFile()
        {

        }

        public MyFile(string location)
        {
                _currentFile = new FileInfo(location);
                Name = _currentFile.Name;
                CreationTime = _currentFile.CreationTime;
                Attributes = _currentFile.Attributes.ToString();
        }

        public override string ToString()
        {
            return $"Name: {Name}" + " " + $"Creation time: {CreationTime}"  + " " +$"Attributes: {Attributes}";
        }

        #region iEquatable

        public bool Equals(MyFile other)
        {
            if (other == null)
            {
                return false;
            }

            if (Name == other.Name &&
                CreationTime == other.CreationTime &&
                Attributes == other.Attributes)
            {
                return true;
            }
            return false;
        }
        public bool Equals(FileInfo other)
        {
            if (other == null)
            {
                return false;
            }

            if (Name == other.Name &&
                CreationTime == other.CreationTime &&
                Attributes == other.Attributes.ToString())
            {
                return true;
            }
            return false;
        }
        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj is MyFile)
            {
                MyFile myFielObj = obj as MyFile;

                if (myFielObj == null)
                {
                    return false;
                }
                else
                {
                    return Equals(myFielObj);
                }
            }
            else 
            {
                FileInfo myFielObj = obj as FileInfo;

                if (myFielObj == null)
                {
                    return false;
                }
                else
                {
                    return Equals(myFielObj);
                }
            }
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        #endregion
    }
}
