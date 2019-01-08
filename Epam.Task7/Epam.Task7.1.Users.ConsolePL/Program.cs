using Epam.Task7._1.Users.BLL;
using Epam.Task7._1.Users.BLL.Interface;
using Epam.Task7._1.Users.Common;
using Epam.Task7._1.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task7._1.Users.ConsolePL
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            var userLogic = DependencyResolver.UserLogic;
            DateTime dateTime = CreatingNewDate(random.Next(50), random.Next(11), random.Next(31));
            var user = new User
            {
                Name = "Sergey",
                DateOfBirthday = dateTime,
                Age = Age(dateTime),
            };

            userLogic.Add(user);
            for (int i = 0; i < 100; i++)
            {
                dateTime = CreatingNewDate(random.Next(50), random.Next(11), random.Next(31));
                user = new User
                {
                    Name = "Sergey",
                    DateOfBirthday = dateTime,
                    Age = Age(dateTime),
                };

                userLogic.Add(user);
            }
            ShowUsers(userLogic);
        }
        private static int Age(DateTime _dateOfBirthday)
        {
            if(_dateOfBirthday.Month > DateTime.Now.Month)
            {
                return DateTime.Now.Year - _dateOfBirthday.Year - 1;
            }
            else if (_dateOfBirthday.Month < DateTime.Now.Month)
            {
                return DateTime.Now.Year - _dateOfBirthday.Year;
            }
                return _dateOfBirthday.Day > DateTime.Now.Day
                    ? DateTime.Now.Year - _dateOfBirthday.Year - 1
                    : DateTime.Now.Year - _dateOfBirthday.Year;
        }

        private static DateTime CreatingNewDate(int Year, int Month, int Day)
        {
            DateTime dateTime = new DateTime();
            dateTime = DateTime.Now;
            dateTime = dateTime.AddYears(-Year);
            dateTime = dateTime.AddMonths(-Month);
            dateTime = dateTime.AddDays(-Day);
            return dateTime;
        }

        private static void ShowUsers(IUserLogic userLogic)
        {
            Console.WriteLine($"Id Name DateOfBirthday Age");
            foreach (var user in userLogic.GetAll())
            {
                Console.WriteLine(user);
            }
        }
    }
}
