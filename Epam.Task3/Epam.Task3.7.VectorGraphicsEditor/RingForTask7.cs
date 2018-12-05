using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3._7.VectorGraphicsEditor
{
    class RingForTask7:Circle
    {
        private float m_innerRadius;
        public float InnerRadius
        {
            get { return m_innerRadius; }
            set
            {
                if(value<=0)
                {
                    throw new ArgumentOutOfRangeException("Inner radius of ring", value.ToString(),
                    "Inner radius of ring must be greater than zero.");
                }
                else if (value < Radius)
                {
                    m_innerRadius = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Inner radius of ring", value.ToString(),
                    "Inner radius of ring must be less than outer radius.");
                }
            }
        }
        public float AreaOfRing => (float)Math.PI * (Radius * Radius - m_innerRadius * m_innerRadius);
        public float LengthOuterInnerCircumference => 2 * (float)Math.PI * (Radius + m_innerRadius);
    }
}
