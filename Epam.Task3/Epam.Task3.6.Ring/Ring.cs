using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3._6.Ring
{
    class Ring
    {
        private float m_x;
        private float m_y;

        private float m_innerRadius;
        private float m_outerRadius;
        public float X
        {
            get { return m_x; }
            set { m_x = value; }
        }
        public float Y
        {
            get { return m_y; }
            set { m_y = value; }
        }
        public float InnerRadius
        {
            get { return m_innerRadius; }
            set
            {
                if (value > 0)
                {
                    m_innerRadius = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("InnerRadius", value.ToString(),
                    "The InnerRadius must be greater than zero.");
                }
            }
        }
        public float OuterRadius
        {
            get { return m_outerRadius; }
            set
            {
                if (value>0)
                {
                    m_outerRadius = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("OuterRadius", value.ToString(),
                    "The OuterRadius must be greater than zero.");
                }
            }
        }
        public float AreaOfRing => (float)Math.PI * (m_outerRadius * m_outerRadius - m_innerRadius * m_innerRadius);
        public float LengthOuterInnerCircumference => 2 * (float)Math.PI * (m_outerRadius + m_innerRadius);
    }
}
