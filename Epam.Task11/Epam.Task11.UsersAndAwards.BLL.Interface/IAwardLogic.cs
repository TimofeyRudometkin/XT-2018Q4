using Epam.Task11.UsersAndAwards.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task11.UsersAndAwards.BLL.Interface
{
    public interface IAwardLogic
    {
        void Add(Award award);

        void DeleteAward(int Id);

        void UpdateAward(Award award);

        Award GetAwardById(int Id);

        IEnumerable<Award> GetAllAwards();

        Dictionary<int, Award> GetDictionaryOfAwards();
    }
}
