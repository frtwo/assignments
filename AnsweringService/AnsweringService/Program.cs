using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnsweringService
{
    class Program
    {
        static void Main(string[] args)
        {
            bool done = true;

            do
            {
                int choice = GetSingleDigit();
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("We’re transferring you to an operator.");
                        done = true;
                        break;
                    case 1:
                        Console.WriteLine("Our sales offices are closed at this time.");
                        done = true;
                        break;
                    case 3:
                        Console.WriteLine("Please record your message now.");
                        done = true;
                        break;
                    case 5:
                        Console.WriteLine("Goodbye.");
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Sorry. you’ve entered an invalid option.");
                        done = false;
                        break;
                }
            } while (!done);

            Console.ReadLine();
        }

        static void DisplayMenu()
        {
            Console.WriteLine("Welcome to <Company Name>'s answering service.");
            Console.WriteLine("Please select from one of the following choices:");
            Console.WriteLine("0 -- Contact Operator");
            Console.WriteLine("1 -- Contact Sales Office");
            Console.WriteLine("3 -- Record a Message");
            Console.WriteLine("5 -- Exit answering service");
            Console.Write(">> ");
        }

        // loops until a valid input (integer) is returned.
        static int GetSingleDigit()
        {
            DisplayMenu();
            string choice;
            do
            {
                choice = Console.ReadLine();

                // from http://stackoverflow.com/questions/894263/how-to-identify-if-a-string-is-a-number
                int n;
                if (int.TryParse(choice, out n))
                {
                    return n;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    DisplayMenu();
                }
            } while (true);

        }
    }
}
