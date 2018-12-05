using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3._1.Round
{
    class Program
    {
        static void Main(string[] args)
        {
            Round();
        }

        private static void Round()
        {
            Round R = new Round();
            while (true)
            {
                try
                {
                    Console.WriteLine("Input the value of radius or zero for end the program.");
                    R.Radius = float.Parse(Console.ReadLine());
                    if(R.Radius==0)
                    {
                        break;
                    }
                    Console.WriteLine($"Length of the circumscribed circle = {R.LengthOfTheCircumscribedCircle}");
                    Console.WriteLine($"The area of a circle = {R.TheAreaOfACircle + Environment.NewLine}");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine($"The number you enter must be greater than zero.{Environment.NewLine}");
                }
                catch (FormatException)
                {
                    Console.WriteLine($"The number you enter must be integer or a float, not text.{Environment.NewLine}");
                }
            }
        }
    }
}
