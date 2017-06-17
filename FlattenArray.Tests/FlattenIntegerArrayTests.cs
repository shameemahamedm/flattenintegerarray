// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FlattenIntegerArrayTests.cs" author="Shameem Ahamed">
//   Copyright (c) All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.IO;
using NUnit.Framework;
using System.Linq;

namespace FlattenArray.Tests
{
    [TestFixture]
    public class FlattenIntegerArrayTests
    {
        [SetUp]
        public void Setup()
        {
            flattenIntegerArrays = new FlattenIntegerArrays();
        }

        private FlattenIntegerArrays flattenIntegerArrays;

        [TestCase(1)]
        [TestCase(1, 2)]
        [TestCase(1, 2, new object[] { 3 })]
        [TestCase(1, 2, new object[] { 3, new object[] { 6, 7 } })]
        [TestCase(1, 2, new object[] { 3 }, 4, new object[] { 5, new object[] { 6, 7 } }, 8)]
        [TestCase(1, 2, new object[] { 3 }, 4, new object[] { 5, new object[] { 6, 7 } }, 8)]
        public void GetFlattenedArray_ValidArrays_ReturnsFlattenedArray(object[] inputArrays)
        {
            var result = flattenIntegerArrays.GetFlattenedArray(inputArrays);

            Assert.IsTrue(result.Count() > 0);
        }

        [TestCase(1, 2, new object[] { "string" }, 4, new object[] { 5, new object[] { 6, 7 } }, 8)]
        [TestCase(1.001, 2, new object[] { "3" }, 4, new object[] { 5, new object[] { 6, 7 } }, 8)]
        [TestCase(1234567891234, 2, new object[] { 3 }, 4)]
        [TestCase(1234567891234, 2, new[] { true }, 4)]
        public void GetFlattenedArray_InvalidDataTypeInArray_ThrowsException(object[] inputArrays)
        {
            Assert.Catch<InvalidDataException>(() => flattenIntegerArrays.GetFlattenedArray(inputArrays));
        }

        [TestCase(1, 2, new object[] { }, 4, new object[] { 5, new object[] { 6, 7 } }, 8)]
        public void GetFlattenedArray_BlankInArray_ReturnsResult(object[] inputArrays)
        {
            var result = flattenIntegerArrays.GetFlattenedArray(inputArrays);

            Assert.IsTrue(result.Count() > 0);
        }

        [TestCase(1, new[] { 2, 3 }, 4)]
        [TestCase(1, 2, new int[] { }, 4, new object[] { 5, new[] { 6, 7 } }, 8)]
        public void GetFlattenedArray_IntegerArrays_ReturnsResult(object[] inputArrays)
        {
            var result = flattenIntegerArrays.GetFlattenedArray(inputArrays);

            Assert.IsTrue(result.Count() > 0);
        }
    }
}