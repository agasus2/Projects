using System;
using System.IO;
using CatalogSerializer;

namespace CatalogSerializerTests
{
    static class TestCatalog
    {
        private static string _path =$"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\\Temp\\";

        public static string[] Drives { get; } = Environment.GetLogicalDrives();
        public static MyDirectory StandardDir { get; private set; }

        public static void Create()
        {

            if (Drives != null)
            {
                Directory.CreateDirectory(_path + @"CatalogSerializerTestFolder\TestDir1\TestDir2");
                File.Create(_path + @"CatalogSerializerTestFolder\File.txt").Close();
                File.Create(_path + @"CatalogSerializerTestFolder\TestDir1\File.doc").Close();
                File.Create(_path + @"CatalogSerializerTestFolder\TestDir1\TestDir2\File.pdf").Close();
                GetStandardDirectory();
            }
        }
        public static void GetStandardDirectory()
        {
            if (Drives != null)
            {
                StandardDir = new MyDirectory(_path + @"CatalogSerializerTestFolder");

                StandardDir.SubDirectoryes.Add(new MyDirectory(_path + @"CatalogSerializerTestFolder\TestDir1\"));
                StandardDir.SubFiles.Add(new MyFile(_path + @"CatalogSerializerTestFolder\File.txt"));

                StandardDir.SubDirectoryes[0].SubDirectoryes.Add(new MyDirectory(_path + @"CatalogSerializerTestFolder\TestDir1\TestDir2"));
                StandardDir.SubDirectoryes[0].SubFiles.Add(new MyFile(_path + @"CatalogSerializerTestFolder\TestDir1\File.doc"));

                StandardDir.SubDirectoryes[0].SubDirectoryes[0].SubFiles.Add(new MyFile(_path + @"CatalogSerializerTestFolder\TestDir1\TestDir2\File.pdf"));


            }
        }




        public static void Delete()
        {
            if (Drives != null)
            {
                Directory.Delete(_path, true);
            }
        }


    }
}
