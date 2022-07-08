using System;
using System.Threading;

namespace _100PrisonerRiddleTest
{
    static class Program
    {
        static void Main(string[] args)
        {
            int[] box = new int[100];
            int[] prisoners = new int[100];

            for (int i = 0; i < 3; i++)
            {
                Console.Clear();
                string[] dots = { ".", "..", "..." };
                Console.Write("Loading prisoners" + dots[i]);
                Thread.Sleep(1000);
            }

            for (int i = 0; i < 100; i++)
            {
                box[i] = i;
                prisoners[i] = i;
            }

            Console.Clear();
            Console.Write($"All {box.Length} Prisoners Loaded Successfully");
            Thread.Sleep(2500);
            Console.Clear();
            Console.Write("Would You Like To Start The Program?");

            again:
            var awnser = Console.ReadLine();

            if (awnser == "n" || awnser == "no")
            {
                Environment.Exit(1);
            }
            else if(awnser != "y")
            {
                if(awnser != "yes")
                {
                    Console.Clear();
                    Console.WriteLine("Incorrect Input");
                    Thread.Sleep(500);
                    Console.WriteLine("Valid Inputs Equals(Yes, No, Y , N)");
                    Thread.Sleep(500);
                    Console.WriteLine("Would You Like To Start The Program?");
                    goto again;
                }
            }

            int timesRun = 0;

            AgainFindNumbers:
            var rng = new Random();
            rng.Shuffle(box);
            timesRun++;

            for (int i = 0; i < prisoners.Length; i++)
            {
                int prisoner = prisoners[i];
                int number = box[prisoner];
                int timesSearched = 0;
                
                for(int x = 0; x < 50; x++)
                {
                    if(number != prisoner || timesSearched > 50)
                    {
                        timesSearched++;
                        number = box[number];
                    }
                }

                if(number == prisoner && timesSearched < 50)
                {
                    Console.WriteLine($"Prisoner({prisoner}) found his number in {timesSearched} tries");
                }
                else if(number != prisoner)
                {
                    Console.WriteLine($"Prisoner({prisoner}) searched 50 boxes and didn't find his number");
                    Console.WriteLine($"The prisoners has lost a total of {timesRun} times");
                    Console.WriteLine("Trying again");
                    Thread.Sleep(1000);
                    Console.Clear();
                    goto AgainFindNumbers;
                }
            }

            Console.WriteLine($"After {timesRun} tries all prisoners found their numbers");
        }

        public static void Shuffle<T>(this Random rng, T[] array)
        {
            int n = array.Length;
            while (n > 1)
            {
                int k = rng.Next(n--);
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }
    }
}
