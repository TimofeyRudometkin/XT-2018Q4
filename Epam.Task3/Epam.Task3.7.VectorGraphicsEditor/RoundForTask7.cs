using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3._7.VectorGraphicsEditor
{
    class RoundForTask7: Circle
    {
        public float LengthOfTheCircumscribedCircle => 2 * (float)Math.PI * Radius;
        public float TheAreaOfACircle => (float)Math.PI * Radius * Radius;
    }
}
