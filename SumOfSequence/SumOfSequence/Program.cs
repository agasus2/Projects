using System;
namespace SumOfSequence
{
    class Program
    {
        private const string UserPattern = "oreder.mantissa(e or E)(+ or - or nothing)power";
        private static void Main(string[] args)
        {
            UI();
        }

        public static void UI()
        {
            string bufferString;
  
            Console.WriteLine("Program for summing numbers in exponential format");

            Console.WriteLine("For correct input you must use this pattern - {0}", UserPattern);

            Console.WriteLine("Example : 1.12e21");

            Console.WriteLine("If you want see result, input \"=\"(without quotes) and press \"Enter\" button");

            Console.WriteLine("Input number in exponential format and press \"Enter\" button:");

            BigFloat result = new BigFloat();

            while (true)
            {
                bufferString = Console.ReadLine();
                if (BigFloat.IsExponentialFormat(bufferString))
                {
                    try
                    {
                        result += new BigFloat(bufferString);
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("to big exponential power");
                        continue;
                    }
                    catch (OutOfMemoryException) 
                    {
                        Console.WriteLine("big exponential power for your computer");
                        continue;
                    }
                }
                else if (bufferString == "=")
                {
                    Console.WriteLine(result.ToString());
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong number format, please input number which corresponds this pattern -\n{0}:", UserPattern);
                    continue;
                }
                Console.WriteLine("+");
            }
        }
    }  
}
