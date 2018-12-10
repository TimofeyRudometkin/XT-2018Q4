using System;
using System.Collections.Generic;
using System.Text;

namespace Epam.Task._4._2.WordFrequency
{
    class Program
    {
        static void Main(string[] args)
        {
            //words are considered to be the elements of a string containing only letters in an amount of one or more.
            WordFrequency();
        }
        static void WordFrequency()
        {
            string text;
            string VariantOfStart;
            Dictionary<string, int> WordsWithTheFrequencyOfOccurrenceOfWords = new Dictionary<string, int>();

            while (true)
            {
                text = "";
                try
                {
                    Console.WriteLine("Enter the text and see how many times each of the words occurs in it or enter '1' to process the preset" +
                        " text, '0' to exit the program.");
                    VariantOfStart = Console.ReadLine();
                    if(VariantOfStart=="1")
                    {
                        text = "FROM fairest creatures we desire increase, That thereby beauty's rose might never die, But as the riper " +
                            "should by time decease, His tender heir might bear his memory: But thou, contracted to thine own bright eyes," +
                            " Feed'st thy light'st flame with self-substantial fuel, Making a famine where abundance lies, Thyself thy foe," +
                            " to thy sweet self too cruel. Thou that art now the world's fresh ornament And only herald to the gaudy spring" +
                            ", Within thine own bud buriest thy content And, tender churl, makest waste in niggarding. Pity the world, or " +
                            "else this glutton be, To eat the world's due, by the grave and thee.";
                        Console.WriteLine(text + Environment.NewLine);
                    }
                    else if(VariantOfStart=="0")
                    {
                        break;
                    }
                    else
                    {
                        text = VariantOfStart;
                        Console.WriteLine();
                    }

                    WordsWithTheFrequencyOfOccurrenceOfWords = FillingTheCollectionOfUniqueWordsAndTheNumberOfRepetitions(text,
                        WordsWithTheFrequencyOfOccurrenceOfWords);

                    foreach (KeyValuePair<string, int> element in WordsWithTheFrequencyOfOccurrenceOfWords)
                    {
                        Console.WriteLine($"'{element.Key}' occurs in the text {element.Value} times");
                    }
                    Console.WriteLine(Environment.NewLine);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + Environment.NewLine);
                }
            }
        }

        static Dictionary<string, int> FillingTheCollectionOfUniqueWordsAndTheNumberOfRepetitions(string text,
            Dictionary<string, int> WordsWithTheFrequencyOfOccurrenceOfWords)
        {
            StringBuilder word = new StringBuilder();
            string LowerText = text.ToLower();
            WordsWithTheFrequencyOfOccurrenceOfWords.Clear();

            for (int i = 0; i < LowerText.Length; i++)
            {
                if (char.IsLetter(LowerText[i]))
                {
                    word.Insert(word.Length, LowerText[i]);
                    for (int j = i + 1; j < LowerText.Length; j++)
                    {
                        if (char.IsLetter(LowerText[j]) && (j != (LowerText.Length - 1)))
                        {
                            word.Insert(word.Length, LowerText[j]);
                        }
                        else if (char.IsLetter(LowerText[j]) && (j == (LowerText.Length - 1)))
                        {
                            word.Insert(word.Length, LowerText[j]);
                            if (WordsWithTheFrequencyOfOccurrenceOfWords.ContainsKey(word.ToString()))
                            {
                                WordsWithTheFrequencyOfOccurrenceOfWords[word.ToString()] += 1;
                            }
                            else
                            {
                                WordsWithTheFrequencyOfOccurrenceOfWords.Add(word.ToString(),1);
                            }
                            word.Clear();
                            i = j;
                            break;
                        }
                        else
                        {
                            if (WordsWithTheFrequencyOfOccurrenceOfWords.ContainsKey(word.ToString()))
                            {
                                WordsWithTheFrequencyOfOccurrenceOfWords[word.ToString()] += 1;
                            }
                            else
                            {
                                WordsWithTheFrequencyOfOccurrenceOfWords.Add(word.ToString(), 1);
                            }
                            word.Clear();
                            i = j;
                            break;
                        }
                    }
                }
            }
            return WordsWithTheFrequencyOfOccurrenceOfWords;
        }
    }
}
