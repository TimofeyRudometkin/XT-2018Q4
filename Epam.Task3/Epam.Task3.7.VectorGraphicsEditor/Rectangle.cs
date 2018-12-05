using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3._7.VectorGraphicsEditor
{
    class Rectangle:Figure
    {
        private float m_SideA;
        private float m_SideB;
        public float SideA
        {
            get { return m_SideA; }
            set
            {
                if (value > 0)
                {
                    m_SideA = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Length of side A of rectangle", value.ToString(),
                    "Length of side A of rectangle must be greater than zero.");
                }
            }
        }
        public float SideB
        {
            get { return m_SideB; }
            set
            {
                if (value > 0)
                {
                    m_SideB = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Length of side B of rectangle", value.ToString(),
                    "Length of side B of rectangle must be greater than zero.");
                }
            }
        }
        public float Area => m_SideA * m_SideB;
        public float Perimetr => 2 * m_SideA + 2 * m_SideB;
    }
}
