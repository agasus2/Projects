using System;

namespace BullsAndCows
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to bulls and cows");
            while (true)
            {

                Console.WriteLine("1.Rules \n2.Play \n3.Exit");

                int choice;
                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case 1:
                        UI.ShowRules();
                        break;
                    case 2:
                        UI.Play();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Enter correct number");
                        break;
                }
            }
        }
    }


  }
