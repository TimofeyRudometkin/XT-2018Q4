using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task7._1.Users.Entities;

namespace Epam.Task7._1.Users.BLL.Interface
{
    public interface IAwardLogic
    {
        void Add(Award award);

        void DeleteAward(int Id);

        void UpdateAward(Award award);

        Award GetAwardById(int Id);

        IEnumerable<Award> GetAllAwards();
    }
}
