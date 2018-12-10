using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task4._1.Lost
{
    class Program
    {
        static void Main(string[] args)
        {
            Lost();
        }
        public static void Lost()
        {
            Random RandomNumber = new Random();
            int CountOfPeople = RandomNumber.Next(55);
            List<string> PeopleInTheCircle = new List<string>();

            FillingTheList(CountOfPeople, PeopleInTheCircle);
            CrossingOutThePeopleFromCircle(PeopleInTheCircle);
            PrintTheRemainingHuman(PeopleInTheCircle);
        }
        static void FillingTheList(int CountOfPeople, List<string> PeopleInTheCircle)
        {
            for (int i = 1; i <= CountOfPeople; i++)
            {
                PeopleInTheCircle.Add($"Human № {i}");
                Console.WriteLine($"Human № {i} was added");
            }
        }
        static void CrossingOutThePeopleFromCircle(List<string> PeopleInTheCircle)
        {
            bool ControllerOfAccounts = true;

            while (PeopleInTheCircle.Count >= 2)
            {
                if (ControllerOfAccounts)
                {
                    ControllerOfAccounts = PeopleInTheCircle.Count % 2 == 0
                                         ? true
                                         : false;
                    Console.WriteLine($"From circle NOT crossing out {PeopleInTheCircle[0]}");
                    for (int i = 1; i < PeopleInTheCircle.Count; i++)
                    {
                        Console.WriteLine($"From circle crossing out {PeopleInTheCircle[i]}");
                        PeopleInTheCircle.RemoveAt(i);
                        if ((i) < PeopleInTheCircle.Count)
                        {
                            Console.WriteLine($"From circle NOT crossing out {PeopleInTheCircle[i]}");
                        }
                    }
                    if (!ControllerOfAccounts)
                    {
                        Console.WriteLine($"From circle NOT crossing out {PeopleInTheCircle[PeopleInTheCircle.Count-1]}");
                    }
                }
                else
                {
                    ControllerOfAccounts = PeopleInTheCircle.Count % 2 == 0
                                         ? true
                                         : false;
                    for (int i = 0; i < PeopleInTheCircle.Count; i++)
                    {
                        if ((i + 1) < PeopleInTheCircle.Count)
                        {
                            Console.WriteLine($"From circle NOT crossing out {PeopleInTheCircle[i + 1]}");
                        }
                        Console.WriteLine($"From circle crossing out {PeopleInTheCircle[i]}");
                        PeopleInTheCircle.RemoveAt(i);
                    }
                }
            }
        }
        static void PrintTheRemainingHuman(List<string> PeopleInTheCircle)
        {
            foreach (string element in PeopleInTheCircle)
            {
                Console.WriteLine($"Remaining human '{element}.'");
            }
        }
    }
}
