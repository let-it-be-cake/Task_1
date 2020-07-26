using Shapes.MaterialShapes;
using System;
using Xunit;

namespace Shape.Test
{
    public class MembraneTriangleTest
    {
        [Fact]
        public void MembraneTriangle_Test_New_PaperTriangle()
        {
            // arrange
            PaperTriangle membraneTriangle = new PaperTriangle(10, 10, 10);

            // assert

            Assert.Throws<Exception>(() => new MembraneTriangle(3, 3, 3, membraneTriangle));
        }

        [Fact]
        public void MembraneTriangle_Test_New_MembraneTriangle_from_MembraneCircle()
        {
            // arrange
            MembraneCircle membraneTriangle= new MembraneCircle(20);

            MembraneTriangle expected = new MembraneTriangle(10, 10, 10);

            // act
            var actual = new MembraneTriangle(10, 10, 10, membraneTriangle);

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MembraneTriangle_Test_New_MembraneTriangle_from_Bigger_MembraneTriangle()
        {
            // arrange
            MembraneTriangle membraneTriangle = new MembraneTriangle(2, 2, 2);

            // assert
            Assert.Throws<Exception>(() => new MembraneTriangle(10, 10, 10, membraneTriangle));
        }
    }
}