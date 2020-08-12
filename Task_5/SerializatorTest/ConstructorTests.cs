using Serialization;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SerializatorTest
{
    public class ConstructorTests
    {
        [Fact]
        public void Serializator_Constructor_Exception_Havnt_ClassVersion_Attribute_Test()
        {
            //arrange
            var expected = new TestClassErrorClassVersion();

            //assert
            Assert.Throws<ArgumentException>(() =>
                new Serializator<TestClassErrorClassVersion>(typeof(TestClassErrorClassVersion)));
        }

        [Fact]
        public void Serializator_Constructor_Exception_Havnt_Serializable_Attribute_Test()
        {
            //arrange
            var expected = new TestClassErrorSerializable();

            //assert
            Assert.Throws<ArgumentException>(() =>
                new Serializator<TestClassErrorSerializable>(typeof(TestClassErrorSerializable)));
        }
        

    }
}
