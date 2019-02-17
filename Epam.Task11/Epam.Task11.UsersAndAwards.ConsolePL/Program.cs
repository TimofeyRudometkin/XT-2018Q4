using Epam.Task11.UsersAndAwards.BLL.Interface;
using Epam.Task11.UsersAndAwards.Common;
using Epam.Task11.UsersAndAwards.Entities;
using System;

namespace Epam.Task11.UsersAndAwards.ConsolePL
{
    public class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            var _userLogic = DependencyResolver.UserLogic;
            var _awardLogic = DependencyResolver.AwardLogic;
            var _siteUserLogic = DependencyResolver.SiteUserLogic;
            string[] _name = new string[10];
            _name[0] = "Alexander";
            _name[1] = "Nina";
            _name[2] = "Evgeny";
            _name[3] = "Tom";
            _name[4] = "Alicia";
            _name[5] = "Vasily";
            _name[6] = "Peter";
            _name[7] = "Alexey";
            _name[8] = "Egor";
            _name[9] = "Athanasius";

            string[] _award = new string[10];
            _award[0] = "Golden gramophone";
            _award[1] = "For valor";
            _award[2] = "The best grower";
            _award[3] = "The winner of the championship of dominoes";
            _award[4] = "The fastest";
            _award[5] = "The slowest";
            _award[6] = "Cleverest";
            _award[7] = "Most powerful";
            _award[8] = "Rescue a man";
            _award[9] = "The loudest";

            for (int i = 0; i < 3; i++)
            {
                AddUser(_userLogic, _name[random.Next(9)], random.Next(50), random.Next(11), random.Next(30));
            }
            for (int i = 0; i < 10; i++)
            {
                AddAward(_awardLogic, _award[i]);
            }
            Console.WriteLine(GetAwardById(_awardLogic, 0));
            ToAwardUser(_userLogic, 0, 0);
            ToAwardUser(_userLogic, 1, 1);
            ShowUsers(_userLogic, _awardLogic);
            ShowAwards(_awardLogic);
            DeleteUser(_userLogic, 3);
            DeleteUser(_userLogic, 2);
            DeleteAward(_awardLogic, 9);
            ShowUsers(_userLogic, _awardLogic);
            ShowAwards(_awardLogic);
            UpdateUser(_userLogic, _name[random.Next(9)], random.Next(50), random.Next(11), random.Next(30), 1);
            UpdateAward(_awardLogic, "GO HOME!", 4);
            ShowUsers(_userLogic, _awardLogic);
            ShowAwards(_awardLogic);
        }
        public static void AddUser(IUserLogic userLogic, string name, int Year, int Month, int Day)
        {
            DateTime dateTime = new DateTime();
            dateTime = DateTime.Now;
            dateTime = dateTime.AddYears(-Year);
            dateTime = dateTime.AddMonths(-Month);
            dateTime = dateTime.AddDays(-Day);
            User user = new User()
            {
                Name = name,
                DateOfBirthday = dateTime,
                Age = Age(dateTime),
            };
            userLogic.Add(user);
        }
        private static int Age(DateTime _dateOfBirthday)
        {
            if (_dateOfBirthday.Month > DateTime.Now.Month)
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
        public static void DeleteUser(IUserLogic userLogic, int Id)
        {
            userLogic.Delete(Id);
        }
        public static void UpdateUser(IUserLogic userLogic, string name, int Year, int Month, int Day, int Id)
        {
            DateTime dateTime = new DateTime();
            dateTime = DateTime.Now;
            dateTime = dateTime.AddYears(-Year);
            dateTime = dateTime.AddMonths(-Month);
            dateTime = dateTime.AddDays(-Day);
            User user = new User()
            {
                Id = Id,
                Name = name,
                DateOfBirthday = dateTime,
                Age = Age(dateTime),
            };
            userLogic.Update(user);
        }
        public static void ShowUsers(IUserLogic userLogic, IAwardLogic awardLogic)
        {
            Console.WriteLine($"Id Name DateOfBirthday Age");
            foreach (var user in userLogic.GetAll())
            {
                Console.Write(user);
                int[] listOfAwards = GetAwardsIdByUserId(userLogic, user.Id);
                if (!(listOfAwards == null))
                {
                    foreach (int awardId in listOfAwards)
                    {
                        Award award = new Award();
                        award = GetAwardById(awardLogic, awardId);
                        Console.Write($" award '{award.Title}' with id {award.Id}");
                    }
                }
                Console.WriteLine();
            }
        }
        public static void AddAward(IAwardLogic _awardLogic, string TitleOfAward)
        {
            Award award = new Award()
            {
                Title = TitleOfAward,
            };
            _awardLogic.Add(award);
        }
        public static void DeleteAward(IAwardLogic awardLogic, int Id)
        {
            awardLogic.DeleteAward(Id);
        }
        public static void UpdateAward(IAwardLogic awardLogic, string Title, int Id)
        {
            Award award = new Award()
            {
                Id = Id,
                Title = Title,
            };
            awardLogic.UpdateAward(award);
        }
        public static void ShowAwards(IAwardLogic awardLogic)
        {
            Console.WriteLine("Id Title");
            foreach (Award award in awardLogic.GetAllAwards())
            {
                Console.WriteLine(award);
            }
        }
        public static Award GetAwardById(IAwardLogic awardLogic, int Id)
        {
            return awardLogic.GetAwardById(Id);
        }
        public static int[] GetAwardsIdByUserId(IUserLogic userLogic, int userId)
        {
            return userLogic.GetAwardsIdByUserId(userId);
        }
        public static void ToAwardUser(IUserLogic userLogic, int userId, int awardId)
        {
            userLogic.ToAward(userId, awardId);
        }
        public static bool ToRemoveUserReward(IUserLogic userLogic, int userId, int awardId)
        {
            return userLogic.ToRemoveUserReward(userId, awardId);
        }
        public static bool AddImage(IUserLogic userLogic, int userId, string pathOfTheAddedImage)
        {

            return userLogic.AddImage(userId, pathOfTheAddedImage);
        }
        public static bool AddSiteUser(ISiteUserLogic siteUserLogic, string siteUserName, string siteUserPassword)
        {
            return siteUserLogic.Add(siteUserName, siteUserPassword);
        }
        public static bool DeleteSiteUser(ISiteUserLogic siteUserLogic, string siteUserName)
        {
            return siteUserLogic.Delete(siteUserName);
        }
        public static bool ToAwardSiteUser(ISiteUserLogic siteUserLogic, string siteUserName, int awardId)
        {
            return siteUserLogic.ToAwardSiteUser(siteUserName, awardId);
        }
        public static bool ToRemoveSiteUserReward(ISiteUserLogic siteUserLogic, string siteUserName, int awardId)
        {
            return siteUserLogic.ToRemoveSiteUserReward(siteUserName, awardId);
        }
        public static SiteUser GetBySiteUserName(ISiteUserLogic siteUserLogic, string siteUserName)
        {
            return siteUserLogic.GetBySiteUserName(siteUserName);
        }
        public static int[] GetAwardsIdBySiteUsername(ISiteUserLogic siteUserLogic, string siteUserName)
        {
            return siteUserLogic.GetAwardsIdBySiteUsername(siteUserName);
        }
        public static void ShowSiteUsers(ISiteUserLogic siteUserLogic, IAwardLogic awardLogic)
        {
            Console.WriteLine($"Name AwardId");
            foreach (var siteUser in siteUserLogic.GetAll())
            {
                Console.Write(siteUser);
                int[] listOfAwards = GetAwardsIdBySiteUsername(siteUserLogic, siteUser.Name);
                if (!(listOfAwards == null))
                {
                    foreach (int awardId in listOfAwards)
                    {
                        Award award = new Award();
                        award = GetAwardById(awardLogic, awardId);
                        Console.Write($" award '{award.Title}' with id {award.Id}");
                    }
                }
                Console.WriteLine();
            }
        }
        public static void ShowSiteUsersAdmin(ISiteUserLogic siteUserLogic, IAwardLogic awardLogic)
        {
            foreach (var siteUser in siteUserLogic.GetAll())
            {
                Console.Write(siteUser.ToStringAdmin());
                int[] listOfAwards = GetAwardsIdBySiteUsername(siteUserLogic, siteUser.Name);
                if (!(listOfAwards == null))
                {
                    foreach (int awardId in listOfAwards)
                    {
                        Award award = new Award();
                        award = GetAwardById(awardLogic, awardId);
                        Console.Write($" award '{award.Title}' with id {award.Id}");
                    }
                }
                Console.WriteLine();
            }
        }
        public static bool AddImageToSiteUser(ISiteUserLogic siteUserLogic, string siteUserName, string pathOfTheAddedImage)
        {
            return siteUserLogic.AddImage(siteUserName, pathOfTheAddedImage);
        }

        public static bool CorrectionOfAccessPermission(ISiteUserLogic siteUserLogic, string siteUserName, bool admin)
        {
            return siteUserLogic.CorrectionOfAccessPermission(siteUserName, admin);
        }
    }
}
