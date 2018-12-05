using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3._5.Employee
{
    class Employee: Epam.Task3._3.User.User
    {
        private int m_Experience;
        private string m_Position;
        public int Experience
        {
            get { return m_Experience; }
            set
            {
                if ((Age - value) > 14)
                {
                    m_Experience = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Experience", value.ToString(),
                    "Work experience is wrong, a person can get a job only from the age of 14.");
                }
            }
        }
        public string Position
        {
            get { return m_Position; }
            set
            {
                if (value != "")
                {
                    m_Position = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Position", value,
                        "The Position field must be filled in.");
                }
            }
        }
    }
}
