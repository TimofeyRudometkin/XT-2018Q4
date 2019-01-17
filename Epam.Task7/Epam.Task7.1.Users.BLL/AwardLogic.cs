using Epam.Task7._1.Users.BLL.Interface;
using Epam.Task7._1.Users.DAL.Interface;
using Epam.Task7._1.Users.Entities;
using System;
using System.Collections.Generic;

namespace Epam.Task7._1.Users.BLL
{
    public class AwardLogic : IAwardLogic
    {
        private const string ALL_AWARDS_CASHE_KEY = "GetAllAwards";
        private readonly IAwardDao _awardDAO;
        private readonly ICacheLogic _cacheLogic;

        public AwardLogic(IAwardDao awardDao, ICacheLogic cacheLogic)
        {
            _awardDAO = awardDao;
            _cacheLogic = cacheLogic;
        }
        public void Add(Award award)
        {
            try
            {
                if (award == null)
                {
                    throw new System.Exception("Award is null.");
                }
                else if (award.Title == "")
                {
                    throw new System.Exception("Awards must be named.");
                }
                _cacheLogic.Delete(ALL_AWARDS_CASHE_KEY);
                _awardDAO.Add(award);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + e.Source + Environment.NewLine + e.TargetSite + Environment.NewLine + e.StackTrace);
                throw new Exception("Can't add user to text file.");
            }
        }

        public void DeleteAward(int Id)
        {
            if (_awardDAO.DeleteAward(Id))
            {
                _cacheLogic.Delete(ALL_AWARDS_CASHE_KEY);
                Console.WriteLine($"Award with Id = {Id} is deleted.");
            }
        }

        public void UpdateAward(Award award)
        {
            try
            {
                if (award.Title == "")
                {
                    throw new System.Exception("Awards must be named.");
                }
                if (_awardDAO.UpdateAward(award))
                {
                    _cacheLogic.Delete(ALL_AWARDS_CASHE_KEY);
                    Console.WriteLine($"Award with Id = {award.Id} is updated.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + e.Source + Environment.NewLine + e.TargetSite + Environment.NewLine + e.StackTrace);
                throw new Exception("Can't update award at text file.");
            }
        }

        public Award GetAwardById(int Id)
        {
            return _awardDAO.GetAwardById(Id);
        }

        public IEnumerable<Award> GetAllAwards()
        {
            var cacheResult = _cacheLogic.Get<IEnumerable<Award>>(ALL_AWARDS_CASHE_KEY);

            if (cacheResult == null)
            {
                var result = _awardDAO.GetAllAwards();
                _cacheLogic.Add(ALL_AWARDS_CASHE_KEY, result);
                return result;
            }
            return cacheResult;
        }

        public Dictionary<int, Award> GetDictionaryOfAwards()
        {
            return _awardDAO.GetDictionaryOfAwards();
        }
    }
}
