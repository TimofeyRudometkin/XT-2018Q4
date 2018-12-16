using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task5._1.CustomSort
{
    class Program
    {
        static void Main(string[] args)
        {
            ArbitraryType[] array =
            {
                new ArbitraryType("Nissan", 2000),
                new ArbitraryType("Subaru", 1989),
                new ArbitraryType("Acura", 2005),
                new ArbitraryType("Vaz", 2004),
                new ArbitraryType("Mitsubishi", 1996),
                new ArbitraryType("Jaguar", 2011),
                new ArbitraryType("Kia", 2017),
                new ArbitraryType("Hyundai", 2018),
            };
            string[] arrayofstring = {"Nissan", "Subaru", "Acura", "Vaz", "Mitsubishi", "Jaguar", "Kia", "Hyundai" };
            Console.WriteLine("Unsorted array:" + Environment.NewLine);
            ScreenOutputElementsOfStringArray(arrayofstring);
            Console.WriteLine();

            Console.WriteLine("Sort the array by strings:" + Environment.NewLine);
            CustomSort(arrayofstring, 0, arrayofstring.Length - 1, SortOfStringsOfTheArray);
            ScreenOutputElementsOfStringArray(arrayofstring);
            Console.WriteLine();



            Console.WriteLine("Unsorted array:" + Environment.NewLine);
            ScreenOutputElementsOfArbitraryType(array);
            Console.WriteLine();

            Console.WriteLine("Sort the array by strings:" + Environment.NewLine);
            CustomSort(array, 0, array.Length - 1, SortOfStrings);
            ScreenOutputElementsOfArbitraryType(array);
            Console.WriteLine();

            Console.WriteLine("Sort the array by numbers:" + Environment.NewLine);
            CustomSort(array, 0, array.Length - 1, SortOfNumbers);
            ScreenOutputElementsOfArbitraryType(array);
        }
        public static void CustomSort<T>(T[] array, int left, int right, Func<T, T, string> sorttype)
        {
            int low = left;
            int high = right;
            T SupportElement = array[(left + right) / 2];

            while (low <= high)
            {
                while (sorttype(array[low], SupportElement) == "element1smallerthanelement2")
                {
                    low++;
                }
                while (sorttype(array[high], SupportElement) == "element1biggerthanelement2")
                {
                    high--;
                }
                if (low <= high)
                {
                    T temp = array[low];
                    array[low] = array[high];
                    array[high] = temp;
                    low++;
                    high--;
                }
            }
            if (left < high)
            {
                CustomSort(array, left, high, sorttype);
            }
            if (low < right)
            {
                CustomSort(array, low, right, sorttype);
            }
        }
        private static string SortOfStrings(ArbitraryType T1, ArbitraryType T2)
        {
            if (T1.SomeString1 == T2.SomeString1)
            {
                return "elementsAreEqual";
            }
            else if (T1.SomeString1 == null)
            {
                return "element1biggerthanelement2";
            }
            else if (T2.SomeString1 == null)
            {
                return "element1smallerthanelement2";
            }
            else if (T1.SomeString1.Length > T2.SomeString1.Length)
            {
                return "element1biggerthanelement2";
            }
            else if (T1.SomeString1.Length < T2.SomeString1.Length)
            {
                return "element1smallerthanelement2";
            }
            else if (T1.SomeString1.Length == T2.SomeString1.Length)
            {
                for (int i = 0; i < T1.SomeString1.Length; i++)
                {
                    if (T1.SomeString1[i] > T2.SomeString1[i])
                    {
                        return "element1biggerthanelement2";
                    }
                    else if (T1.SomeString1[i] < T2.SomeString1[i])
                    {
                        return "element1smallerthanelement2";
                    }
                }
                return "elementsAreEqual";
            }
            return "elementsAreEqual";
        }
        private static string SortOfNumbers(ArbitraryType T1, ArbitraryType T2)
        {
            if (T1.SomeNumber1 == T2.SomeNumber1)
            {
                return "elementsAreEqual";
            }
            else if (T1.SomeNumber1 == 0)
            {
                return "element1biggerthanelement2";
            }
            else if (T2.SomeNumber1 == 0)
            {
                return "element1smallerthanelement2";
            }
            else if (T1.SomeNumber1 > T2.SomeNumber1)
            {
                return "element1biggerthanelement2";
            }
            else
            {
                return "element1smallerthanelement2";
            }
        }
        protected static string SortOfStringsOfTheArray(string T1, string T2)
        {
            if (T1==T2)
            {
                return "elementsAreEqual";
            }
            else if (T1 == null)
            {
                return "element1biggerthanelement2";
            }
            else if (T2 == null)
            {
                return "element1smallerthanelement2";
            }
            else if (T1.Length > T2.Length)
            {
                return "element1biggerthanelement2";
            }
            else if (T1.Length < T2.Length)
            {
                return "element1smallerthanelement2";
            }
            else if (T1.Length == T2.Length)
            {
                for (int i = 0; i < T1.Length; i++)
                {
                    if (T1[i] > T2[i])
                    {
                        return "element1biggerthanelement2";
                    }
                    else if (T1[i] < T2[i])
                    {
                        return "element1smallerthanelement2";
                    }
                }
                return "elementsAreEqual";
            }
            return "elementsAreEqual";
        }
        private static void ScreenOutputElementsOfArbitraryType(ArbitraryType[] ArrayOfElement)
        {
            foreach (ArbitraryType element in ArrayOfElement)
            {
                Console.WriteLine($"{element.SomeString1} - {element.SomeNumber1}");
            }
        }
        private static void ScreenOutputElementsOfStringArray(string[] ArrayOfStrings)
        {
            foreach(string element in ArrayOfStrings)
            {
                Console.WriteLine(element);
            }
        }
    }
}
