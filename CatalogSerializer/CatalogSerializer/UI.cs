using System;
using System.IO;
using System.Runtime.Serialization;

namespace CatalogSerializer
{
    public static class UI
    { 
        private const string Help = @"Please enter ""-help"" to see user's guide";

        public static void SerializationChoose(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            if (args.Length == 3)
            {
                SerializeCatalog(args);
            }
            else if (args.Length == 1 && args[0].ToLower() == "-help")
            {
                ShowUsersGiude();
            }
            else if (args.Length == 2)
            {
                DeserializeCatalog(args);
            }
            else
            {
                Console.WriteLine($"Wrong command. {Help}");
            }
        }

        private static void SerializeCatalog(string[] args)
        {
            string path = args[0].Trim('"');
            string fileName = args[1];
            string serializationFormat = args[2];

            try
            {
                if (Directory.Exists(path))
                {
                    MyDirectory dir = new MyDirectory(path);
                    MyDirectory.Init(dir);

                    switch (serializationFormat)
                    {
                        case "-bin":
                            MySerializer.SerializeBinary(dir, fileName);
                            Console.WriteLine("Binary serialization was successful");
                            break;
                        case "-xml":
                            MySerializer.SerializeXml(dir, fileName);
                            Console.WriteLine("Xml serialization was successful");
                            break;
                        default:
                            Console.WriteLine($"Wrong serialization format. {Help}");
                            break;
                    }
                }
                else Console.WriteLine("Directory not found");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Illegal characters in file name");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("File can't be overwriten");
            }
        }

        private static void DeserializeCatalog(string[] args)
        {
            string fileName = args[0];
            string serializationFormat = args[1];
            try
            {
                MyDirectory dir = MySerializer.DeserializeFromFile(fileName, serializationFormat);

                if (dir != null)
                {
                    PrintSubDirectoriesAndFiles(dir);
                }
                else
                {
                    Console.WriteLine($"File \"{fileName}\" does not exist, or wrong serialization format. {Help}");
                }
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine(@"The file is damaged, or not the result of the program ""CatalogSerializer""");
            }
            catch (SerializationException)
            {
                Console.WriteLine(@"Trying to deserialize file, serialized to another format");
            }
        }

        private static void ShowUsersGiude()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Help\Help.txt");

            using (FileStream rulesStream = new FileStream(path, FileMode.Open))
            {
                using (StreamReader rulesReader = new StreamReader(rulesStream))
                {
                    Console.WriteLine();

                    string buffer = rulesReader.ReadToEnd();

                    Console.WriteLine(buffer);
                    Console.WriteLine();
                }
            }
        }

        private static void PrintSubDirectoriesAndFiles(MyDirectory dir, string indentation = "")
        {
            string recursiveIndentation = indentation;

            Console.WriteLine(recursiveIndentation + $"Directory: {{Name: {dir.Name} }}");

            var subDirs = dir.SubDirectoryes;
            var files = dir.SubFiles;

            foreach (MyFile mf in files)
            {
                Console.WriteLine(recursiveIndentation + $"File: {{{mf.ToString()}}}");
            }
            if (subDirs.Count != 0)
            {
                foreach (MyDirectory d in subDirs)
                {
                    PrintSubDirectoriesAndFiles(d, recursiveIndentation + "  ");
                }
            }
        }
    }
}
