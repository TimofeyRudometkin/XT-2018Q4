using System;
using System.Text.RegularExpressions;

namespace Epam.Task8._3.EmailFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            string _string = @"Иван: ivan@mail.ru, Петр: p_ivanov@mail.rol.ru";
            string RegString = @"([A-Za-zА-ЯЁа-яё0-9][A-Za-zА-ЯЁа-яё0-9\.\-_]*[@][A-Za-zА-ЯЁа-яё]{2,6}[.][A-Za-zА-ЯЁа-яё0-9\-]+[.][A-Za-zА-ЯЁа-яё0-9\-]+)" +
                               @"|([A-Za-zА-ЯЁа-яё0-9][A-Za-zА-ЯЁа-яё0-9.\-_]*[@][A-Za-zА-ЯЁа-яё]{2,6}[.][A-Za-zА-ЯЁа-яё0-9\-]+)";
            Regex regex = new Regex(RegString, RegexOptions.IgnoreCase);
            Console.WriteLine($"Text template:{Environment.NewLine}{_string}");
            if (regex.IsMatch(_string))
            {
                Console.WriteLine("Found e-mail addresses:");
                foreach(var email in regex.Matches(_string))
                {
                    Console.WriteLine(email);
                }
            }
            else
            {
                Console.WriteLine("E-mail address was not found.");
            }

            Console.WriteLine("Enter text.");
            _string = Console.ReadLine();
            if (regex.IsMatch(_string))
            {
                Console.WriteLine("Found e-mail addresses:");
                foreach (string email in regex.Matches(_string))
                {
                    Console.WriteLine(email);
                }
            }
            else
            {
                Console.WriteLine("E-mail address was not found.");
            }
        }
    }
}
