using Epam.Task._7._1.Users.DAL;
using Epam.Task._7._1.Users.DAL.Interface;
using Epam.Task7._1.Users.BLL;
using Epam.Task7._1.Users.BLL.Interface;
using Epam.Task7._1.Users.DAL.Interface;
using Epam.Task7.Users.DAL.TextFiles;
using System.Configuration;

namespace Epam.Task7._1.Users.Common
{
    public static class DependencyResolver
    {
        private static IUserDao _userDao;

        public static IUserDao UserDao
        {
            get
            {
                var key = ConfigurationManager.AppSettings["DaoUserKey"];

                if (_userDao == null)
                {
                    switch (key.ToLower())
                    {
                        case "memory":
                            {
                                _userDao = new UserMemoryDao();
                                break;
                            }
                        case "textfiles":
                            {
                                _userDao = new UserTextFilesDao();
                                break;
                            }
                        default:
                            break;
                    }
                }
                return _userDao;
            }
        }

        private static IAwardDao _awardDao;

        public static IAwardDao AwardDao
        {

            get
            {
                var key = ConfigurationManager.AppSettings["DaoUserKey"];

                if(_awardDao == null)
                {
                    switch (key.ToLower())
                    {
                        case "memory":
                            {
                                _awardDao = new AwardMemoryDao();
                                break;
                            }
                        case "textfiles":
                            {
                                _awardDao = new AwardTextFilesDao();
                                break;
                            }
                        default:
                            break;
                    }
                }
                return _awardDao;
            }
        }

        private static IUserLogic _userLogic;

        public static IUserLogic UserLogic => _userLogic ?? (_userLogic = new UserLogic(UserDao, CacheLogic));

        private static IAwardLogic _awardLogic;

        public static IAwardLogic AwardLogic => _awardLogic ?? (_awardLogic = new AwardLogic(AwardDao, CacheLogic));

        private static ICacheLogic _cacheLogic;

        public static ICacheLogic CacheLogic => _cacheLogic ?? (_cacheLogic = new CacheLogic());

    }
}
