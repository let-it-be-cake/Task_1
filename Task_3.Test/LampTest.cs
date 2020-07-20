using Task_3.Products;
using Xunit;

namespace Task_3.Test
{
    public class LampTest
    {
        #region Testing operator +

        [Fact]
        public void Test_1_summing()
        {
            //arrange
            Lamp lamp1 = new Lamp(100, "Chip");
            Lamp lamp2 = new Lamp(1000, "Expensive");

            Lamp expected = new Lamp(550, "Chip-Expensive");

            //act
            var actual = lamp1 + lamp2;

            //asserts
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_2_summing()
        {
            //arrange
            Lamp lamp1 = new Lamp(10, "Chip") { Power = 100 };
            Lamp lamp2 = new Lamp(90, "Power") { Power = 100 };

            Lamp expected = new Lamp(50, "Chip-Power");

            //act
            var actual = lamp1 + lamp2;

            //asserts
            Assert.Equal(expected, actual);
        }

        #endregion Testing operator +

        #region Testing converting to notepad
        [Fact]
        public void Test_1_Convert_Lamp_to_Notepad()
        {
            //arrange
            Lamp lamp = new Lamp(10, "Extra") { Power = 200 };

            Notepad expected = new Notepad(10, "Extra");

            //act
            Notepad actual = (Notepad)lamp;

            //asserts
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Test_2_Convert_Lamp_to_Notepad()
        {
            //arrange
            Lamp lamp = new Lamp() { Name = "Notepad"};

            Notepad expected = new Notepad();

            //act
            Notepad actual = (Notepad)lamp;

            //asserts
            Assert.Equal(expected, actual);
        }
        #endregion Testing converting to notepad

        #region Testing converting to Bread
        [Fact]
        public void Test_1_Convert_Lamp_to_Bread()
        {
            //arrange
            Lamp lamp = new Lamp(10, "Extra") { Power = 200 };

            Bread expected = new Bread(10, "Extra");

            //act
            Bread actual = (Bread)lamp;

            //asserts
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Test_2_Convert_Lamp_to_Bread()
        {
            //arrange
            Lamp lamp = new Lamp() { Name = "Bread"};

            Bread expected = new Bread();

            //act
            Bread actual = (Bread)lamp;

            //asserts
            Assert.Equal(expected, actual);
        }
        #endregion Testing converting to Lamp
    }
}