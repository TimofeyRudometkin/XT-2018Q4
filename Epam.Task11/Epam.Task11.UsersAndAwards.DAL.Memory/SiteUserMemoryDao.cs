using Epam.Task11.UsersAndAwards.DAL.Interface;
using Epam.Task11.UsersAndAwards.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task11.UsersAndAwards.DAL.Memory
{
    public class SiteUserMemoryDao : ISiteUserDao
    {
        public bool Add(string siteUserName, string userPassword)
        {
            throw new NotImplementedException();
        }

        public bool AddImage(string siteUserName, string pathOfTheAddedImage)
        {
            throw new NotImplementedException();
        }

        public bool CorrectionOfAccessPermission(string siteUserName, bool admin)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string siteUserName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SiteUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public int[] GetAwardsIdBySiteUserName(string siteUserName)
        {
            throw new NotImplementedException();
        }

        public SiteUser GetBySiteUserName(string siteUserName)
        {
            throw new NotImplementedException();
        }

        public bool ToAwardSiteUser(string siteUserName, int awardId)
        {
            throw new NotImplementedException();
        }

        public bool ToRemoveSiteUserReward(string siteUserName, int awardId)
        {
            throw new NotImplementedException();
        }
    }
}
