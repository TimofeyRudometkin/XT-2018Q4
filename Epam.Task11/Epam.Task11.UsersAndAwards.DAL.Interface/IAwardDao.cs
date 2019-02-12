using Epam.Task11.UsersAndAwards.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task11.UsersAndAwards.DAL.Interface
{
    public interface IAwardDao
    {
        bool Add(Award award);

        bool DeleteAward(int Id);

        bool UpdateAward(Award award);

        Award GetAwardById(int Id);

        IEnumerable<Award> GetAllAwards();

        Dictionary<int, Award> GetDictionaryOfAwards();
    }
}
