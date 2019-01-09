using Epam.Task._7._1.Users.DAL;
using Epam.Task._7._1.Users.DAL.Interface;
using Epam.Task7._1.Users.BLL;
using Epam.Task7._1.Users.BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task7._1.Users.Common
{
    public static class DependencyResolver
    {
        private static IUserDao _userDao;

        public static IUserDao UserDao => _userDao ?? (_userDao = new UserFakeDao());

        private static IUserLogic _userLogic;

        public static IUserLogic UserLogic => _userLogic ?? (_userLogic = new UserLogic(UserDao, CacheLogic));

        private static ICacheLogic _cacheLogic;

        public static ICacheLogic CacheLogic => _cacheLogic ?? (_cacheLogic = new CacheLogic());

    }
}
