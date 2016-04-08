using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindLargeNumber
{
    /********************************************************************************
    3.  Write a function that accepts a variable number of integers,
        finds the largest number that’s divisible by 5, and prints that number to the screen;
        If none of the integers are divisible the print “None Found”
    *********************************************************************************/
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int[] numberSet;

            try {
                // from http://stackoverflow.com/questions/2959161/convert-string-to-int-array-using-linq
                numberSet = input.Split(' ').Select(int.Parse).ToArray();
            }
            catch (System.FormatException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                return;
            }
            // int? allows nulls as a value for int.
            int? largeNumber = FindLargestNumber(numberSet);

            if (largeNumber == null)
            {
                Console.WriteLine("None Found.");
            }
            else
            {
                Console.WriteLine(largeNumber);
            }

            Console.ReadLine();
        }

        static int? FindLargestNumber(int[] numberSet)
        {
            // from http://stackoverflow.com/questions/19522225/how-to-set-null-value-to-int-in-c
            int? largestNumber = null;

            foreach (int number in numberSet)
            {
                if (number % 5 == 0)
                {
                    if ((largestNumber == null) || (number > largestNumber))
                    {
                        largestNumber = number;
                    }
                }
            }

            return largestNumber;
        }
    }
}
