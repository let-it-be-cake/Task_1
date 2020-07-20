using System;
using Xunit;

using Task_1;

namespace Task_1.Test
{
    public class VectorTest
    {
        #region Testing Operation +
        [Fact]
        public void Test_1_operator_plus()
        {
            //arrange
            int x1 = 2, y1 = 3, z1 = 3;
            int x2 = 5, y2 = 6, z2 = 8;

            Vector expected = new Vector(x1+x2, y1+y2, z1+z2);
            Vector vector1 = new Vector(x1, y1, z1);
            Vector vector2 = new Vector(x2, y2, z2);

            //act
            Vector actual = vector1 + vector2;

            //assert
            Assert.Equal(expected.Point, actual.Point);
        }

        [Fact]
        public void Test_2_operator_plus()
        {
            int x1 = 8, y1 = 9, z1 = 9;
            int x2 = 10, y2 = 12, z2 = 13;


            Vector expected = new Vector(x1 + x2, y1 + y2, z1 + z2);
            Vector vector1 = new Vector(x1, y1, z1);
            Vector vector2 = new Vector(x2, y2, z2);

            //act
            Vector actual = vector1 + vector2;

            //assert
            Assert.Equal(expected.Point, actual.Point);
        }

        [Fact]
        public void Test_3_operator_plus()
        {
            int x1 = 12, y1 = 6, z1 = 8;
            int x2 = 3, y2 = 14, z2 = 11;


            Vector expected = new Vector(x1 + x2, y1 + y2, z1 + z2);
            Vector vector1 = new Vector(x1, y1, z1);
            Vector vector2 = new Vector(x2, y2, z2);

            //act
            Vector actual = vector1 + vector2;

            //assert
            Assert.Equal(expected.Point, actual.Point);
        }
        #endregion Testing Operation +

        #region Testing Operation -
        [Fact]
        public void Test_1_operator_minus()
        {
            //arrange
            int x1 = 5, y1 = 6, z1 = 8;
            int x2 = 2, y2 = 3, z2 = 3;

            Vector expected = new Vector(x1 - x2, y1 - y2, z1 - z2);
            Vector vector1 = new Vector(x1, y1, z1);
            Vector vector2 = new Vector(x2, y2, z2);

            //act
            Vector actual = vector1 - vector2;

            //assert
            Assert.Equal(expected.Point, actual.Point);
        }

        [Fact]
        public void Test_2_operator_minus()
        {
            int x1 = 10, y1 = 12, z1 = 13;
            int x2 = 8, y2 = 9, z2 = 9;


            Vector expected = new Vector(x1 - x2, y1 - y2, z1 - z2);
            Vector vector1 = new Vector(x1, y1, z1);
            Vector vector2 = new Vector(x2, y2, z2);

            //act
            Vector actual = vector1 - vector2;

            //assert
            Assert.Equal(expected.Point, actual.Point);
        }

        [Fact]
        public void Test_3_operator_minus()
        {
            int x1 = 12, y1 = 6, z1 = 8;
            int x2 = 3, y2 = 14, z2 = 11;


            Vector expected = new Vector(x1 - x2, y1 - y2, z1 - z2);
            Vector vector1 = new Vector(x1, y1, z1);
            Vector vector2 = new Vector(x2, y2, z2);

            //act
            Vector actual = vector1 - vector2;

            //assert
            Assert.Equal(expected.Point, actual.Point);
        }
        #endregion Testing Operation -

        #region Testing Operation *
        [Fact]
        public void Test_1_operator_vector_mul()
        {
            //arrange
            int x1 = 2, y1 = 3, z1 = 3;
            int mul = 3;

            Vector expected = new Vector(x1 * mul, y1 * mul, z1 * mul);
            Vector vector1 = new Vector(x1, y1, z1);

            //act
            Vector actual = vector1 * mul;

            //assert
            Assert.Equal(expected.Point, actual.Point);
        }

        [Fact]
        public void Test_2_operator_vector_mul()
        {
            int x1 = 8, y1 = 9, z1 = 9;
            int mul = 2;

            Vector expected = new Vector(x1 * mul, y1 * mul, z1 * mul);
            Vector vector1 = new Vector(x1, y1, z1);

            //act
            Vector actual = vector1 * mul;

            //assert
            Assert.Equal(expected.Point, actual.Point);
        }

        [Fact]
        public void Test_1_operator_mul_vector()
        {
            int x1 = 12, y1 = 6, z1 = 8;

            int mul = 10;

            Vector expected = new Vector(x1 * mul, y1 * mul, z1 * mul);
            Vector vector1 = new Vector(x1, y1, z1);

            //act
            Vector actual = mul * vector1;

            //assert
            Assert.Equal(expected.Point, actual.Point);
        }

        [Fact]
        public void Test_2_operator_mul_vector()
        {
            int x1 = 3, y1 = 14, z1 = 11;
            int mul = 5;

            Vector expected = new Vector(x1 * mul, y1 * mul, z1 * mul);
            Vector vector1 = new Vector(x1, y1, z1);

            //act
            Vector actual = mul * vector1;

            //assert
            Assert.Equal(expected.Point, actual.Point);
        }
        #endregion Testing Operation *

        #region Testing Operation /
        [Fact]
        public void Test_1_operator_vector_div()
        {
            //arrange
            double x1 = 2, y1 = 3, z1 = 3;
            double div = 3;

            Vector expected = new Vector(x1 / div, y1 / div, z1 / div);
            Vector vector1 = new Vector(x1, y1, z1);

            //act
            Vector actual = vector1 / div;

            //assert
            Assert.Equal(expected.Point, actual.Point);
        }

        [Fact]
        public void Test_2_operator_vector_div()
        {
            double x1 = 8, y1 = 9, z1 = 9;
            double div = 2;

            Vector expected = new Vector(x1 * div, y1 * div, z1 * div);
            Vector vector1 = new Vector(x1, y1, z1);

            //act
            Vector actual = vector1 * div;

            //assert
            Assert.Equal(expected.Point, actual.Point);
        }

        [Fact]
        public void Test_1_operator_div_vector()
        {
            double x1 = 12, y1 = 6, z1 = 8;
            double div = 10;

            Vector expected = new Vector(x1 * div, y1 * div, z1 * div);
            Vector vector1 = new Vector(x1, y1, z1);

            //act
            Vector actual = div * vector1;

            //assert
            Assert.Equal(expected.Point, actual.Point);
        }

        [Fact]
        public void Test_2_operator_div_vector()
        {
            double x1 = 3, y1 = 14, z1 = 11;
            double div = 5;

            Vector expected = new Vector(x1 * div, y1 * div, z1 * div);
            Vector vector1 = new Vector(x1, y1, z1);

            //act
            Vector actual = div * vector1;

            //assert
            Assert.Equal(expected.Point, actual.Point);
        }
        #endregion Testing Operation /
    }
}
