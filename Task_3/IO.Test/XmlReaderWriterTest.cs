using System;
using System.IO;
using Xunit;

using IO;
using System.Collections.Generic;
using Shapes.Interfaces;
using Shapes.MaterialShapes;
using Shapes.Enums;

namespace IO.Test
{
    public class XmlReaderWriterTest
    {
        [Fact]
        public void XmlReadWriteTest_6_objects()
        {
            //arrange
            List<Shape> expected = new List<Shape>();

            PaperTriangle paperTriangle = new PaperTriangle(1,2,1);
            paperTriangle.Coloring(Color.Cornsilk);

            PaperRectangle paperRectangle = new PaperRectangle(10, 8);
            paperRectangle.Coloring(Color.Green);

            PaperCircle paperCircle = new PaperCircle(10);
            paperCircle.Coloring(Color.Cyan);

            MembraneTriangle membraneTriangle = new MembraneTriangle(10, 12, 11);

            MembraneRectangle membraneRectangle = new MembraneRectangle(4, 5);

            MembraneCircle membraneCircle = new MembraneCircle(4);

            expected.Add(paperTriangle);
            expected.Add(membraneTriangle);
            expected.Add(paperCircle);
            expected.Add(membraneCircle);
            expected.Add(paperRectangle);
            expected.Add(membraneRectangle);

            var stream1 = new IO.XmlWriter("test10.xml");
            var stream2 = new IO.XmlReader("test10.xml");

            // act
            stream1.Write(expected);
            var actual = stream2.Read();

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void StreamReadWriteTest_3_objects()
        {
            //arrange
            List<Shape> expected = new List<Shape>();

            PaperTriangle paperTriangle = new PaperTriangle(1,2,1);

            PaperRectangle paperRectangle = new PaperRectangle(10, 8);
            paperRectangle.Coloring(Color.Green);

            MembraneCircle membraneCircle = new MembraneCircle(4);

            expected.Add(paperTriangle);
            expected.Add(membraneCircle);
            expected.Add(paperRectangle);

            var stream1 = new IO.XmlWriter("test11.xml");
            var stream2 = new IO.XmlReader("test11.xml");

            // act
            stream1.Write(expected);
            var actual = stream2.Read();

            // assert
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void StreamReadWriteTest_12_objects()
        {
            //arrange
            List<Shape> expected = new List<Shape>();

            PaperTriangle paperTriangle1 = new PaperTriangle(1, 2, 1);

            PaperRectangle paperRectangle1 = new PaperRectangle(10, 8);
            paperRectangle1.Coloring(Color.Green);

            PaperCircle paperCircle1 = new PaperCircle(10);
            paperCircle1.Coloring(Color.Cyan);

            PaperTriangle paperTriangle2 = new PaperTriangle(4, 7, 9);

            PaperRectangle paperRectangle2 = new PaperRectangle(3, 2);
            paperRectangle1.Coloring(Color.Green);

            PaperCircle paperCircle2 = new PaperCircle(19);

            MembraneTriangle membraneTriangle1 = new MembraneTriangle(10, 12, 11);

            MembraneRectangle membraneRectangle1 = new MembraneRectangle(4, 5);

            MembraneCircle membraneCircle1 = new MembraneCircle(4);

            MembraneTriangle membraneTriangle2 = new MembraneTriangle(20, 12, 11);

            MembraneRectangle membraneRectangle2 = new MembraneRectangle(11, 7);

            MembraneCircle membraneCircle2 = new MembraneCircle(13);

            expected.Add(paperTriangle1);
            expected.Add(membraneTriangle1);
            expected.Add(paperCircle1);
            expected.Add(membraneCircle1);
            expected.Add(paperRectangle1);
            expected.Add(membraneRectangle1);

            expected.Add(paperTriangle2);
            expected.Add(membraneTriangle2);
            expected.Add(paperCircle2);
            expected.Add(membraneCircle2);
            expected.Add(paperRectangle2);
            expected.Add(membraneRectangle2);

            var stream1 = new IO.XmlWriter("test12.xml");
            var stream2 = new IO.XmlReader("test12.xml");

            // act
            stream1.Write(expected);
            var actual = stream2.Read();

            // assert
            Assert.Equal(expected, actual);
        }
    }
}
