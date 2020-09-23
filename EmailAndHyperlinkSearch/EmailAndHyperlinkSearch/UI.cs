using System;

namespace EmailAndHyperlinkSearch
{
    public static class UI
    {
        private static Finder finder = new Finder();

        private static EventHandler<EmailAndHyperlinkEventArgs> _emailDel;
        private static EventHandler<EmailAndHyperlinkEventArgs> _hlinkDel;
        public static void ProgramStart()
        {
            Console.WriteLine("Welcome to e-mail and hyperlink finder");

            EventSubscribing();

            while (true)
            {
                Console.WriteLine("Please select the action");
                Console.WriteLine("1.Find in file\n2.Find on web site\n3.Exit");

                int userChoise;
                int.TryParse(Console.ReadLine(), out userChoise);
                try
                {
                    switch (userChoise)
                    {
                        case 1:
                            UserChoiseProcessing("Input file name: ", finder.FindInFile);
                            break;
                        case 2:
                            UserChoiseProcessing(@"Input full(with http:// or https://) link to web site: ", finder.FindOnWebSite);
                            break;
                        case 3:
                            EventUnsubscribing();
                            Environment.Exit(0);
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void EventSubscribing()
        {
            _emailDel = CreateEventSubscriber("Email Founder");
            finder.EmailFound += _emailDel;

            _hlinkDel = CreateEventSubscriber("Hyperlink Founder"); 
            finder.HyperlinkFound += _hlinkDel;
        }

        private static EventHandler<EmailAndHyperlinkEventArgs> CreateEventSubscriber(string str)
        {
            return (object sender, EmailAndHyperlinkEventArgs e) => Console.WriteLine($"{str}: {e.msg} ");
        }

        private static void EventUnsubscribing()
        {
            finder.EmailFound -= _emailDel;
            finder.HyperlinkFound -= _hlinkDel;
        }

        private static void UserChoiseProcessing(string msg, Action<string> act)
        {
            Console.Write(msg);
            string userChoise = Console.ReadLine();
            act(userChoise.Trim());
        }
    }
}
