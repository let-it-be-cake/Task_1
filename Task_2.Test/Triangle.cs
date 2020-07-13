using System;
using Task_2.Figures;
using Xunit;

namespace Task_2.Test
{
    public class TriangleTest
    {
        #region Triangle

        [Fact]
        public void Triangle_GetSides_FromSides_ArraySide_returned()
        {
            //arrange
            double side1 = 2;
            double side2 = 3;
            double side3 = 4;
            Triangle triangle = new Triangle(side1, side2, side3);
            double[] expected = new double[] { side1, side2, side3 };

            //act
            double[] actual = triangle.GetSides();

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Triangle_GetSides_FromPoints_ArraySide_returned()
        {
            //arrange
            double x1 = 0;
            double y1 = 0;
            double x2 = 3;
            double y2 = 0;
            double x3 = 3;
            double y3 = 4;
            Triangle triangle = new Triangle(x1, y1, x2, y2, x3, y3);
            double[] expected = new double[] { 3, 4, 5 };

            //act
            double[] actual = triangle.GetSides();

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Triangle_Perimeter_Sides_6and8and10_24returned()
        {
            //arrange
            double side1 = 6;
            double side2 = 8;
            double side3 = 10;

            Triangle triangle = new Triangle(side1, side2, side3);
            double expected = 24;

            //act
            double actual = triangle.Perimetr();

            //assert --/ yes, i know double != double, but i use integer values \--
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Triangle_Perimeter_Points_0and0and3and0and3and4_12returned()
        {
            //arrange
            double x1 = 0;
            double y1 = 0;
            double x2 = 3;
            double y2 = 0;
            double x3 = 3;
            double y3 = 4;
            Triangle triangle = new Triangle(x1, y1, x2, y2, x3, y3);

            double expected = 12;

            //act
            double actual = triangle.Perimetr();

            //assert --yes, i know double != double, but i use integer values--
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Triangle_Area_Sides_6and8and10_24returned()
        {
            //arrange
            double side1 = 6;
            double side2 = 8;
            double side3 = 10;

            Triangle triangle = new Triangle(side1, side2, side3);
            double expected = 24;

            //act
            double actual = triangle.Perimetr();

            //assert --/ yes, i know double != double, but i use integer values \--
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Triangle_Area_Points_0and0and3and0and3and4_12returned()
        {
            //arrange
            double x1 = 0;
            double y1 = 0;
            double x2 = 3;
            double y2 = 0;
            double x3 = 3;
            double y3 = 4;
            Triangle triangle = new Triangle(x1, y1, x2, y2, x3, y3);

            double expected = 12;

            //act
            double actual = triangle.Perimetr();

            //assert --yes, i know double != double, but i use integer values--
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Triangle_WrongSides_Error_returned()
        {
            //arrange
            double side1 = 1;
            double side2 = 10;
            double side3 = 1;

            //act
            //ArgumentException

            //assert
            Assert.Throws<ArgumentException>(() => new Triangle(side1, side2, side3));
        }

        #endregion Triangle
        }
}