using Epam.Task._7._1.Users.DAL;
using Epam.Task._7._1.Users.DAL.Interface;
using Epam.Task7._1.Users.BLL.Interface;
using Epam.Task7._1.Users.Entities;
using System.Collections.Generic;

namespace Epam.Task7._1.Users.BLL
{
    public class UserLogic: IUserLogic
    {
        private const string ALL_USERS_CACHE_KEY = "GetAllUsers";
        private readonly IUserDao _userDAO;
        private readonly ICacheLogic _cacheLogic;

        public UserLogic(IUserDao userDao, ICacheLogic cacheLogic)
        {
            _userDAO = userDao;
            _cacheLogic = cacheLogic;
        }
        public void Add(User user)
        {
            try
            {
                if (user == null)
                {
                    throw new System.Exception("User is null.");
                }
                else if ((user.Name == "") || (user.DateOfBirthday==null))
                {
                    throw new System.Exception("Some fields of User are blank.");
                }
                _cacheLogic.Delete(ALL_USERS_CACHE_KEY);
                _userDAO.Add(user);
            }
            catch
            {
                
            }
        }
        public void Delete(int Id)
        {
            _userDAO.Delete(Id);
        }
        public void Update(User user)
        {
            try
            {
                if ((user.Name == "") || (user.DateOfBirthday == null))
                {
                    throw new System.Exception("Some fields of User are blank.");
                }
                _userDAO.Update(user);
            }
            catch
            {

            }
        }
        public User GetById(int Id)
        {
            return _userDAO.GetById(Id);
        }
        public IEnumerable<User> GetAll()
        {
            var cacheResult = _cacheLogic.Get<IEnumerable<User>>(ALL_USERS_CACHE_KEY);

            if (cacheResult == null)
            {
                var result = _userDAO.GetAll();
                _cacheLogic.Add(ALL_USERS_CACHE_KEY, result);
                return result;
            }
            return cacheResult;
        }
    }
}
