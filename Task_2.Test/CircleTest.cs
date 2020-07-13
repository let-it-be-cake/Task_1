using System;
using Task_2.Figures;
using Xunit;

namespace Task_2.Test
{
    public class CircleTest
    {
        #region Circle

        [Fact]
        public void Circle_GetSides_ArraySide_returned()
        {
            //arrange
            double x = 2;
            double y = 3;
            double radius = 4;
            Circle circle = new Circle(x, y, radius);
            double[] expected = new double[] { radius };

            //act
            double[] actual = circle.GetSides();

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Circle_Perimeter_7and2andPi_returned()
        {
            //arrange
            double x = 5;
            double y = 6;
            double radius = 7;

            Circle circle = new Circle(x, y, radius);
            double expected = Math.PI * 2 * radius;

            //act
            double actual = circle.Perimetr();

            //assert --yes, i know double != double, but i use integer values--
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Circle_Area_Error_returned()
        {
            //arrange
            double x = 5;
            double y = 6;
            double radius = 7;

            Circle circle = new Circle(x, y, radius);
            double expected = Math.PI * radius * radius;

            //act
            double actual = circle.Area();

            //assert --yes, i know double != double, but i use integer values--
            Assert.Equal(expected, actual);
        }

        #endregion Circle
    }
}