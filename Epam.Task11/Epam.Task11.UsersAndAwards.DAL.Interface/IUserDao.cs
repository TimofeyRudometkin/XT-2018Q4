using Epam.Task11.UsersAndAwards.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task11.UsersAndAwards.DAL.Interface
{
    public interface IUserDao
    {
        void Add(User user);

        bool Delete(int Id);

        bool Update(User user);

        bool ToAward(int userId, int awardId);

        User GetById(int Id);

        int[] GetAwardsIdByUserId(int userId);

        IEnumerable<User> GetAll();
    }
}
