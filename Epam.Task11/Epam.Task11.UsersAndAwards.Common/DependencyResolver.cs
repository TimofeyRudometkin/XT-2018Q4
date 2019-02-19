using Epam.Task11.UsersAndAwards.BLL;
using Epam.Task11.UsersAndAwards.BLL.Interface;
using Epam.Task11.UsersAndAwards.DAL.Interface;
using Epam.Task11.UsersAndAwards.DAL.Memory;
using Epam.Task11.UsersAndAwards.DAL.SqlDB;
using Epam.Task11.UsersAndAwards.DAL.TextFiles;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task11.UsersAndAwards.Common
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
                        case "sql":
                            {
                                _userDao = new UserSqlDao();
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

                if (_awardDao == null)
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
                        case "sql":
                            {
                                _awardDao = new AwardSqlDao();
                                break;
                            }
                        default:
                            break;
                    }
                }
                return _awardDao;
            }
        }

        private static ISiteUserDao _siteUserDao;

        public static ISiteUserDao SiteUserDao
        {
            get
            {
                var key = ConfigurationManager.AppSettings["DaoUserKey"];

                if (_siteUserDao == null)
                {
                    switch (key.ToLower())
                    {
                        case "memory":
                            {
                                _siteUserDao = new SiteUserMemoryDao();
                                break;
                            }
                        case "textfiles":
                            {
                                _siteUserDao = new SiteUserTextFilesDao();
                                break;
                            }
                        case "sql":
                            {
                                _siteUserDao = new SiteUserSqlDao();
                                break;
                            }
                        default:
                            break;
                    }
                }
                return _siteUserDao;
            }
        }
        private static IUserLogic _userLogic;

        public static IUserLogic UserLogic => _userLogic ?? (_userLogic = new UserLogic(UserDao, CacheLogic));

        private static IAwardLogic _awardLogic;

        public static IAwardLogic AwardLogic => _awardLogic ?? (_awardLogic = new AwardLogic(AwardDao, CacheLogic));

        private static ICacheLogic _cacheLogic;

        public static ICacheLogic CacheLogic => _cacheLogic ?? (_cacheLogic = new CacheLogic());

        private static ISiteUserLogic _siteUserLogic;

        public static ISiteUserLogic SiteUserLogic => _siteUserLogic ?? (_siteUserLogic = new SiteUserLogic(SiteUserDao));
    }
}
