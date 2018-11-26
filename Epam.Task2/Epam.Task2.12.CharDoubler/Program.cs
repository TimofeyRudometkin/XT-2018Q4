using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2._12.CharDoubler
{
    class Program
    {
        private static void FCharDoubler()
        {
            while (true)
            {
                Console.WriteLine("Enter the first line or an empty line to exit the program: ");
                StringBuilder StringBuilder1 = new StringBuilder(Console.ReadLine());
                if (StringBuilder1.Length == 0)
                {
                    break;
                }
                Console.WriteLine();
                Console.Write("Enter the second line: ");
                StringBuilder StringBuilder2 = new StringBuilder(Console.ReadLine());
                Console.WriteLine();

                for (int i = 0; i < StringBuilder2.Length; i++)
                {
                    for (int j = i + 1; j < StringBuilder2.Length; j++)
                    {
                        if (StringBuilder2[i] == StringBuilder2[j])
                        {
                            StringBuilder2.Remove(j, 1);
                            j=j>0?j--:j;
                        }
                        if(char.IsPunctuation(StringBuilder2[i])|| char.IsSeparator(StringBuilder2[i]))
                        {
                            StringBuilder2.Remove(i, 1);
                            i=i>0?i--:i;
                        }
                    }
                }

                for(int i=0;i<StringBuilder1.Length;i++)
                {
                    for (int j = 0; j < StringBuilder2.Length; j++)
                    {
                        if(StringBuilder1[i]==StringBuilder2[j])
                        {
                            StringBuilder1.Insert(i + 1, StringBuilder2[j]);
                            i++;
                        }
                    }
                }
                Console.WriteLine("Resulting string: " + StringBuilder1);
            }
        }
        static void Main(string[] args)
        {
            FCharDoubler();
        }
    }
}
