using Epam.Task7._1.Users.BLL.Interface;
using Epam.Task7._1.Users.Common;
using Epam.Task7._1.Users.Entities;
using System;

namespace Epam.Task7._1.Users.ConsolePL
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            var userLogic = DependencyResolver.UserLogic;
            string[] name = new string[10];
            name[0] = "Alexander";
            name[1] = "Nina";
            name[2] = "Evgeny";
            name[3] = "Tom";
            name[4] = "Alicia";
            name[5] = "Vasily";
            name[6] = "Peter";
            name[7] = "Alexey";
            name[8] = "Egor";
            name[9] = "Athanasius";

            for (int i = 0; i < 3; i++)
            {
                AddUser(userLogic, name[random.Next(9)], random.Next(50), random.Next(11), random.Next(30));
                userLogic.GetAll();
                userLogic.GetAll();
                userLogic.GetAll();
            }

            ShowUsers(userLogic);
        }
        private static void AddUser(IUserLogic userLogic, string name, int Year, int Month, int Day)
        {
            DateTime dateTime = new DateTime();
            dateTime = DateTime.Now;
            dateTime = dateTime.AddYears(-Year);
            dateTime = dateTime.AddMonths(-Month);
            dateTime = dateTime.AddDays(-Day);
            var user = new User()
            {
                Name = name,
                DateOfBirthday = dateTime,
                Age = Age(dateTime),
            };
            userLogic.Add(user);
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
