using Serialization;
using System;
using System.Collections.Generic;
using Xunit;

namespace SerializatorTest.JsonTest
{
    public class SerializationDeserializationTest
    {
        /// <summary>
        /// Data for testing using the TestClass2 class
        /// </summary>
        /// <returns>Test collection</returns>
        public static IEnumerable<object[]> DataTest1()
        {
            yield return new object[] {
                new List<string> { "Test1", "Test2"},
                new int[]{ 42, 2112 },
                new string("Json4.Json")
            };
            yield return new object[] {
                new List<string> { "NeTest1", "NeTest2"},
                new int[]{ 4222, 2111 },
                new string("Json5.Json")
            };
            yield return new object[] {
                new List<string> { "AntiTest1", "AntiTest2"},
                new int[]{ 1, 2 },
                new string("Json6.Json")
            };
        }

        /// <summary>
        /// Data for testing collections using the TestClass1 class
        /// </summary>
        /// <returns>Test collection</returns>
        public static IEnumerable<object[]> DataClassTest1()
        {
            yield return new object[]
            {
                new List<TestClass1>()
                {
                    new TestClass1()
                    {
                        field1 = "Test1", field2 = 1, field3 = 1.1
                    },
                    new TestClass1()
                    {
                        field1 = "Test2", field2 = 42, field3 = 11.11
                    },
                },
                new string("Json10.Json")
            };
            yield return new object[]
            {
                new List<TestClass1>()
                {
                    new TestClass1()
                    {
                        field1 = "Test3", field2 = 100, field3 = 10.01
                    },
                    new TestClass1()
                    {
                        field1 = "Test4", field2 = 420, field3 = 21.11
                    },
                },
                new string("Json11.Json")
            };
            yield return new object[]
            {
                new List<TestClass1>()
                {
                    new TestClass1()
                    {
                        field1 = "Test5", field2 = 1111, field3 = 11.11
                    },
                    new TestClass1()
                    {
                        field1 = "Test6", field2 = 242, field3 = 101.011
                    },
                },
                new string("Json12.Json")
            };
        }

        /// <summary>
        /// Data for testing collections using the TestClass2 class
        /// </summary>
        /// <returns>Test collection</returns>
        public static IEnumerable<object[]> DataClassTest2()
        {
            yield return new object[]
            {
                new List<TestClass2>()
                {
                    new TestClass2()
                    {
                        field1 = new List<string>(){ "ZM", "ag"},
                        field2 =  new int[]{ 12, 22 },
                    },
                    new TestClass2()
                    {
                        field1 = new List<string> { "Test1", "Test2"},
                        field2 = new int[]{ 42, 2112 },
                    },
                },
                new string("Json13.Json")
            };

            yield return new object[]
            {
                new List<TestClass2>()
                {
                    new TestClass2()
                    {
                       field1 =  new List<string> { "Commi", "Liber"},
                       field2=  new int[]{ 1, 2 },
                    },
                    new TestClass2()
                    {
                        field1 = new List<string> { "NeTest1", "NeTest2"},
                        field2 = new int[]{ 4222, 2111 },
                    },
                },
                new string("Json14.Json")
            };

            yield return new object[]
            {
                new List<TestClass2>()
                {
                    new TestClass2()
                    {
                        field1 = new List<string> { "Ra", "si"},
                        field2 = new int[]{ 4252, 2281 },
                    },
                    new TestClass2()
                    {
                        field1 = new List<string> { "AntiTest1", "AntiTest2"},
                        field2 = new int[]{ 1, 2 },
                    },
                },
                new string("Json15.Json")
            };
        }

        /// <summary>
        /// Testing serializable deserializable functions for a Serializator class in an Json file
        /// </summary>
        /// <param name="field1">Test field 1</param>
        /// <param name="field2">Test field 2</param>
        /// <param name="field3">Test field 3</param>
        /// <param name="path">Path to save serializable file</param>
        [Theory]
        [InlineData("Test1", 1, 1.1, "Json1.Json")]
        [InlineData("Test100", 100, 10.01, "Json2.Json")]
        [InlineData("Test111", 1111, 11.11, "Json3.Json")]
        public void Serialize_Deserialize_Generic_To_Json_File_TestClass1(string field1, int field2, double field3, string path)
        {
            //arrange
            Serializator<TestClass1> serializator = new Serializator<TestClass1>(typeof(TestClass1));
            TestClass1 expect = new TestClass1();
            expect.field1 = field1;
            expect.field2 = field2;
            expect.field3 = field3;

            //act
            serializator.ToJson(expect, path);
            var actual = serializator.FromJson(path);

            // assert
            Assert.Equal(expect, actual);
        }

        /// <summary>
        /// Testing serializable deserializable functions for a Serializator class in an Json file
        /// </summary>
        /// <param name="field1">Test field 1</param>
        /// <param name="field2">Test field 2</param>
        /// <param name="path">Path to save serializable file</param>
        [Theory]
        [MemberData(nameof(DataTest1))]
        public void Serialize_Deserialize_Generic_To_Json_File_TestClass2(List<string> field1, int[] field2, string path)
        {
            //arrange
            Serializator<TestClass2> serialization = new Serializator<TestClass2>(typeof(TestClass2));
            TestClass2 expected = new TestClass2();
            expected.field1 = field1;
            expected.field2 = field2;

            //act
            serialization.ToJson(expected, path);
            var actual = serialization.FromJson(path);

            //assert
            Assert.Equal(expected, actual);
        }

        /// <summary>
        ///  Testing serializable deserializable functions for a Serializator collection generic class in an Json file
        /// </summary>
        /// <param name="expected">Correc parameters to be serialized</param>
        /// <param name="path">Path to save serializable file</param>
        [Theory]
        [MemberData(nameof(DataClassTest1))]
        public void Serialize_Deserialize_Generic_Collection_To_Json_File_TestClass1(List<TestClass1> expected, string path)
        {
            //arrange
            Serializator<TestClass1> serialization = new Serializator<TestClass1>(typeof(List<TestClass1>));

            //act
            serialization.ToJson(expected, path);
            var actual = serialization.FromJsonCollection(path);

            //assert
            Assert.Equal(expected, actual);
        }

        /// <summary>
        ///  Testing serializable deserializable functions for a Serializator collection generic class in an Json file
        /// </summary>
        /// <param name="expected">Correc parameters to be serialized</param>
        /// <param name="path">Path to save serializable file</param>
        [Theory]
        [MemberData(nameof(DataClassTest2))]
        public void Serialize_Deserialize_Generic_Collection_To_Json_File_TestClass2(List<TestClass2> expected, string path)
        {
            //arrange
            Serializator<TestClass2> serialization = new Serializator<TestClass2>(typeof(List<TestClass2>));

            //act
            serialization.ToJson(expected, path);
            var actual = serialization.FromJsonCollection(path);

            //assert
            Assert.Equal(expected, actual);
        }

       
    }
}