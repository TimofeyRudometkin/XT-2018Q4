using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3._7.VectorGraphicsEditor
{
    class Line:Figure
    {
        private float m_length;
        public float Length
        {
            get { return m_length; }
            set
            {
                if (value > 0)
                {
                    m_length = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Length of line", value.ToString(),
                    "Length of line must be greater than zero.");
                }
            }
        }
    }
}
