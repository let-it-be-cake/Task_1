using Task_3.Products;
using Xunit;

namespace Task_3.Test
{
    public class NotepadTest
    {
        #region Testing operation +

        [Fact]
        public void Test_1_summing()
        {
            //arrange
            Notepad notepad1 = new Notepad(100, "Chip");
            Notepad notepad2 = new Notepad(1000, "Expensive");

            Notepad expected = new Notepad(550, "Chip-Expensive");

            //act
            var actual = notepad1 + notepad2;

            //asserts
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_2_summing()
        {
            //arrange
            Notepad notepad1 = new Notepad(10, "Extra") { Lists = 192 };
            Notepad notepad2 = new Notepad(90, "List") { Lists = 192 };

            Notepad expected = new Notepad(50, "Extra-List");

            //act
            var actual = notepad1 + notepad2;

            //asserts
            Assert.Equal(expected, actual);
        }

        #endregion Testing operation +

        #region Testing converting to Bread

        [Fact]
        public void Test_1_Convert_Notepad_to_Bread()
        {
            //arrange
            Notepad notepad = new Notepad(10, "Extra") { Lists = 192 };

            Bread expected = new Bread(10, "Extra");

            //act
            Bread actual = (Bread)notepad;

            //asserts
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_2_Convert_Notepad_to_Bread()
        {
            //arrange
            Notepad notepad = new Notepad() { Name = "Bread"};

            Bread expected = new Bread();

            //act
            Bread actual = (Bread)notepad;

            //asserts
            Assert.Equal(expected, actual);
        }

        #endregion Testing converting to Bread

        #region Testing converting to Lamp

        [Fact]
        public void Test_1_Convert_Notepad_to_Lamp()
        {
            //arrange
            Notepad notepad = new Notepad(10, "Extra") { Lists = 192 };

            Lamp expected = new Lamp(10, "Extra");

            //act
            Lamp actual = (Lamp)notepad;

            //asserts
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_2_Convert_Notepad_to_Lamp()
        {
            //arrange
            Notepad notepad = new Notepad() { Name = "Lamp"};

            Lamp expected = new Lamp();

            //act
            Lamp actual = (Lamp)notepad;

            //asserts
            Assert.Equal(expected, actual);
        }

        #endregion Testing converting to Lamp
    }
}