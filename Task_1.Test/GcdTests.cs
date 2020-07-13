using Task_1;
using Xunit;

namespace XUnitTestProject1
{
    public class GcdTests
    {
        #region Euclid(first, second)

        [Fact]
        public void Euclid_884and2431_221returned()
        {
            //arrange
            int x = 884;
            int y = 2431;
            int expected = 221;

            //act
            int actual = Gcd.Euclid(x, y);

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Euclid_221and332_1returned()
        {
            //arrange
            int x = 221;
            int y = 332;
            int expected = 1;

            //act
            int actual = Gcd.Euclid(x, y);

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Euclid_45and9_9returned()
        {
            //arrange
            int x = 45;
            int y = 9;
            int expected = 9;

            //act
            int actual = Gcd.Euclid(x, y);

            //assert
            Assert.Equal(expected, actual);
        }

        #endregion Euclid(first, second)

        #region Euclid(first, second, params int[] numbers)

        [Fact]
        public void Euclid_45and9and39_3returned()
        {
            //arrange
            int a = 45;
            int b = 9;
            int c = 39;
            int expected = 3;

            //act
            int actual = Gcd.Euclid(a, b, c);

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Euclid_179and856and545and101_1returned()
        {
            //arrange
            int a = 179;
            int b = 856;
            int c = 545;
            int d = 101;
            int expected = 1;

            //act
            int actual = Gcd.Euclid(a, b, c, d);

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Euclid_1000and20and80and520and790_20returned()
        {
            //arrange
            int a = 1000;
            int b = 20;
            int c = 80;
            int d = 520;
            int e = 790;
            int expected = 20;

            //act
            int actual = Gcd.Euclid(a, b, c, d);

            //assert
            Assert.Equal(expected, actual);
        }

        #endregion Euclid(first, second, params int[] numbers)

        #region  Euclid(out long time, int first, params int[] numbers)

        [Fact]
        public void EuclidTime_45and12_3returned()
        {
            //arrange
            int a = 45;
            int b = 12;
            long time;

            int expected = 3;

            //act
            int actual = Gcd.Euclid(out time, a, b);

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EuclidTime_3and6and900_3returned()
        {
            //arrange
            int a = 3;
            int b = 6;
            int c = 900;
            long time;

            int expected = 3;

            //act
            int actual = Gcd.Euclid(out time, a, b, c);

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EuclidTime_35and980and665_35returned()
        {
            //arrange
            int a = 35;
            int b = 980;
            int c = 665;
            long time;

            int expected = 35;
            //act
            int actual = Gcd.Euclid(out time, a, b, c);

            //assert
            Assert.Equal(expected, actual);
        }

        #endregion  Euclid(out long time, int first, params int[] numbers)

        #region Stein(first, second)

        [Fact]
        public void Stein_884and2431_221returned()
        {
            //arrange
            int x = 884;
            int y = 2431;
            int expected = 221;

            //act
            int actual = Gcd.Stein(x, y);

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Stein_221and332_1returned()
        {
            //arrange
            int x = 221;
            int y = 332;
            int expected = 1;

            //act
            int actual = Gcd.Stein(x, y);

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Stein_45and9_9returned()
        {
            //arrange
            int x = 45;
            int y = 9;
            int expected = 9;

            //act
            int actual = Gcd.Stein(x, y);

            //assert
            Assert.Equal(expected, actual);
        }

        #endregion Stein(first, second)

        #region Stein(first, second, params int[] numbers)

        [Fact]
        public void Stein_45and9and39_3returned()
        {
            //arrange
            int a = 45;
            int b = 9;
            int c = 39;
            int expected = 3;

            //act
            int actual = Gcd.Stein(a, b, c);

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Stein_179and856and545and101_1returned()
        {
            //arrange
            int a = 179;
            int b = 856;
            int c = 545;
            int d = 101;
            int expected = 1;

            //act
            int actual = Gcd.Stein(a, b, c, d);

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Stein_1000and20and80and520and790_20returned()
        {
            //arrange
            int a = 1000;
            int b = 20;
            int c = 80;
            int d = 520;
            int e = 790;
            int expected = 20;

            //act
            int actual = Gcd.Stein(a, b, c, d);

            //assert
            Assert.Equal(expected, actual);
        }

        #endregion Stein(first, second, params int[] numbers)

        #region  Stein(out long time, int first, params int[] numbers)

        [Fact]
        public void SteinTime_45and12_3returned()
        {
            //arrange
            int a = 45;
            int b = 12;
            long time;

            int expected = 3;

            //act
            int actual = Gcd.Stein(out time, a, b);

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SteinTime_3and6and900_3returned()
        {
            //arrange
            int a = 3;
            int b = 6;
            int c = 900;
            long time;

            int expected = 3;

            //act
            int actual = Gcd.Stein(out time, a, b, c);

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SteinTime_35and980and665_35returned()
        {
            //arrange
            int a = 35;
            int b = 980;
            int c = 665;
            long time;

            int expected = 35;
            //act
            int actual = Gcd.Stein(out time, a, b, c);

            //assert
            Assert.Equal(expected, actual);
        }

        #endregion  Stein(out long time, int first, params int[] numbers)

    }
}