using Girl;
using Shapes.Enums;
using Shapes.Interfaces;
using Shapes.MaterialShapes;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BoxTest
{
    public class BoxTest
    {
        #region Add Method

        [Fact]
        public void Add_Test_1_object()
        {
            // arrange
            var box = new Box();

            PaperTriangle excepted = new PaperTriangle(1, 2, 1);

            // act
            box.Add(excepted);
            var actual = box.Peek(0);

            // assert
            Assert.Equal(actual, excepted);
        }

        [Fact]
        public void Add_Test_Several_objects()
        {
            // arrange
            var box = new Box();

            PaperTriangle excepted = new PaperTriangle(1, 2, 1);

            // act
            box.Add(excepted);

            // assert
            Assert.Throws<ArgumentException>(() => box.Add(excepted));
        }

        [Fact]
        public void Add_Test_7_objects()
        {
            //arrange
            int excepted = 7;

            var box = new Box();

            PaperTriangle paperTriangle = new PaperTriangle(1, 2, 1);
            paperTriangle.Coloring(Color.Cornsilk);

            PaperRectangle paperRectangle = new PaperRectangle(10, 8);
            paperRectangle.Coloring(Color.Green);

            PaperCircle paperCircle = new PaperCircle(10);
            paperCircle.Coloring(Color.Cyan);

            MembraneTriangle membraneTriangle = new MembraneTriangle(10, 12, 11);

            MembraneRectangle membraneRectangle = new MembraneRectangle(4, 5);

            MembraneCircle membraneCircle = new MembraneCircle(4);

            PaperRectangle paperRectangle1 = new PaperRectangle(10, 8);

            // act
            box.Add(paperTriangle);
            box.Add(membraneTriangle);
            box.Add(paperCircle);
            box.Add(membraneCircle);
            box.Add(paperRectangle);
            box.Add(membraneRectangle);
            box.Add(paperRectangle1);

            int actual = box.Count();

            // assert
            Assert.Equal(excepted, actual);
        }

        #endregion Add Method

        #region Poll Method
        [Fact]
        public void Poll_Test_1_object()
        {
            // arrange
            var box = new Box();

            PaperTriangle excepted = new PaperTriangle(1, 2, 1);

            // act
            box.Add(excepted);
            var actual = box.Poll(0);

            // assert
            Assert.Equal(actual, excepted);
        }

        [Fact]
        public void Poll_Test_3_object()
        {
            // arrange
            var box = new Box();

            PaperTriangle excepted = new PaperTriangle(1, 2, 1);
            PaperTriangle triangle = new PaperTriangle(8, 9, 10);
            MembraneCircle circle = new MembraneCircle(10);

            // act
            box.Add(triangle);
            box.Add(excepted);
            box.Add(circle);
            var actual = box.Peek(1);

            // assert
            Assert.Equal(actual, excepted);
        }

        [Fact]
        public void Poll_Test_0_object()
        {
            // arrange
            var box = new Box();

            // assert
            Assert.Throws<ArgumentOutOfRangeException>(() => box.Poll(0));
        }
        #endregion Poll Method
        
        #region Replace Method
        [Fact]
        public void Replace_Test_1_object()
        {
            // arrange
            var box = new Box();

            PaperTriangle excepted = new PaperTriangle(1, 2, 1);

            MembraneCircle circle = new MembraneCircle(10);

            // act
            box.Add(circle);
            box.Replace(excepted, 0);
            var actual = box.Peek(0);

            // assert
            Assert.Equal(actual, excepted);
        }

        [Fact]
        public void Replace_Test_2_object()
        {
            // arrange
            var box = new Box();

            PaperTriangle excepted = new PaperTriangle(1, 2, 1);

            PaperTriangle triangle = new PaperTriangle(8, 9, 10);
            MembraneCircle circle = new MembraneCircle(10);

            // act
            box.Add(triangle);
            box.Add(circle);
            box.Replace(excepted, 1);
            var actual = box.Peek(1);

            // assert
            Assert.Equal(actual, excepted);
        }

        [Fact]
        public void Replace_Test_0_object()
        {
            // arrange
            var box = new Box();

            PaperTriangle excepted = new PaperTriangle(1, 2, 1);

            // assert
            Assert.Throws<ArgumentOutOfRangeException>(() => box.Replace(excepted, 0));
        }

        #endregion Replace Method

        #region Find Method

        [Fact]
        public void Find_Test_1()
        {
            // arrange
            var box = new Box();

            MembraneTriangle rectangle = new MembraneTriangle(10, 6, 8);

            PaperTriangle excepted = new PaperTriangle(6, 8, 10);

            // act

            box.Add(excepted);
            var actual = box.Find(rectangle).First();

            // assert
            Assert.Equal(excepted, actual);
        }

        #endregion Find Method

        #region Area Method

        [Fact]
        public void Area_Test_1()
        {
            // arrange
            var box = new Box();

            MembraneRectangle rectangle = new MembraneRectangle(6, 4);

            PaperTriangle triangle = new PaperTriangle(6, 8, 10);

            int excepted = 48;

            // act

            box.Add(rectangle);
            box.Add(triangle);
            var actual = box.Area();

            // assert
            Assert.Equal(excepted, actual);
        }

        [Fact]
        public void Area_Test_2()
        {
            // arrange
            var box = new Box();

            MembraneRectangle rectangle = new MembraneRectangle(6, 4);

            MembraneRectangle rectangle2 = new MembraneRectangle(2, 2);

            PaperTriangle triangle = new PaperTriangle(6, 8, 10);

            int excepted = 52;

            // act

            box.Add(rectangle);
            box.Add(triangle);
            box.Add(rectangle2);

            var actual = box.Area();

            // assert
            Assert.Equal(excepted, actual);
        }

        [Fact]
        public void Area_Test_3()
        {
            // arrange
            var box = new Box();

            MembraneRectangle rectangle = new MembraneRectangle(10, 4);

            MembraneRectangle rectangle2 = new MembraneRectangle(2, 2);

            PaperTriangle triangle = new PaperTriangle(6, 8, 10);

            int excepted = 68;

            // act

            box.Add(rectangle);
            box.Add(triangle);
            box.Add(rectangle2);

            var actual = box.Area();

            // assert
            Assert.Equal(excepted, actual);
        }
        #endregion Area Method

        #region Perimeter Method

        [Fact]
        public void Perimeter_Test_1()
        {
            // arrange
            var box = new Box();

            MembraneRectangle rectangle = new MembraneRectangle(6, 4);

            PaperTriangle triangle = new PaperTriangle(6, 8, 10);

            int excepted = 44;

            // act

            box.Add(rectangle);
            box.Add(triangle);
            var actual = box.Perimeter();

            // assert
            Assert.Equal(excepted, actual);
        }

        [Fact]
        public void Perimeter_Test_2()
        {
            // arrange
            var box = new Box();

            MembraneRectangle rectangle = new MembraneRectangle(6, 4);

            MembraneRectangle rectangle2 = new MembraneRectangle(2, 2);

            PaperTriangle triangle = new PaperTriangle(6, 8, 10);

            int excepted = 52;

            // act

            box.Add(rectangle);
            box.Add(triangle);
            box.Add(rectangle2);

            var actual = box.Perimeter();

            // assert
            Assert.Equal(excepted, actual);
        }

        [Fact]
        public void Perimeter_Test_3()
        {
            // arrange
            var box = new Box();

            MembraneRectangle rectangle = new MembraneRectangle(10, 4);

            MembraneRectangle rectangle2 = new MembraneRectangle(2, 2);

            PaperTriangle triangle = new PaperTriangle(6, 8, 10);

            int excepted = 60;

            // act

            box.Add(rectangle);
            box.Add(triangle);
            box.Add(rectangle2);

            var actual = box.Perimeter();

            // assert
            Assert.Equal(excepted, actual);
        }
        #endregion Perimeter Method

        #region GetMembranes Method

        [Fact]
        public void GetMembranes_Test_6_object()
        {
            //arrange
            var box = new Box();

            PaperTriangle paperTriangle = new PaperTriangle(1, 2, 1);
            paperTriangle.Coloring(Color.Cornsilk);

            PaperRectangle paperRectangle = new PaperRectangle(10, 8);
            paperRectangle.Coloring(Color.Green);

            PaperCircle paperCircle = new PaperCircle(10);
            paperCircle.Coloring(Color.Cyan);

            MembraneTriangle membraneTriangle = new MembraneTriangle(10, 12, 11);

            MembraneRectangle membraneRectangle = new MembraneRectangle(4, 5);

            MembraneCircle membraneCircle = new MembraneCircle(4);

            box.Add(paperTriangle);
            box.Add(membraneTriangle);
            box.Add(paperCircle);
            box.Add(membraneCircle);
            box.Add(paperRectangle);
            box.Add(membraneRectangle);

            var expected = new List<Membrane>();
            expected.Add(membraneTriangle);
            expected.Add(membraneCircle);
            expected.Add(membraneRectangle);

            // act
            var actual = box.GetMembranes().ToList(); ;

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetMembranes_Test_5_object()
        {
            //arrange
            var box = new Box();

            PaperCircle paperCircle = new PaperCircle(10);
            paperCircle.Coloring(Color.Cyan);

            MembraneTriangle membraneTriangle = new MembraneTriangle(10, 12, 11);

            MembraneRectangle membraneRectangle = new MembraneRectangle(4, 5);

            MembraneCircle membraneCircle = new MembraneCircle(4);

            MembraneCircle membraneCircle1 = new MembraneCircle(8);

            box.Add(membraneTriangle);
            box.Add(paperCircle);
            box.Add(membraneCircle);
            box.Add(membraneCircle1);
            box.Add(membraneRectangle);

            var expected = new List<Membrane>();
            expected.Add(membraneTriangle);
            expected.Add(membraneCircle);
            expected.Add(membraneCircle1);
            expected.Add(membraneRectangle);

            // act
            var actual = box.GetMembranes().ToList(); ;

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetMembranes_Test_2_object()
        {
            //arrange
            var box = new Box();

            MembraneRectangle membraneRectangle = new MembraneRectangle(4, 5);

            MembraneCircle membraneCircle = new MembraneCircle(4);

            box.Add(membraneCircle);
            box.Add(membraneRectangle);

            var expected = new List<Membrane>();

            expected.Add(membraneCircle);
            expected.Add(membraneRectangle);

            // act
            var actual = box.GetMembranes().ToList(); ;

            // assert
            Assert.Equal(expected, actual);
        }

        #endregion GetMembranes Method

        #region GetPapers Method

        [Fact]
        public void GetPapers_Test_6_object()
        {
            //arrange
            var box = new Box();

            PaperTriangle paperTriangle = new PaperTriangle(1, 2, 1);
            paperTriangle.Coloring(Color.Cornsilk);

            PaperRectangle paperRectangle = new PaperRectangle(10, 8);
            paperRectangle.Coloring(Color.Green);

            PaperCircle paperCircle = new PaperCircle(10);
            paperCircle.Coloring(Color.Cyan);

            MembraneTriangle membraneTriangle = new MembraneTriangle(10, 12, 11);

            MembraneRectangle membraneRectangle = new MembraneRectangle(4, 5);

            MembraneCircle membraneCircle = new MembraneCircle(4);

            box.Add(paperTriangle);
            box.Add(membraneTriangle);
            box.Add(paperCircle);
            box.Add(membraneCircle);
            box.Add(paperRectangle);
            box.Add(membraneRectangle);

            var expected = new List<Paper>();
            expected.Add(paperTriangle);
            expected.Add(paperCircle);
            expected.Add(paperRectangle);

            // act
            var actual = box.GetPapers().ToList(); ;

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetPapers_Test_5_object()
        {
            //arrange
            var box = new Box();

            PaperCircle paperCircle = new PaperCircle(10);
            paperCircle.Coloring(Color.Cyan);

            MembraneTriangle membraneTriangle = new MembraneTriangle(10, 12, 11);

            MembraneRectangle membraneRectangle = new MembraneRectangle(4, 5);

            MembraneCircle membraneCircle = new MembraneCircle(4);

            MembraneCircle membraneCircle1 = new MembraneCircle(8);

            box.Add(membraneTriangle);
            box.Add(paperCircle);
            box.Add(membraneCircle);
            box.Add(membraneCircle1);
            box.Add(membraneRectangle);

            var expected = new List<Paper>();
            expected.Add(paperCircle);

            // act
            var actual = box.GetPapers().ToList(); ;

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetPapers_Test_2_object()
        {
            //arrange
            var box = new Box();

            PaperRectangle paperRectangle = new PaperRectangle(4, 5);

            PaperCircle paperCircle = new PaperCircle(4);

            box.Add(paperCircle);
            box.Add(paperRectangle);

            var expected = new List<Paper>();

            expected.Add(paperCircle);
            expected.Add(paperRectangle);

            // act
            var actual = box.GetPapers().ToList(); ;

            // assert
            Assert.Equal(expected, actual);
        }

        #endregion GetPapers Method
    }
}