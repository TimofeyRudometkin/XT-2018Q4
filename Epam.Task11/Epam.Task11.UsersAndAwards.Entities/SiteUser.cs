using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task11.UsersAndAwards.Entities
{
    public class SiteUser
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public int[] AwardId { get; set; }

        public string AccessPermission { get; set; }

        public override string ToString()
        {
            return $"{Name} {AwardId.ToString()}";
        }
    }
}
