using Epam.Task7._1.Users.Entities;
using System.Collections.Generic;

namespace Epam.Task7._1.Users.BLL.Interface
{
    public interface IUserLogic
    {
        void Add(User user);

        void Delete(int Id);

        void Update(User user);

        User GetById(int Id);

        IEnumerable<User> GetAll();
    }
}
