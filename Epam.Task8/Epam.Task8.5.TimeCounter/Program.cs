using System;
using System.Text.RegularExpressions;

namespace Epam.Task8._5.TimeCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            string _string;
            string _time = @"[^0-9][0-1]{0,1}[0-9][:][0-5][0-9]|[^0-9][2][0-4][:][0-5][0-9]|^[0-1]{0,1}[0-9][:][0-5][0-9]|^[2][0-4][:][0-5][0-9]";
            Regex RegTime = new Regex(_time, RegexOptions.IgnoreCase);

            Console.WriteLine("Enter text.");
            _string = Console.ReadLine();
            Console.WriteLine($"Time in the text present {RegTime.Matches(_string).Count} times.");

        }
    }
}
