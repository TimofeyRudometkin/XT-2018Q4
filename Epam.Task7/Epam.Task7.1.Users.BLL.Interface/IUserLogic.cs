using Epam.Task7._1.Users.Entities;
using System.Collections.Generic;

namespace Epam.Task7._1.Users.BLL.Interface
{
    public interface IUserLogic
    {
        void Add(User user);

        void Delete(int Id);

        void Update(User user);

        void ToAward(int userId, int awardId);

        User GetById(int Id);

        int[] GetAwardsIdByUserId(int userId);

        IEnumerable<User> GetAll();

        int[] GetAllAwardsIdFromUser(int userId);
    }
}
