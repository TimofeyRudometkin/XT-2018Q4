using Epam.Task11.UsersAndAwards.BLL.Interface;
using Epam.Task11.UsersAndAwards.DAL.Interface;
using Epam.Task11.UsersAndAwards.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task11.UsersAndAwards.BLL
{
    public class SiteUserLogic : ISiteUserLogic
    {
        private readonly ISiteUserDao _siteUserDAO;

        public SiteUserLogic(ISiteUserDao siteUserDao)
        {
            _siteUserDAO = siteUserDao;
        }

        public bool Add(string siteUserName, string userPassword)
        {
            try
            {
                if (siteUserName == "" || userPassword=="")
                {
                    return false;
                }
                _siteUserDAO.Add(siteUserName, userPassword);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + e.Source + Environment.NewLine + e.TargetSite + Environment.NewLine + e.StackTrace);
                throw new Exception("Can't add site user to text file.");
            }
            return true;
        }

        public bool AddImage(string siteUserName, string pathOfTheAddedImage)
        {
            return _siteUserDAO.AddImage(siteUserName, pathOfTheAddedImage);
        }

        public bool CorrectionOfAccessPermission(string siteUserName, bool admin)
        {
            return _siteUserDAO.CorrectionOfAccessPermission(siteUserName, admin);
        }

        public bool Delete(string siteUserName)
        {
            return _siteUserDAO.Delete(siteUserName);
        }

        public IEnumerable<SiteUser> GetAll()
        {
            return _siteUserDAO.GetAll();
        }

        public int[] GetAwardsIdBySiteUsername(string siteUserName)
        {
            return _siteUserDAO.GetAwardsIdBySiteUserName(siteUserName);
        }

        public SiteUser GetBySiteUserName(string siteUserName)
        {
             return _siteUserDAO.GetBySiteUserName(siteUserName);
        }

        public bool ToAwardSiteUser(string siteUserName, int awardId)
        {
            return _siteUserDAO.ToAwardSiteUser(siteUserName, awardId);
        }

        public bool ToRemoveSiteUserReward(string siteUserName, int awardId)
        {
            return _siteUserDAO.ToRemoveSiteUserReward(siteUserName, awardId);
        }
    }
}
