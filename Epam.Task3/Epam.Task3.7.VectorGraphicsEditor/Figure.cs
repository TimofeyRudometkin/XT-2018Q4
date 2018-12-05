using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3._7.VectorGraphicsEditor
{
    class Figure
    {
        private float m_x;
        private float m_y;

        public float X
        {
            get { return m_x; }
            set{ m_x=value ; }
        }
        public float Y
        {
            get { return m_y; }
            set { m_y = value; }
        }
    }
}
