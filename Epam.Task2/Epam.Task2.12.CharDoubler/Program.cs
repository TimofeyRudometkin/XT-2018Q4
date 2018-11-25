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
                Console.WriteLine("Введите первую строку или пустую строку для выхода из программы: ");
                StringBuilder StringBuilder1 = new StringBuilder(Console.ReadLine());
                if (StringBuilder1.Length == 0)
                {
                    break;
                }
                Console.WriteLine();
                Console.Write("Введите вторую строку: ");
                StringBuilder StringBuilder2 = new StringBuilder(Console.ReadLine());
                Console.WriteLine();

                //оставим во второй строке только уникальные символы, знаки пунктуации и разделители также удаляем
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

                //Удваиваем символы первой строки входящие во вторую
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
                Console.WriteLine("Результирующая строка: "+StringBuilder1);
            }
        }
        static void Main(string[] args)
        {
            FCharDoubler();
        }
    }
}
