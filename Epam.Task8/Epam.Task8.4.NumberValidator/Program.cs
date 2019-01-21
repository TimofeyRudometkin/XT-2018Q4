using System;
using System.Text.RegularExpressions;

namespace Epam.Task8._4.NumberValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string _string;
            string _numberInNormalNotation = @"^[-]{0,1}\d+[.]{0,1}\d*$";
            string _numberInScientificNotation = @"^[-]{0,1}\d+[.]{0,1}\d*[e][-]{0,1}\d+$|";
            Regex RegNumberInNormalNotation = new Regex(_numberInNormalNotation, RegexOptions.IgnoreCase);
            Regex RegNumberInScientificNotation = new Regex(_numberInScientificNotation, RegexOptions.IgnoreCase);

            Console.WriteLine("Enter number.");
            _string = Console.ReadLine();
            if (RegNumberInNormalNotation.IsMatch(_string))
            {
                Console.WriteLine("This number is in normal notation.");
            }
            else if(RegNumberInScientificNotation.IsMatch(_string))
            {
                Console.WriteLine("This number is in scientific notation.");
            }
            else
            {
                Console.WriteLine("This is not a number.");
            }
        }
    }
}
