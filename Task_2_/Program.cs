using System;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] array1 = new double[] { 1, 2, 10, 0, 3 };
            double[] array2 = new double[] { 2, 1, 0, 12, 9 };

            double[] array3 = new double[] { 3, 3, 10, 12, 12 };

            Polynomial expected = new Polynomial(array3);
            Polynomial polynomial1 = new Polynomial(array1);
            Polynomial polynomial2 = new Polynomial(array2);

            //act
            Polynomial actual = polynomial1 + polynomial2;
        }
    }
}
