using System;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            long time;
            Console.WriteLine(Gcd.Euclid(out time, 45, 9, 39) + " time "+ time);


            Console.WriteLine(Gcd.Stein(out time, 45, 9, 39) + " time " + time);
            
        }
    }
}
