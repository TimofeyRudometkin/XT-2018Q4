using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3._2.Triangle
{
    class Triangle
    {
        private float m_SideA;
        private float m_SideB;
        private float m_SideC;
        private float m_Perimetr;
        public float SideA
        {
            get { return (m_SideA); }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Side 'A'", value.ToString(),
                        "The value must be greater than zero.");
                }
                m_SideA = value;
            }
        }
        public float SideB
        {
            get { return (m_SideB); }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Side 'B'", value.ToString(),
                        "The value must be greater than zero.");
                }
                m_SideB = value;
            }
        }
        public float SideC
        {
            get { return (m_SideC); }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Side 'C'", value.ToString(),
                        "The value must be greater than zero.");
                }
                else if ((value >= (m_SideA + m_SideB))||(m_SideA >= (value + m_SideB))||(m_SideB >= (m_SideA + value)))
                {
                    throw new ArgumentOutOfRangeException("Side 'A,B,C'", value.ToString(),
                        "The Side must be less than sum of two other sides.");
                }
                m_SideC = value;
            }
        }
        public float Perimetr
        {
            get
            {
                m_Perimetr = (m_SideA + m_SideB + m_SideC);
                if(m_Perimetr / 2 * ((m_Perimetr / 2) - m_SideA) * ((m_Perimetr / 2) - m_SideB) * ((m_Perimetr / 2) - m_SideC) <= 0)
                {
                    throw new ArgumentOutOfRangeException("There is no triangle with side values entered.");
                }
                return (m_Perimetr);
            }
        }
        public double Area => (Math.Sqrt(Perimetr / 2 * ((Perimetr / 2) - m_SideA) * ((Perimetr / 2) - m_SideB) * ((Perimetr / 2) - m_SideC)));
    }
}
