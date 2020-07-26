using Shapes.MaterialShapes;
using System;
using Xunit;

namespace Shape.Test
{
    public class MembraneCircleTest
    {
        [Fact]
        public void MembraneCircle_Test_New_PaperCircle()
        {

            // arrange
            PaperCircle membraneCircle = new PaperCircle(20);

            // assert

            Assert.Throws<Exception>(() => new MembraneCircle(10, membraneCircle));
        }

        [Fact]
        public void MembraneCircle_Test_New_MembraneCircle_from_MembraneTriangle()
        {

            // arrange
            MembraneTriangle membraneCircle = new MembraneTriangle(40, 30, 20);

            MembraneCircle expected = new MembraneCircle(8);

            // act
            var actual = new MembraneCircle(8, membraneCircle);

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MembraneCircle_Test_New_MembraneCircle_from_Bigger_MembraneCircle()
        {

            // arrange
            MembraneCircle membraneCircle = new MembraneCircle(20);

            // assert
            Assert.Throws<Exception>(() => new MembraneCircle(40, membraneCircle));
        }
    }
}
