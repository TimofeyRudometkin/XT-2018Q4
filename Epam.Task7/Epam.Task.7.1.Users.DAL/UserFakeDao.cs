using Epam.Task7._1.Users.Entities;
using System.Collections.Generic;
using System.Linq;
using Epam.Task._7._1.Users.DAL.Interface;

namespace Epam.Task._7._1.Users.DAL
{
    public class UserFakeDao : IUserDao
    {
        private static readonly Dictionary<int, User> _repoUsers = new Dictionary<int, User>();
        public void Add(User user)
        {
            var lastId = _repoUsers.Keys.Any()
                ? _repoUsers.Keys.Max()
                : 0;

            user.Id = ++lastId;

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
