

namespace Epam.Task5._1.CustomSort
{
    class ArbitraryType
    {
        private string m_SomeString1;
        private double m_SomeNumber1;
        private string m_SomeString2;
        private double m_SomeNumber2;

        public string SomeString1
        {
            get => m_SomeString1;
            set => m_SomeString1 = value;
        }
        public double SomeNumber1
        {
            get => m_SomeNumber1;
            set => m_SomeNumber1 = value;
        }
        public string SomeString2
        {
            get => m_SomeString2;
            set => m_SomeString2 = value;
        }
        public double SomeNumber2
        {
            get => m_SomeNumber2;
            set => m_SomeNumber2 = value;
        }
        public ArbitraryType(string m_SomeString1, string m_SomeString2)
        {
            this.m_SomeString1 = m_SomeString1;
            this.m_SomeString2 = m_SomeString2;
        }
        public ArbitraryType(string m_SomeString1, double m_SomeNumber1)
        {
            this.m_SomeString1 = m_SomeString1;
            this.m_SomeNumber1 = m_SomeNumber1;
        }
        public ArbitraryType(double m_SomeNumber1, double m_SomeNumber2)
        {
            this.m_SomeNumber1 = m_SomeNumber1;
            this.m_SomeNumber2 = m_SomeNumber2;
        }
        public ArbitraryType(double m_SomeNumber1, string m_SomeString1)
        {
            this.m_SomeNumber1 = m_SomeNumber1;
            this.m_SomeString1 = m_SomeString1;
        }
    }
}
