using System;
using System.Text.RegularExpressions;

namespace Epam.Task8._1.DateExistance
{
    class Program
    {
        static void Main(string[] args)
        {
            string _string = "RegExr was created by gskinner.com, and is proudly hosted by Media Temple. Edit the Expression & Text to see matches.Roll over " +
                "matches or the expression for details.PCRE & Javascript flavors of 12.04.3443 RegEx are supported. The side bar includes a Cheatsheet, full " +
                "34.54.3453 31-12-2014. Reference, and Help.You can also Save & Share with the Community, and view patterns you create or favorite in My Patter" +
                "ns. Explore results with the Tools below.Replace & List output custom results.Details lists capture groups.Explain describes your expression" +
                " in plain English.";
            string RegString = @"([0-2][0-9]\-|[3][0-1]\-)([0][0-9]|[1][0-2])\-([0-9]{4})";
            Regex regex = new Regex(RegString, RegexOptions.IgnoreCase);

            if (regex.IsMatch(_string))
            {
                Console.WriteLine($"The text \"{_string}\" contains date.{Environment.NewLine}");
            }
            else
            {
                Console.WriteLine($"The text \"{_string}\" doesn't contain date.{Environment.NewLine}");
            }

            _string = "RegExr was created by gskinner.com, and is proudly hosted by Media Temple. Edit the Expression & Text to see matches.Roll over " +
                "matches or the expression for details.PCRE & Javascript flavors of RegEx are supported. The side bar includes a Cheatsheet, full " +
                "34.54.3453 31.12.2014. Reference, and Help.You can also Save & Share with the Community, and view patterns you create or favorite in My Patter" +
                "ns. Explore results with the Tools below.Replace & List output custom results.Details lists capture groups.Explain describes your expression" +
                " in plain English.";
            if (regex.IsMatch(_string))
            {
                Console.WriteLine($"The text \"{_string}\" contains date.{Environment.NewLine}");
            }
            else
            {
                Console.WriteLine($"The text \"{_string}\" doesn't contain date.{Environment.NewLine}");
            }

            Console.WriteLine("Enter the text containing the date in the format dd-mm-yyyy: 2016 year will come 01-01-2016.");
            _string = Console.ReadLine();
            if (regex.IsMatch(_string))
            {
                Console.WriteLine($"The text \"{_string}\" contains date.{Environment.NewLine}");
            }
            else
            {
                Console.WriteLine($"The text \"{_string}\" doesn't contain date.{Environment.NewLine}");
            }

        }
    }
}
