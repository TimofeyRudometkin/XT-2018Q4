using System.Collections.Generic;
using Epam.Task7._1.Users.Entities;

namespace Epam.Task._7._1.Users.DAL.Interface
{
    public interface IUserDao
    {
        void Add(User user);
        
        bool Delete(int Id);
        
        bool Update(User user);
        
        User GetById(int Id);
        
        IEnumerable<User> GetAll();
    }
}