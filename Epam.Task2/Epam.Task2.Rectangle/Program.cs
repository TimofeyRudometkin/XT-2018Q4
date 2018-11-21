using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2._1.Rectangle
{
    class Program
    {
        private static void AreaOfARectungle()
        {
            int sidea;
            int sideb;

            //Цикл повтора всей программы
            while (true)
            {
                Console.WriteLine("Введите длину стороны 'а' прямоугольника.");

                //Прописываем два оператора try-catch для игнорирования
                //ввода пользователем данных вызывающих исключение,
                //т.е. при вводе букв в значение второй стороны не
                //потребуется вновь вводить значения первой стороны

                //Цикл ввода длины стороны 'a'
                while (true)
                {
                    try
                    {
                        sidea = int.Parse(Console.ReadLine());

                        if (sidea > 0)
                        {
                            break;
                        }

                        Console.WriteLine();
                        Console.WriteLine("Длины сторон должны быть больше 0. Повторите ввод длины стороны 'a'.");
                    }
                    catch (FormatException) { }//Оператор catch не заполняем, т.к. игнорируем возможность
                                               //ввода строки вида "абвг" или нецелых чисел.
                    catch (OverflowException)
                    {
                        Console.WriteLine("Введите число поменьше, это для меня великовато");
                    }
                }

                Console.WriteLine("Введите длину стороны 'b' прямоугольника.");

                //Цикл ввода длины стороны 'b'
                while (true)
                {
                    try
                    {
                        sideb = int.Parse(Console.ReadLine());

                        if (sideb > 0)
                        {
                            break;
                        }

                        Console.WriteLine();
                        Console.WriteLine("Длины сторон должны быть больше 0. Повторите ввод длины стороны 'b'.");

                    }
                    catch (FormatException) { }//Оператор catch не заполняем, т.к. игнорируем возможность
                                               //ввода строки вида "абвг" или нецелых чисел.
                    catch (OverflowException)
                    {
                        Console.WriteLine("Введите число поменьше, это для меня великовато");
                    }
                }

                //при больших значениях сторон площадь не верна, 
                //исключения при этом не выпадает, подумать на досуге.
                Console.WriteLine($"Площадь прямоугольника \"{sidea * sideb}\"");

                Console.WriteLine("Введите любые символы для продолжения или пустую " +
                    "строку для завершения программы");

                if (Console.ReadLine() == "")
                {
                    break;
                }
            }
            
        }
        static void Main(string[] args)
        {
            AreaOfARectungle();
        }
    }
}
