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
        private static Dictionary<int, int[]> _repoUsersAwards = new Dictionary<int, int[]>();
        public void Add(User user)
        {
            if (_repoUsers.Keys.Any())
            {
                user.Id = _repoUsers.Keys.Max() + 1;
                _repoUsers.Add(user.Id, user);
            }
            else
            {
                _repoUsers.Add(0, user);
            }
            //var lastId = _repoUsers.Keys.Any()
            //    ? _repoUsers.Keys.Max()
            //    : 0;

            //user.Id = ++lastId;

            //if(user.Id > 300)
            //{
            //    System.Console.WriteLine("");
            //}
            //_repoUsers.Add(user.Id, user);
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

            if (_repoUsersAwards.ContainsKey(userId))
            {
                int[] listOfAwards = new int[_repoUsersAwards[userId].Length+1];
                listOfAwards = _repoUsersAwards[userId];
                listOfAwards[_repoUsersAwards[userId].Length] = awardId;
                _repoUsersAwards[userId] = listOfAwards;
            }
            else
            {
                int[] listOfAwards = new int[1];
                listOfAwards[0] = awardId;
                _repoUsersAwards.Add(userId, listOfAwards);
            }

            return true;
        }
        public User GetById(int Id)
        {
            return _repoUsers.TryGetValue(Id, out var user) 
                ? user 
                : null;
        }
        public int[] GetAwardsIdByUserId(int userId)
        {
            if (!_repoUsersAwards.ContainsKey(userId))
            {
                return null;
            }
            
            return _repoUsersAwards[userId];
        }
        public IEnumerable<User> GetAll()
        {
            return _repoUsers.Values;
        }
        public int[] GetAllAwardsIdFromUser(int userId)
        {
            if (_repoUsersAwards.ContainsKey(userId))
            {
                return _repoUsersAwards[userId];
            }
            else
            {
                return null;
            }
        }
    }
}
