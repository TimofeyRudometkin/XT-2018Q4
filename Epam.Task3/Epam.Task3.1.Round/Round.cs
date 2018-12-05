using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3._1.Round
{
    public class Round
    {
        private float m_XCoordinateOfTheCenter;
        private float m_YCoordinateofTheCenter;
        private float m_Radius;
        public float XCoordinateOfTheCenter
        {
            get { return (m_XCoordinateOfTheCenter); }
            set
            {
                m_XCoordinateOfTheCenter = value;
            }
        }
        public float YCoordinateOfTheCenter
        {
            get { return (m_YCoordinateofTheCenter); }
            set
            {
                m_YCoordinateofTheCenter = value;
            }

        }
        public float Radius
        {
            get { return (m_Radius); }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", value.ToString(),
                        "The value must be greater than zero");
                }
                m_Radius = value;
            }
        }
        public float LengthOfTheCircumscribedCircle => 2 * (float)Math.PI * m_Radius;
        public float TheAreaOfACircle => (float)Math.PI * m_Radius * m_Radius;
    }
}
