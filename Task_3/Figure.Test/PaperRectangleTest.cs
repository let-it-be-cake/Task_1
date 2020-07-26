using Shapes.MaterialShapes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Shape.Test
{
    public class PaperRectangleTest
    {
        [Fact]
        public void PaperRectangle_Test_New_MembraneRectangle()
        {

            // arrange
            MembraneRectangle paperRectangle = new MembraneRectangle(20, 10);

            // assert

            Assert.Throws<Exception>(() => new PaperRectangle(10, 10, paperRectangle));
        }

        [Fact]
        public void PaperRectangle_Test_New_PaperRectangle_from_PaperTriangle()
        {

            // arrange
           PaperTriangle paperRectangle = new PaperTriangle(40, 30, 20);

            PaperRectangle expected = new PaperRectangle(8, 8);

            // act
            var actual = new PaperRectangle(8, 8, paperRectangle);

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PaperRectangle_Test_New_PaperRectangle_from_Bigger_PaperRectangle()
        {

            // arrange
            PaperRectangle paperRectangle = new PaperRectangle(20, 20);

            // assert

            Assert.Throws<Exception>(() => new PaperRectangle(40, 40, paperRectangle));
        }
    }
}
