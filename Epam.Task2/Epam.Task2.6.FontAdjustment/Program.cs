using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2._6.FontAdjustment
{
    class Program
    {
        [Flags]
        private enum enFontAdjustment { Bold, Italic, Underline }
        private static void FontAdjustment()
        {
            Console.WriteLine("Label options: None");

            int tracing;

            while (true)
            { 
                Console.WriteLine("Enter:"+ System.Environment.NewLine+"        1: bold" + System.Environment.NewLine + 
                    "        2: italic" + System.Environment.NewLine + "        3: underline" + 
                    System.Environment.NewLine + "        4: italic, underline"+ System.Environment.NewLine + 
                    "        0: for exit from this program.");

                try
                {
                    tracing = int.Parse(Console.ReadLine()) - 1;
                    if (tracing == -1)
                    {
                        break;
                    }
                }
                catch (FormatException)
                {
                    continue;
                }
                Console.WriteLine("Label options: " + (enFontAdjustment)tracing);
            }
        }
        static void Main(string[] args)
        {
            FontAdjustment();
        }
    }
}
