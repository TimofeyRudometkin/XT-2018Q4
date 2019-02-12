using Epam.Task11.UsersAndAwards.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task11.UsersAndAwards.BLL.Interface
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
    }
}
