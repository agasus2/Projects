using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace CatalogSerializer
{
    [Serializable]
    public class MyDirectory : IEquatable<MyDirectory>
    {
        [XmlElement("Name")]
        public string Name{ get; set; }
        [XmlElement("File")]
        public List<MyFile> SubFiles { get; set; } = new List<MyFile>();
        [XmlElement("SubDirectory")]
        public List<MyDirectory> SubDirectoryes{ get; set; } = new List<MyDirectory>();

        [NonSerialized]
        private DirectoryInfo _currentDir;

        public MyDirectory()
        {
        }

        public MyDirectory(string location)
        {
                _currentDir = new DirectoryInfo(location);
                Name = _currentDir.Name;
        }
     
        public static void Init(MyDirectory dir)
        {
            try
            {
                var dirs = dir._currentDir.GetDirectories();
                var files = dir._currentDir.GetFiles();
                foreach (FileInfo f in files)
                {
                    MyFile bufferFile = new MyFile(f.FullName);
                    dir.SubFiles.Add(bufferFile);
                }
                if (dirs.Length != 0)
                {
                    foreach (DirectoryInfo d in dirs)
                    {
                        MyDirectory buffDir = new MyDirectory(d.FullName);

                        dir.SubDirectoryes.Add(buffDir);
                        Init(buffDir);
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {

            }
            catch (PathTooLongException) 
            {

            }
            catch (IOException)
            {

            }
        }

        #region iEquatable

        private bool SubFilesEqual(List<MyFile> currList, List<MyFile> compList)
        {
            int index = 0;

            foreach (MyFile file in currList)
            {
                if (file.Equals(compList[index]))
                {
                    index++;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        private bool SubFilesEqual(List<MyFile> currList, FileInfo [] compArr)
        {
            int index = 0;

            foreach (MyFile file in currList)
            {
                if (file.Equals(compArr[index]))
                {
                    index++;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public bool Equals(DirectoryInfo other)
        {
            var subDirs = other.GetDirectories();

            if (other == null ||
                SubDirectoryes.Count != other.GetDirectories().Length ||
                SubFiles.Count != other.GetFiles().Length ||
                !SubFilesEqual(SubFiles, other.GetFiles()))
            {
                return false;
            }

            if (Name == other.Name)
            {
                int index = 0;

                foreach (MyDirectory dir in SubDirectoryes)
                {
                    if (dir.Equals(subDirs[index]))
                    {
                        index++;
                    }
                    else
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Equals(MyDirectory other)
        {
            if (other == null ||
                SubDirectoryes.Count != other.SubDirectoryes.Count ||
                SubFiles.Count != other.SubFiles.Count ||
                !SubFilesEqual(SubFiles, other.SubFiles))
            {
                return false;
            }

            if (Name == other.Name)
            {
                int index = 0;

                foreach (MyDirectory dir in SubDirectoryes)
                {
                    if (dir.Equals(other.SubDirectoryes[index]))
                    {
                        index++;
                    }
                    else
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj is MyDirectory)
            {
                MyDirectory myDirectoryObj = obj as MyDirectory;
                if (myDirectoryObj == null)
                {
                    return false;
                }
                else
                {
                    return Equals(myDirectoryObj);
                }
            }
            else 
            {
                DirectoryInfo dirInfoObj = obj as DirectoryInfo;

                if (dirInfoObj == null)
                {
                    return false;
                }
                else
                {
                    return Equals(dirInfoObj);
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
