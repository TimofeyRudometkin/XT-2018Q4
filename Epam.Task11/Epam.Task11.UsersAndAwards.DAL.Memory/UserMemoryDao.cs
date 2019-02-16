using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task11.UsersAndAwards.DAL.Interface;
using Epam.Task11.UsersAndAwards.Entities;

namespace Epam.Task11.UsersAndAwards.DAL.Memory
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
                int[] listOfAwards = new int[_repoUsersAwards[userId].Length + 1];
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
        public bool ToRemoveUserReward(int userId, int awardId)
        {
            if (_repoUsersAwards.ContainsKey(userId))
            {
                int[] arrayOfAwards = _repoUsersAwards[userId];
                int[] arrayOfAwards1 = new int[arrayOfAwards.Length];
                int count = 0;
                for(int i=0; i<arrayOfAwards.Length; i++)
                {
                    if(arrayOfAwards[i] == awardId)
                    {
                        arrayOfAwards1[i] = -1;
                        count++;
                    }
                }
                if(count == arrayOfAwards.Length)
                {
                    _repoUsersAwards.Remove(userId);
                }
                else
                {
                    int[] arrayOfAwards2 = new int[arrayOfAwards1.Length-count];
                    count = 0;
                    for (int i=0; i<arrayOfAwards1.Length; i++)
                    {
                        if(arrayOfAwards1[i]!=(-1))
                        {
                            arrayOfAwards2[i - count] = arrayOfAwards1[i];
                            count++;
                        }
                    }
                    _repoUsersAwards[userId] = arrayOfAwards2;
                }
                return true;
            }
            return false;
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
        public bool AddImage(int userId, string pathOfTheAddedImage)
        {
            string _pathOfServerFolder = $@"{AppDomain.CurrentDomain.BaseDirectory}/Content";
            string _pathOfTheServerImage = $@"{_pathOfServerFolder} id - {userId}.jpg";
            if (File.Exists(_pathOfTheServerImage))
            {
                File.Delete(_pathOfTheServerImage);
                File.Copy(pathOfTheAddedImage, _pathOfServerFolder);
            }
            else
            {
                File.Copy(pathOfTheAddedImage, _pathOfServerFolder);
            }
            return true;
        }
    }
}
