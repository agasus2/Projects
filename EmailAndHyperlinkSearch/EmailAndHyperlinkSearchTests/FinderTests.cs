using NUnit.Framework;
using EmailAndHyperlinkSearch;
using System.IO;
using System.Reflection;

namespace EmailAndHyperlinkSearchTests
{
    public class FinderTests
    {

        private const string StandardValues = @"agas06@mail.ru , agasya06@gmail.com , maxym.aharkov@nure.ua , karen12@list.ru , Example@example.ru , aharkov.m@dbbest.com " +
                                    @"Email.com.ua@mail.ru , ?symbols?_-$^&@mail.ru , avs.ymbol.s?_-$.^&@mail.ru , goodemail@mia.com.ua , goodemail@?avsymbols?_-$^&.come" +
                                    @"badEmail@mail.com , Email@mail.ru , badEmail@masdjh.comand , https://www.cyberforum.ru/csharp/. , www.google.com , https://ru.wikipedia.org/ , http://ru.wikipedia.org/ ," +
                                   @"www.as.com/index.html ";

      
        private const string ResourceLocation = "EmailAndHyperlinkSearchTests.TestFile.txt";

        Finder testFinder = new Finder();

        [SetUp]
        public void EventsSubscribe()
        {
            testFinder.EmailFound += Pattern_Test;
            testFinder.HyperlinkFound += Pattern_Test;
        }

        [Test]
        public void Email_And_Hyperlink_Founder_Test()
        {
            string _text = ReadFromFileInResources();

            testFinder.RunSearchTasks(_text, ResourceLocation);
        }

        public void Pattern_Test(object sender, EmailAndHyperlinkEventArgs e)
        {
            Assert.That(StandardValues.Contains(e.Value), Is.EqualTo(true));
        }

        private string ReadFromFileInResources()
        {
            if (File.Exists("TestFile.txt"))
            {
                var assembly = Assembly.GetExecutingAssembly();

                using (Stream stream = assembly.GetManifestResourceStream(ResourceLocation))
                using (StreamReader fileReader = new StreamReader(stream))
                {
                    return fileReader.ReadToEnd();
                }
            }

            return null;
        }

        [TearDown]
        public void EventsUnsubscribe()
        {
            testFinder.EmailFound -= Pattern_Test;
            testFinder.HyperlinkFound -= Pattern_Test;
        }

    }
}
