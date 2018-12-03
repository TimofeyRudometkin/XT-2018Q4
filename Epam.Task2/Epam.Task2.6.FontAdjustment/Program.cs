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
        private enum enFont { None=0, Bold=1, Italic= 2, Underline=4 }
        private static void FontAdjustment()
        {
            Console.WriteLine("Label options: None");

            int tracing;
            enFont Font = enFont.None;

            while (true)
            { 
                Console.WriteLine("Enter:"+ System.Environment.NewLine+"        1: bold" + System.Environment.NewLine + 
                    "        2: italic" + System.Environment.NewLine + "        3: underline" + 
                    System.Environment.NewLine + "        0: for exit from this program.");

                try
                {
                    tracing = int.Parse(Console.ReadLine());
                    if (tracing==0)
                    {
                        break;
                    }
                    switch (tracing)
                    {
                        case 1:
                            if ((Font & enFont.Bold) == enFont.Bold)
                            {
                                Font = Font ^ enFont.Bold;
                            }
                            else
                            {
                                Font = Font | enFont.Bold;
                            }
                            break;
                        case 2:
                            if ((Font & enFont.Italic) == enFont.Italic)
                            {
                                Font = Font ^ enFont.Italic;
                            }
                            else
                            {
                                Font = Font | enFont.Italic;
                            }
                            break;
                        case 3:
                            if ((Font & enFont.Underline) == enFont.Underline)
                            {
                                Font = Font ^ enFont.Underline;
                            }
                            else
                            {
                                Font = Font | enFont.Underline;
                            }
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Label options: {0}", Font);
                    continue;
                }
                Console.WriteLine("Label options: {0}", Font);
            }
        }
        static void Main(string[] args)
        {
            FontAdjustment();
        }
    }
}
