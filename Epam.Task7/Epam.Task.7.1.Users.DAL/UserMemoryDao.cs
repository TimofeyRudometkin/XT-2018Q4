using Epam.Task7._1.Users.Entities;
using System.Collections.Generic;
using System.Linq;
using Epam.Task._7._1.Users.DAL.Interface;
using Epam.Task7._1.Users.Entities.Exception;

namespace Epam.Task._7._1.Users.DAL
{
    public class UserMemoryDao : IUserDao
    {
        private static readonly Dictionary<int, User> _repoUsers = new Dictionary<int, User>();
        public void Add(User user)
        {
            var lastId = _repoUsers.Keys.Any()
                ? _repoUsers.Keys.Max()
                : 0;

            user.Id = ++lastId;

            if(user.Id > 300)
            {
                throw new CriticalException();
            }
            _repoUsers.Add(user.Id, user);
        }
        public bool Delete(int Id)
        {
            return _repoUsers.Remove(Id);
        }
        public bool Update(User user)
        {
            if (!_repoUsers.ContainsKey(user.Id))
            {
                return false;
            }

            _repoUsers[user.Id] = user;
            return true;
        }
        public bool ToAward(int userId, int awardId)
        {
            if (!_repoUsers.ContainsKey(userId))
            {
                return false;
            }

            return true;
        }
        public User GetById(int Id)
        {
            return _repoUsers.TryGetValue(Id, out var user) 
                ? user 
                : null;
        }
        public IEnumerable<User> GetAll()
        {
            return _repoUsers.Values;
        }
    }
}
