using Shapes.MaterialShapes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Shape.Test
{
    public class MembraneRectangleTest
    {
        [Fact]
        public void MembraneRectangle_Test_New_PaperRectangle()
        {

            // arrange
            PaperRectangle membraneRectangle = new PaperRectangle(20, 10);

            // assert

            Assert.Throws<Exception>(() => new MembraneRectangle(10, 10, membraneRectangle));
        }

        [Fact]
        public void MembraneRectangle_Test_New_MembraneRectangle_from_MembraneTriangle()
        {

            // arrange
            MembraneTriangle membraneRectangle = new MembraneTriangle(40, 30, 20);

            MembraneRectangle expected = new MembraneRectangle(8, 8);

            // act
            var actual = new MembraneRectangle(8, 8, membraneRectangle);

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MembraneRectangle_Test_New_MembraneRectangle_from_Bigger_MembraneRectangle()
        {

            // arrange
            MembraneRectangle membraneRectangle = new MembraneRectangle(20, 20);

            // assert
            Assert.Throws<Exception>(() => new MembraneRectangle(40, 40, membraneRectangle));
        }
    }
}
