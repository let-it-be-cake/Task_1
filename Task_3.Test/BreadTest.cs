using Task_3.Products;
using Xunit;

namespace Task_3.Test
{
    public class BreadTest
    {
        #region Testing operator +

        [Fact]
        public void Test_1_summing()
        {
            //arrange
            Bread bread1 = new Bread(100, "Chip");
            Bread bread2 = new Bread(1000, "Expensive");

            Bread expected = new Bread(550, "Chip-Expensive");

            //act
            var actual = bread1 + bread2;

            //asserts
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_2_summing()
        {
            //arrange
            Bread bread1 = new Bread(10, "Chip") { Weight = 100 };
            Bread bread2 = new Bread(90, "Not-Chip") { Weight = 100 };

            Bread expected = new Bread(50, "Not-Chip-Chip");

            //act
            var actual = bread2 + bread1;

            //asserts
            Assert.Equal(expected, actual);
        }

        #endregion Testing operator +

        #region Testing converting to notepad
        [Fact]
        public void Test_1_Convert_Bread_to_Notepad()
        {
            //arrange
            Bread bread = new Bread(10, "Extra") { Weight= 200 };

            Notepad expected = new Notepad(10, "Extra");

            //act
            Notepad actual = (Notepad)bread;

            //asserts
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Test_2_Convert_Bread_to_Notepad()
        {
            //arrange
            Bread bread = new Bread() { Name = "Notepad"};

            Notepad expected = new Notepad();

            //act
            Notepad actual = (Notepad)bread;

            //asserts
            Assert.Equal(expected, actual);
        }
        #endregion Testing converting to notepad

        #region Testing converting to Lamp
        [Fact]
        public void Test_1_Convert_Bread_to_Lamp()
        {
            //arrange
            Bread bread = new Bread(10, "Extra") { Weight = 200 };

            Lamp expected = new Lamp(10, "Extra");

            //act
            Lamp actual = (Lamp)bread;

            //asserts
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Test_2_Convert_Bread_to_Lamp()
        {
            //arrange
            Bread bread = new Bread() { Name = "Lamp"};

            Lamp expected = new Lamp();

            //act
            Lamp actual = (Lamp)bread;

            //asserts
            Assert.Equal(expected, actual);
        }
        #endregion Testing converting to Lamp
    }
}