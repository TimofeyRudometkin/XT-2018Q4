using Epam.Task11.UsersAndAwards.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task11.UsersAndAwards.DAL.Interface
{
    public interface ISiteUserDao
    {
        bool Add(string siteUserName, string userPassword);

        bool Delete(string siteUserName);

        bool ToAwardSiteUser(string siteUserName, int awardId);

        bool ToRemoveSiteUserReward(string siteUserName, int awardId);

        SiteUser GetBySiteUserName(string siteUserName);

        int[] GetAwardsIdBySiteUserName(string siteUserName);

        IEnumerable<SiteUser> GetAll();

        bool AddImage(string siteUserName, string pathOfTheAddedImage);

        bool CorrectionOfAccessPermission(string siteUserName, bool admin);
    }
}
