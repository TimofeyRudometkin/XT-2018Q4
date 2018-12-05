using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3._5.Employee
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            int experience;
            while (true)
            {
                try
                {
                    Employee E = new Employee();
                    Console.WriteLine("Input your surname or 'Surname' for exit");
                    E.Surname = Console.ReadLine();
                    if (E.Surname == "Surname")
                    {
                        break;
                    }
                    Console.WriteLine("Input your name.");
                    E.Name = Console.ReadLine();
                    Console.WriteLine("Input your patronymic.");
                    E.Patronymic = Console.ReadLine();
                    Console.WriteLine("Input your birthday at format 'dd.mm.yyyy'.");
                    E.Birthday = Console.ReadLine();
                    Console.WriteLine("Input your work experience.");
                    if (int.TryParse(Console.ReadLine(), out experience))
                    {
                        E.Experience = experience;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Experience", experience.ToString(),
                    "The number you enter must be integer, not float or text.");
                    }
                    Console.WriteLine("Input your position at work.");
                    E.Position = Console.ReadLine();
                    employees.Add(E);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e.Message + Environment.NewLine);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"The entered data of the wrong format.{Environment.NewLine}");
                }
            }
            foreach (Employee element in employees)
            {
                Console.WriteLine($"{ element.Surname} {element.Name} {element.Patronymic} was born on {element.Birthday} " +
                    $"and he (she) was {element.Age} years old. {element.Experience} of wich spent in the workplace. Now work at a " +
                    $"position {element.Position}");
            }

        }
    }
}