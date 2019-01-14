using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task7._1.Users.Entities
{
    public class Award
    {
        public int Id;

        public string Title;

        public override string ToString()
        {
            return $"{Id} {Title}";
        }
    }
}
