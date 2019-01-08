using Epam.Task._7._1.Users.DAL;
using Epam.Task._7._1.Users.DAL.Interface;
using Epam.Task7._1.Users.BLL.Interface;
using Epam.Task7._1.Users.Entities;
using System.Collections.Generic;

namespace Epam.Task7._1.Users.BLL
{
    public class UserLogic: IUserLogic
    {
        private readonly IUserDao _userDAO;
        public UserLogic(IUserDao userDao)
        {
            _userDAO = userDao;
        }
        public void Add(User user)
        {
            _userDAO.Add(user);
        }
        public void Delete(int Id)
        {
            _userDAO.Delete(Id);
        }
        public void Update(User user)
        {
            _userDAO.Update(user);
        }
        public User GetById(int Id)
        {
            return _userDAO.GetById(Id);
        }
        public IEnumerable<User> GetAll()
        {
            return _userDAO.GetAll();
        }
    }
}
