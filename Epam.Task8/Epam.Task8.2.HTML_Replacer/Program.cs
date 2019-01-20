using System;
using System.Text.RegularExpressions;

namespace Epam.Task8._2.HTML_Replacer
{
    class Program
    {
        static void Main(string[] args)
        {
            string _string = "<b>Это</b> текст <i>с</i> <font color=\"red\">HTML</font> кодами<img src=\"https://ktonanovenkogo.ru/image/veb.png\" />";
            string RegString = @"[<][^>]+[>]";
            Regex regex = new Regex(RegString, RegexOptions.IgnoreCase);
            Console.WriteLine($"Original text:{Environment.NewLine}{_string}");
            Console.WriteLine($"The result of the replacement:{Environment.NewLine}{regex.Replace(_string, "_")}");
            Console.WriteLine("Input text.");
            _string = Console.ReadLine();
            Console.WriteLine($"The result of the replacement:{Environment.NewLine}{regex.Replace(_string, "_")}");
        }
    }
}
