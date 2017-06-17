// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FlattenIntegerArrays.cs" author="Shameem Ahamed">
//   Copyright (c) All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.IO;

namespace FlattenArray
{
    /// <summary>
    /// Flatten Integer Arrays
    /// </summary>
    public class FlattenIntegerArrays
    {
        private const string InvalidDataExceptionMessage = "Item is not a valid Integer";

        /// <summary>
        /// Gets the flattened array.
        /// </summary>
        /// <param name="inputArray">The input array.</param>
        /// <returns>Array of Integers</returns>
        public int[] GetFlattenedArray(object[] inputArray)
        {
            var result = new List<int>();

            Flatten(inputArray, result);

            return result.ToArray();
        }

        private static void Flatten(object[] inputArray, ICollection<int> result)
        {
            foreach (var arrayItem in inputArray)
            {
                if (arrayItem is int)
                {
                    result.Add((int)arrayItem);
                }
                else
                {
                    var array = arrayItem as object[];
                    if (array != null)
                    {
                        Flatten(array, result);
                    }
                    else if (arrayItem is int[])
                    {
                        foreach (var item in (int[])arrayItem)
                        {
                            result.Add(item);
                        }
                    }
                    else
                    {
                        throw new InvalidDataException(InvalidDataExceptionMessage);
                    }
                }
            }
        }
    }
}