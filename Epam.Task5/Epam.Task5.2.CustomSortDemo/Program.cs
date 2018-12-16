using System;

namespace Epam.Task5._2.CustomSortDemo
{
    class Program
    {
        //when I add a reference to Epam.Task5._1.CustomSort, methods cannot be used, so repeated code
        static void Main(string[] args)
        {
            string[] arrayofstring = { "Nissan", "Subaru", "Acura", "Vaz", "Mitsubishi", "Jaguar", "Kia", "Hyundai" };
            Console.WriteLine("Unsorted array:" + Environment.NewLine);
            ScreenOutputElementsOfStringArray(arrayofstring);
            Console.WriteLine();

            Console.WriteLine("Sort the array by strings:" + Environment.NewLine);
            CustomSort(arrayofstring, 0, arrayofstring.Length - 1, SortOfStringsOfTheArray);
            ScreenOutputElementsOfStringArray(arrayofstring);
            Console.WriteLine();
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
        protected static string SortOfStringsOfTheArray(string T1, string T2)
        {
            if (T1 == T2)
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
        private static void ScreenOutputElementsOfStringArray(string[] ArrayOfStrings)
        {
            foreach (string element in ArrayOfStrings)
            {
                Console.WriteLine(element);
            }
        }
    }
}
