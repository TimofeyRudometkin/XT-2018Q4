using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3._4.MyString
{
    class MyString
    {
        private char[] m_ArrMyString=new char[10];
        private string m_MyString;

        public string Mystring
        {
            get { return m_MyString; }
            set
            {
                if (value!=null)
                {
                    while (m_ArrMyString.Length < value.Length)
                    {
                        Array.Resize(ref m_ArrMyString, m_ArrMyString.Length * 2);
                    }
                    m_ArrMyString = value.ToCharArray();
                    m_MyString = "";
                    foreach (char element in m_ArrMyString)
                    {
                        m_MyString += element;
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException("MyString", value.ToString(),
                        "The string field must be filled in.");
                }
            }
        }
    }
}
