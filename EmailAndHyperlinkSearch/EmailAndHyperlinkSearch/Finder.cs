using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace EmailAndHyperlinkSearch
{

    public class Finder
    {
        public event EventHandler<EmailAndHyperlinkEventArgs> EmailFound;
        public event EventHandler<EmailAndHyperlinkEventArgs> HyperlinkFound;

        private const string Symbols = @"?_\-$^&";
        public static string EmailPattern {get;} =
            @"(([a-z0-9" + Symbols + @"]+)|([a-z0-9\." + Symbols + @"]+\.[a-z0-9" + Symbols + @"]+))" +
            @"@[a-z0-9\." + Symbols + @"]+\.[a-z]+";
        public static string HyperlinkPattern { get; } = @"((http://)|(https://)|(www))[a-z0-9\./]+\.[a-z/]+";

   

        public void FindInFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
                {
                    using (StreamReader fileReader = new StreamReader(fileStream))
                    {
                        string buffer = fileReader.ReadToEnd();

                        RunSearchTasks(buffer, fileName);
                    }
                }
            }
            else 
            {
               throw new FileNotFoundException("File not found");
            }
        }

        public void FindOnWebSite(string link)
        {
            WebClient web = new WebClient();

            web.Proxy = new WebProxy();

            try
            {
                string text = web.DownloadString(link);

                RunSearchTasks(text, link);
            }
            catch (Exception) 
            {
               throw new WebException("Web site not found or access denied");
            }
        
        }
        public void RunSearchTasks(string text, string location)
        {
            Task emailTask = Task.Run(() => Find(text, location, EmailFound, EmailPattern, "e-mails"));
            Task hyperlinkTask = Task.Run(() => Find(text, location, HyperlinkFound, HyperlinkPattern, "hyperlinks"));
            hyperlinkTask.Wait();
            emailTask.Wait();
        }

        private void Find(string text, string fromThere, EventHandler<EmailAndHyperlinkEventArgs> currentEvent, string pattern, string whatToFind)
        {
            var match = Regex.Match(text, pattern, RegexOptions.IgnoreCase);

            if (match.Length != 0)
            {
                while (match.Success)
                {
                    currentEvent?.Invoke(this, new EmailAndHyperlinkEventArgs(match.Value.Trim() + $" In {fromThere}", match.Value.Trim()));
                    Thread.Sleep(50);
                    match = match.NextMatch();
                }
            }
            else
            {
                currentEvent?.Invoke(this, new EmailAndHyperlinkEventArgs( $"{fromThere} does not contain {whatToFind}", null));
            }

        }

    }
}
