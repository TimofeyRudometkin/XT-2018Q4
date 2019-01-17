using Epam.Task7._1.Users.DAL.Interface;
using Epam.Task7._1.Users.Entities;
using Epam.Task7._1.Users.Entities.Exception;
using System.Collections.Generic;
using System.Linq;

namespace Epam.Task._7._1.Users.DAL
{
    public class AwardMemoryDao : IAwardDao
    {
        public static readonly Dictionary<int, Award> _repoAwards = new Dictionary<int, Award>();
        public void Add(Award award)
        {
            if (_repoAwards.Keys.Any())
            {
                award.Id = _repoAwards.Keys.Max() + 1;
                _repoAwards.Add(award.Id, award);
            }
            else
            {
                _repoAwards.Add(0, award);
            }
        }
        public bool DeleteAward(int Id)
        {
            return _repoAwards.Remove(Id);
        }
        public bool UpdateAward(Award award)
        {
            if (!_repoAwards.ContainsKey(award.Id))
            {
                return false;
            }

            _repoAwards[award.Id] = award;
            return true;
        }
        public Award GetAwardById(int Id)
        {
            return _repoAwards.TryGetValue(Id, out var award)
                ? award
                : null;
        }
        public IEnumerable<Award> GetAllAwards()
        {
            return _repoAwards.Values;
        }
        public Dictionary<int,Award> GetDictionaryOfAwards()
        {
            return _repoAwards;
        }
    }
}
