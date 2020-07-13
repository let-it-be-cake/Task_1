using System;
using Task_2.Figures;
using Xunit;

namespace Task_2.Test
{
    public class AbstractFigureTest
    {
        #region AbstractFigure
        [Fact]
        public void AbstractFigure_GetSides_ArraySide_returned()
        {
            //arrange
            double side1 = 2;
            double side2 = 3;
            double side3 = 4;
            double side4 = 5;
            double side5 = 6;
            double side6 = 7;
            double side7 = 7;
            AbstractFigure abstractFigure = new AbstractFigure(side1, side2, side3, side4, side5, side6, side7);
            double[] expected = new double[] { side1, side2, side3, side4, side5, side6, side7 };

            //act

            double[] actual = abstractFigure.GetSides();

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AbstractFigure_Perimeter_35returned()
        {
            //arrange
            double side1 = 2;
            double side2 = 3;
            double side3 = 4;
            double side4 = 5;
            double side5 = 6;
            double side6 = 7;
            double side7 = 8;
            AbstractFigure abstractFigure = new AbstractFigure(side1, side2, side3, side4, side5, side6, side7);
            double expected = 35;

            //act

            double actual = abstractFigure.Perimetr();

            //assert --yes, i know double != double, but i use integer values--
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AbstractFigure_WrongSides_Error_returned()
        {
            //arrange
            double side1 = 1;
            double side2 = 1;
            double side3 = 1;
            double side4 = 1;
            double side5 = 1;
            double side6 = 1;
            double side7 = 70;

            //act
            //ArgumentException

            //assert
            Assert.Throws<ArgumentException>(() => new AbstractFigure(side1, side2, side3, side4, side5, side6, side7));
        }
        #endregion AbstractFigure
    }
}