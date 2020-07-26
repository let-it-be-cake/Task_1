using Shapes.MaterialShapes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Shape.Test
{
    public class PaperCircleTest
    {
        [Fact]
        public void PaperCircle_Test_New_MembraneCircle()
        {

            // arrange
            MembraneCircle paperCircle = new MembraneCircle(20);

            // assert
            Assert.Throws<Exception>(() => new PaperCircle(10, paperCircle));
        }

        [Fact]
        public void PaperCircle_Test_New_PaperCircle_from_PaperTriangle()
        {

            // arrange
            PaperTriangle paperCircle= new PaperTriangle(40, 30, 20);

            PaperCircle expected = new PaperCircle(8);

            // act
            var actual = new PaperCircle(8, paperCircle);

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PaperCircle_Test_New_PaperCircle_from_Bigger_PaperCircle()
        {

            // arrange
            PaperCircle paperCircle = new PaperCircle(20);

            // assert

            Assert.Throws<Exception>(() => new PaperCircle(40, paperCircle));
        }
    }
}
