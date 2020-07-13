using Task_2.Figures;
using Xunit;

namespace Task_2.Test
{
    public class RectangleTest
    {
        #region Rectangle

        [Fact]
        public void Rectangle_GetSides_FromSides_ArraySide_returned()
        {
            //arrange
            double side1 = 2;
            double side2 = 3;
            Rectangle rectangle = new Rectangle(side1, side2);
            double[] expected = new double[] { side1, side2 };

            //act
            double[] actual = rectangle.GetSides();

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Rectangle_GetSides_FromPoints_ArraySide_returned()
        {
            //arrange
            double x1 = 2;
            double y1 = 3;
            double x2 = 5;
            double y2 = 6;
            Rectangle rectangle = new Rectangle(x1, y1, x2, y2);
            double[] expected = new double[] { y2 - y1, x2 - x1 };

            //act
            double[] actual = rectangle.GetSides();

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Rectangle_Perimeter_7and2_18returned()
        {
            //arrange
            double side1 = 7;
            double side2 = 2;

            Rectangle rectangle = new Rectangle(side1, side2);
            double expected = 18;

            //act
            double actual = rectangle.Perimetr();

            //assert --/ yes, i know double != double, but i use integer values \--
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Rectangle_Perimeter_Points_2and3and5and6_9returned()
        {
            //arrange
            double x1 = 2;
            double y1 = 3;
            double x2 = 5;
            double y2 = 6;

            Rectangle rectangle = new Rectangle(x1, y1, x2, y2);
            double expected = 12;

            //act
            double actual = rectangle.Perimetr();

            //assert --yes, i know double != double, but i use integer values--
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Rectangle_Area_7and2_18returned()
        {
            //arrange
            double side1 = 7;
            double side2 = 2;

            Rectangle rectangle = new Rectangle(side1, side2);
            double expected = 14;

            //act
            double actual = rectangle.Area();

            //assert --/ yes, i know double != double, but i use integer values \--
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Rectangle_Area_Points_2and3and5and6_9returned()
        {
            //arrange
            double x1 = 2;
            double y1 = 3;
            double x2 = 5;
            double y2 = 6;

            Rectangle rectangle = new Rectangle(x1, y1, x2, y2);
            double expected = 9;

            //act
            double actual = rectangle.Area();

            //assert --yes, i know double != double, but i use integer values--
            Assert.Equal(expected, actual);
        }

        #endregion Rectangle
    }
}