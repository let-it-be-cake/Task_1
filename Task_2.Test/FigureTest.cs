using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task_2.Figures;
using Xunit;

namespace Task_2.Test
{
    public class FigureTest
    {
        [Fact]
        public void Extention_8Elements_2returned()
        {
            //arrange
            double x = 0;
            double y = 0;
            double radius = 8;
            double side1 = 3;
            double side2 = 2;
            double side3 = 3;
            double side4 = 2;
            double side5 = 4;
            double side6 = 2;
            List<Figure> figures = new List<Figure>();
            Figure[] arrayFigures;

            //act
            Triangle searched = new Triangle(side2, side3, side4); //Searched

            Figure[] expected = new Figure[] { searched, searched };

            figures.Add(new Triangle(side1, side2, side3));
            figures.Add(new Triangle(side3, side4, side5));
            figures.Add(searched); //First
            figures.Add(new Rectangle(side5, side2));
            figures.Add(new Rectangle(side6, side3));
            figures.Add(new Circle(x, y, radius));
            figures.Add(searched); //Second
            figures.Add(new AbstractFigure(side3, side4, side1, side6, side5));

            arrayFigures = figures.ToArray();

            Figure[] actual = (Figure.Equal(arrayFigures, searched)).ToArray();

            //assert
            Assert.Equal(expected, actual);
        }
    }
}
