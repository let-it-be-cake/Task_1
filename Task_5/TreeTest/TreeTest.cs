using System.Collections.Generic;
using Xunit;

namespace TreeTest
{
    public class TreeTest
    {
        /// <summary>
        /// Checking values for existence
        /// </summary>
        [Fact]
        public void Add_5_int_values_in_tree_and_found_this_value_using_FindNode()
        {
            // arrange
            Tree<int> tree = new Tree<int>();
            tree.Add(4);
            tree.Add(14);
            tree.Add(-1);
            tree.Add(-84);
            tree.Add(8);

            // assert
            Assert.Equal(4, tree.FindNode(4).Value);
            Assert.Equal(14, tree.FindNode(14).Value);
            Assert.Equal(-1, tree.FindNode(-1).Value);
            Assert.Equal(-84, tree.FindNode(-84).Value);
            Assert.Equal(8, tree.FindNode(8).Value);
        }

        public static IEnumerable<object[]> DataInt()
        {
            yield return new object[] {
                new List<int> { 57, 15, 25, 17, 95, 34, 50, 82, 63, 10},
            };
            yield return new object[] {
                new List<int> {91, 60, 1, 85, 56, 8, 47},
            };
            yield return new object[] {
                new List<int> { 75, 30, 41, 34, 40, 65, 72, 70, 74, 64, 6, 31, 83, 37, 18, 28, 29, 69},
            };
        }

        /// <summary>
        /// Checking values for existence
        /// </summary>
        /// <param name="numbers">list of int values</param>
        [Theory]
        [MemberData(nameof(DataInt))]
        public void Add_IEnumberable_int_Collection_in_the_tree_and_found_this_using_FindNode(List<int> numbers)
        {
            //arrange
            Tree<int> tree = new Tree<int>();
            foreach (var value in numbers)
                tree.Add(value);
            //assert
            foreach (var value in numbers)
                Assert.Equal(value, tree.FindNode(value).Value);
        }

        public static IEnumerable<object[]> DataString()
        {
            yield return new object[] {
                new List<string> {  "thrust",
                                    "nuclear",
                                    "disagree",
                                    "dragon",
                                    "thigh",
                                    "houseplant",
                                    "X-ray",
                                    "sweet"},
            };
            yield return new object[] {
                new List<string> {  "valid",
                                    "burial",
                                    "comfort",
                                    "cabin",
                                    "camp",
                                    "crime",
                                    "insight",
                                    "thaw",
                                    "formulate",
                                    "ant",
                                    "dribble"},
            };
            yield return new object[] {
                new List<string> {  "pause",
                                    "constituency",
                                    "woman",
                                    "recruit",
                                    "pumpkin",
                                    "leaflet",
                                    "principle",
                                    "oven",
                                    "nonremittal",
                                    "excess",
                                    "face",
                                    "landscape",
                                    "comedy",
                                    "adoption"},
            };
        }

        /// <summary>
        /// Checking values for existence
        /// </summary>
        /// <param name="numbers">list of string values</param>
        [Theory]
        [MemberData(nameof(DataString))]
        public void Add_IEnumberable_string_Collection_in_the_tree_and_found_this_using_FindNode(List<string> numbers)
        {
            //arrange
            Tree<string> tree = new Tree<string>();
            foreach (var value in numbers)
                tree.Add(value);
            //assert
            foreach (var value in numbers)
                Assert.Equal(value, tree.FindNode(value).Value);
        }

        public static IEnumerable<object[]> DataIntBalance()
        {
            yield return new object[] {
               new List<int> { 34, 15, 63, 10, 17, 50, 82, 25, 57, 95 }
            };
            yield return new object[] {
                new List<int> { 56, 8, 85, 1, 47, 60, 91 }
            };
            yield return new object[] {
                 new List<int> { 40, 29, 70, 18, 31, 64, 74, 6, 28, 30, 34, 41, 65, 72, 75, 37, 69, 83}
            };
        }

        /// <summary>
        /// Inserting an ordered tree, sorting, to create a bad tree and balancing it
        /// </summary>
        /// <param name="numbers">Balanced collection for a tree</param>
        [Theory]
        [MemberData(nameof(DataIntBalance))]
        public void Add_IEnumberable_int_Collection_in_the_tree_and_balancing_tree(List<int> numbers)
        {
            //arrange
            Tree<int> excepted = new Tree<int>();
            foreach (var value in numbers)
                excepted.Add(value);

            //act
            numbers.Sort();
            Tree<int> actual = new Tree<int>();
            foreach (var value in numbers)
                actual.Add(value);
            actual.Balancing();
            //assert
            Assert.Equal(excepted, actual);
        }
    }
}