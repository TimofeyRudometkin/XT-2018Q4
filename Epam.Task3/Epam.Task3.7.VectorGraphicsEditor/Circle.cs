using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3._7.VectorGraphicsEditor
{
    class Circle:Figure
    {
        private float m_radius;
        public float Radius
        {
            get { return m_radius; }
            set
            {
                if (value > 0)
                {
                    m_radius = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Radius of circle", value.ToString(),
                    "Radius of circle must be greater than zero.");
                }
            }
        }
    }
}
