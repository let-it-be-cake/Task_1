using Shapes.MaterialShapes;
using System;
using Xunit;

namespace Shape.Test
{
    public class PaperTriangleTest
    {
        [Fact]
        public void PaperTriangle_Test_New_MembraneTriangle()
        {
            // arrange
            MembraneTriangle paperTriangle = new MembraneTriangle(10, 10, 10);

            // assert

            Assert.Throws<Exception>(() => new PaperTriangle(2, 2, 2, paperTriangle));
        }

        [Fact]
        public void PaperTriangle_Test_New_PaperTriangle_from_PaperCircle()
        {
            // arrange
            PaperCircle paperTriangle = new PaperCircle(20);

            PaperTriangle expected = new PaperTriangle(10, 10, 10);

            // act
            var actual = new PaperTriangle(10, 10, 10, paperTriangle);

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PaperTriangle_Test_New_PaperTriangle_from_Bigger_PaperTriangle()
        {
            // arrange
            PaperTriangle paperTriangle = new PaperTriangle(2, 2, 2);

            // assert

            Assert.Throws<Exception>(() => new PaperTriangle(10, 10, 10, paperTriangle));
        }
    }
}