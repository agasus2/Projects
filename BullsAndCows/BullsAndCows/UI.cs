using System;
using System.IO;

namespace BullsAndCows
{
    static class UI
    {
     
        public static void Play()
        {
            int sequenceSize = ReadNumber("Input sequence size (1 - 6): ", a => a > 0 && a <= 6,
                "Icorrect sequence size");

            SequencesContainer sc = new SequencesContainer(sequenceSize);
            string current = sc.GetNextSequence();

            Console.Write($"Make up the sequence with {sequenceSize} digits and press any key");
            Console.ReadKey(true);
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("Program's try: " + current);

                int bulls = ReadNumber(@"Input count of ""bulls"": ", a => a >= 0 && a <= sequenceSize,
                    "Please input correct count of bulls");

                if (bulls == sequenceSize)
                {
                    Console.WriteLine($"I won in {sc.CountOfTry} attempts. You'r sequence: " + current);
                    break;
                }

                int cows = ReadNumber(@"Input count of ""cows"": ", a => a >= 0 && a <= sequenceSize,
                              "Please input correct count of cows");

                if (!СonditionIsMet(bulls, cows, a => a > sequenceSize, "Bulls and cows count can't be bigger then sequnce size") ||
                    !СonditionIsMet(bulls, cows, a => a == sequenceSize && cows == 1, "Impossible situation"))
                {
                    continue;
                }

                sc.ExcludeByBullsAndCows(current, bulls, cows);

                current = sc.GetNextSequence();

                if (sc.AvailableSequencesCount == 0)
                {
                    Console.WriteLine("Please read the rules. If you are sure of the correctness of your actions," +
                        "\nplease inform the developer about the error");
                    break;
                }

            }
        }

        public static void ShowRules()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Help\Rules.txt");

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

        private static int ReadNumber(string prompt, Func<int, bool> condition, string errorMessage)
        {
            do
            {
                Console.Write(prompt);
                int res;

                if (int.TryParse(Console.ReadLine(), out res) && condition(res))
                {
                    return res;
                }
                Console.WriteLine(errorMessage);
            } while (true);

        }
        private static bool СonditionIsMet(int bulls, int cows, Func<int, bool> condition, string errorMessage)
        {

            if (condition(bulls + cows))
            {
                Console.WriteLine(errorMessage);
                return false;
            }
            return true;

        }
  

    }
}
