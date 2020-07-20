using Xunit;

namespace Task_2.Test
{
    public class PolynomialTest
    {
        #region Testing Operation +
        [Fact]
        public void Test_1_operator_plus()
        {
            //arrange
            double[] array1 = new double[] { 1, 2, 10, 0, 3 };
            double[] array2 = new double[] { 2, 1, 0, 12, 9 };

            double[] array3 = new double[] { 3, 3, 10, 12, 12 };

            Polynomial expected = new Polynomial(array3);
            Polynomial polynomial1 = new Polynomial(array1);
            Polynomial polynomial2 = new Polynomial(array2);

            //act
            Polynomial actual = polynomial1 + polynomial2;

            //assert
            Assert.Equal(expected.Coefficients, actual.Coefficients);
        }

        [Fact]
        public void Test_2_operator_plus()
        {
            //arrange
            double[] array1 = new double[] { 1, 5, 8, 0, 3 };
            double[] array2 = new double[] { 3, 9, 9 };

            double[] array3 = new double[] { 1, 5, 11, 9, 12 };

            Polynomial expected = new Polynomial(array3);
            Polynomial polynomial1 = new Polynomial(array1);
            Polynomial polynomial2 = new Polynomial(array2);

            //act
            Polynomial actual = polynomial1 + polynomial2;

            //assert
            Assert.Equal(expected.Coefficients, actual.Coefficients);
        }

        [Fact]
        public void Test_3_operator_plus()
        {
            //arrange
            double[] array1 = new double[] { 1, 2, 0, 0, 0 };
            double[] array2 = new double[] { 9, 0, 9 };

            double[] array3 = new double[] { 1, 2, 9, 0, 9 };

            Polynomial expected = new Polynomial(array3);
            Polynomial polynomial1 = new Polynomial(array1);
            Polynomial polynomial2 = new Polynomial(array2);

            //act
            Polynomial actual = polynomial1 + polynomial2;

            //assert
            Assert.Equal(expected.Coefficients, actual.Coefficients);
        }
        #endregion Testing Operation +
        
        #region Testing Operation -
        [Fact]
        public void Test_1_operator_minus()
        {
            //arrange
            double[] array1 = new double[] { 3, 2, 10, 0, 3 };
            double[] array2 = new double[] { 2, 1, 0, 12, 9 };

            double[] array3 = new double[] { 1, 1, 10, -12, -6 };

            Polynomial expected = new Polynomial(array3);
            Polynomial polynomial1 = new Polynomial(array1);
            Polynomial polynomial2 = new Polynomial(array2);

            //act
            Polynomial actual = polynomial1 - polynomial2;

            //assert
            Assert.Equal(expected.Coefficients, actual.Coefficients);
        }

        [Fact]
        public void Test_2_operator_minus()
        {
            //arrange
            double[] array1 = new double[] { 1, 5, 8, 0, 3 };
            double[] array2 = new double[] { 8, 5, 9 };

            double[] array3 = new double[] { 1, 5, 0, -5, -6 };

            Polynomial expected = new Polynomial(array3);
            Polynomial polynomial1 = new Polynomial(array1);
            Polynomial polynomial2 = new Polynomial(array2);

            //act
            Polynomial actual = polynomial1 - polynomial2;

            //assert
            Assert.Equal(expected.Coefficients, actual.Coefficients);
        }

        [Fact]
        public void Test_3_operator_minus()
        {
            //arrange
            double[] array1 = new double[] { 5, 2, 9, 0, 9 };
            double[] array2 = new double[] { 9, 0, 9 };

            double[] array3 = new double[] { 5, 2, 0, 0, 0 };

            Polynomial expected = new Polynomial(array3);
            Polynomial polynomial1 = new Polynomial(array1);
            Polynomial polynomial2 = new Polynomial(array2);

            //act
            Polynomial actual = polynomial1 - polynomial2;

            //assert
            Assert.Equal(expected.Coefficients, actual.Coefficients);
        }
        #endregion Testing Operation -
        
        #region Testing Operation *
        [Fact]
        public void Test_1_operator_mul()
        {
            //arrange
            double[] array1 = new double[] { 3, 0, 8 };
            double[] array2 = new double[] { 4, 8, 0 };

            double[] array3 = new double[] { 12, 24, 32, 64, 0 };

            Polynomial expected = new Polynomial(array3);
            Polynomial polynomial1 = new Polynomial(array1);
            Polynomial polynomial2 = new Polynomial(array2);

            //act
            Polynomial actual = polynomial1 * polynomial2;

            //assert
            Assert.Equal(expected.Coefficients, actual.Coefficients);
        }

        [Fact]
        public void Test_2_operator_mul()
        {
            //arrange
            double[] array1 = new double[] { 1, 5, 8, 0, 3 };
            double[] array2 = new double[] { 8, 5, 9 };

            double[] array3 = new double[] { 8, 45, 98, 85, 96, 15, 27 };

            Polynomial expected = new Polynomial(array3);
            Polynomial polynomial1 = new Polynomial(array1);
            Polynomial polynomial2 = new Polynomial(array2);

            //act
            Polynomial actual = polynomial1 * polynomial2;

            //assert
            Assert.Equal(expected.Coefficients, actual.Coefficients);
        }

        [Fact]
        public void Test_3_operator_mul()
        {
            //arrange
            double[] array1 = new double[] { 2, 9 };
            double[] array2 = new double[] { 7, 8, 0, 9 };

            double[] array3 = new double[] { 14, 79, 72, 18, 81 };

            Polynomial expected = new Polynomial(array3);
            Polynomial polynomial1 = new Polynomial(array1);
            Polynomial polynomial2 = new Polynomial(array2);

            //act
            Polynomial actual = polynomial1 * polynomial2;

            //assert
            Assert.Equal(expected.Coefficients, actual.Coefficients);
        }
        #endregion Testing Operation *


    }
}