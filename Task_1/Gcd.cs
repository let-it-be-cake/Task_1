using System.Linq;

namespace Task_1
{
    public static class Gcd
    {
        static public int Euclid(int first, int second)
        {
            //If the numbers are equals, return first number
            if (first == second) return first;

            while (first != 0)
            {
                //Using a tuple to swap two elements
                if (first < second) (first, second) = (second, first);

                //Calculating the remainder
                first -= second * (int)(first / second);
            }

            return second;
        }

        static public int Euclid(int first, int second, params int[] numbers)
        {
            int gcdValue = Euclid(first, second);
            //Calculating of all parameters
            foreach (var number in numbers)
                gcdValue = Euclid(gcdValue, number);
            return gcdValue;
        }
        
        static public int Euclid(out long time, int first, params int[] numbers)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            var result = numbers.Length > 1 ?
                Euclid(first, numbers[0], numbers.Skip(1).ToArray()) : Euclid(first, numbers[0]);
            watch.Stop();
            time = watch.ElapsedMilliseconds;
            return result;
        }

        static public int Stein(int first, int second)
        {
            int shift = 1;
            while ((first != 0) && (second != 0))
            {
                while (((first | second) & 1) == 0)
                {
                    first >>= 1;
                    second >>= 1;
                    shift <<= 1;
                }

                while ((first & 1) == 0) first >>= 1;
                while ((second & 1) == 0) second >>= 1;

                if (first >= second) first -= second;
                else second -= first;
            }
            return second * shift;
        }

        static public int Stein(int first, int second, params int[] numbers)
        {
            int gcdValue = Stein(first, second);
            foreach (var number in numbers)
                gcdValue = Stein(gcdValue, number);
            return gcdValue;
        }

        static public int Stein(out long time, int first, params int[] numbers)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            var result = numbers.Length > 1 ?
                Stein(first, numbers[0], numbers.Skip(1).ToArray()) : Euclid(first, numbers[0]);

            watch.Stop();
            time = watch.ElapsedMilliseconds;
            return result;
        }
        //Returns the execution time using the Euclid method and the wall method and result of calculating
        static public int Gistogram(out long euclidTime, out long steinTime, int first, params int[] numbers)
        {
            Euclid(out euclidTime, first, numbers);
            return Stein(out steinTime, first, numbers);
        }
    }
}