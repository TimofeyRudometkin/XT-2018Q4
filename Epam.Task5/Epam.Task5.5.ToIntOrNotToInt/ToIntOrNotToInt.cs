using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task5._5.ToIntOrNotToInt
{
    static class ToIntOrNotToInt
    {
        public static bool PositiveInteger(this string str)
        {
            bool PositiveInt = true;
            foreach(char element in str)
            {
                if(!char.IsDigit(element)||element=='0')
                {
                    PositiveInt = false;
                    return PositiveInt;
                }
            }
            return PositiveInt;
        }
    }
}
