using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3._4.MyString
{
    class Program
    {
        static void Main(string[] args)
        {
            MyString my_String = new MyString();

            while (true)
            {
                my_String.Mystring = Console.ReadLine();
                Console.WriteLine(my_String.Mystring);
                try
                {
                    Console.WriteLine("Input string.");
                    my_String.Mystring = Console.ReadLine();
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e.Message + Environment.NewLine);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"The number you enter must be integer, not float or text.{Environment.NewLine}");
                }
                Console.WriteLine(my_String.Mystring);
            }
        }
    }
}
