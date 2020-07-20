using System;

namespace Task_2
{
    public class Polynomial
    {
        public double[] Coefficients { get; set; }

        public Polynomial(params double[] coeff)
        {
            Coefficients = coeff;
        }

        public static Polynomial operator +(Polynomial a, Polynomial b)
        {
            int aLength = a.Coefficients.Length;
            int bLength = b.Coefficients.Length;

            double currentA = 0;
            double currentB = 0;

            int indexA = aLength-1;
            int indexB = bLength-1;

            int count = Math.Max(aLength, bLength) - 1;

            Polynomial c = new Polynomial(new double[count + 1]);
            for (; count >= 0; count--) {
                currentA = indexA >= 0 ? a.Coefficients[indexA] : 0;
                currentB = indexB >= 0 ? b.Coefficients[indexB] : 0;

                c.Coefficients[count] = currentA + currentB;

                indexA = indexA < 0 ? -1 : indexA-1;
                indexB = indexB < 0 ? -1 : indexB-1;
            }
            return c;
        }

        public static Polynomial operator -(Polynomial a, Polynomial b)
        {
            int aLength = a.Coefficients.Length;
            int bLength = b.Coefficients.Length;

            double currentA = 0;
            double currentB = 0;

            int indexA = aLength - 1;
            int indexB = bLength - 1;

            int count = Math.Max(aLength, bLength) - 1;

            Polynomial c = new Polynomial(new double[count + 1]);
            for (; count >= 0; count--)
            {
                currentA = indexA >= 0 ? a.Coefficients[indexA] : 0;
                currentB = indexB >= 0 ? b.Coefficients[indexB] : 0;

                c.Coefficients[count] = currentA - currentB;

                indexA = indexA < 0 ? -1 : indexA - 1;
                indexB = indexB < 0 ? -1 : indexB - 1;
            }
            return c;
        }

        public static Polynomial operator *(Polynomial a, Polynomial b)
        {
            int aLength = a.Coefficients.Length;
            int bLength = b.Coefficients.Length;
            int cLength = aLength + bLength - 1;
            Polynomial c = new Polynomial(new double[cLength]);

            for (int i = 0; i < aLength; i++)
            {
                for (int j = 0; j < bLength; j++)
                {
                    c.Coefficients[i + j] += a.Coefficients[i] * b.Coefficients[j];
                }
            }
            return c;
        }
    }
}