using Epam.Task7._1.Users.Entities;
using System.Collections.Generic;

namespace Epam.Task7._1.Users.DAL.Interface
{
    public interface IAwardDao
    {
        void Add(Award award);

        bool DeleteAward(int Id);

        bool UpdateAward(Award award);

        Award GetAwardById(int Id);

        IEnumerable<Award> GetAllAwards();
    }
}
