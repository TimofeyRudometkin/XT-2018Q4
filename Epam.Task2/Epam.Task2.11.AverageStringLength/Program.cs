using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2._11.AverageStringLength
{
    class Program
    {
        private static void FAverageStringLength()
        {
            while (true)
            {
                int FullLengthOfWords = 0;
                int CountWordsinTheString = 0;
                string InputString="";
                bool PreviousCharacterALetter = false;
                char element =' ';
                int FirstLetterInWord=-1;

                Console.WriteLine("Enter a string to determine the average length of the words in it, or an empty " +
                    "string to exit the program.");

                InputString = Console.ReadLine();

                if (InputString.Length == 0)
                    {
                        break;
                    }

                for (int i=0;i<InputString.Length;i++)
                {
                    element = InputString[i];

                    if(char.IsSeparator(element)|| char.IsPunctuation(element))
                    {
                        if(PreviousCharacterALetter)
                        {
                            FullLengthOfWords += i - FirstLetterInWord;
                            CountWordsinTheString += 1;
                        }
                        PreviousCharacterALetter = false;
                    }
                    else
                    {
                        if(!PreviousCharacterALetter)
                        {
                            FirstLetterInWord = i;
                        }

                        if ((i == InputString.Length - 1))
                        {
                            if (PreviousCharacterALetter)
                            {
                                FullLengthOfWords += i+1-FirstLetterInWord;
                                CountWordsinTheString += 1;
                            }
                            else
                            {
                                FullLengthOfWords += 1;
                                CountWordsinTheString += 1;
                            }
                        }
                        PreviousCharacterALetter = true;
                    }
                }
                Console.WriteLine("Average length of words per line " + "{0:N2}", (float)FullLengthOfWords / CountWordsinTheString);
            }
        }
        static void Main(string[] args)
        {
            FAverageStringLength();
        }
    }
}
