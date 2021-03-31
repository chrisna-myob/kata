using System;
using Xunit;
using TicTacToe;
using System.Collections.Generic;
using System.Collections;

namespace TicTacToe.Tests
{
    public class TestDataGenerator : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, 2, 3 };
        }
        
        public static IEnumerable<object[]> GetWinningCoordinatesFromDataGenerator()
        {
            yield return new object[]
            {
                new Coordinate(0,0), new Coordinate(0,1), new Coordinate(0,2),
            };

            yield return new object[]
            {
                new Coordinate(1,0), new Coordinate(1,1), new Coordinate(1,2),
            };

            yield return new object[]
            {
                new Coordinate(2,0), new Coordinate(2,1), new Coordinate(2,2),
            };

            yield return new object[]
            {
                new Coordinate(0,0), new Coordinate(1,0), new Coordinate(2,0),
            };

            yield return new object[]
            {
                new Coordinate(0,1), new Coordinate(1,1), new Coordinate(2,1),
            };

            yield return new object[]
            {
                new Coordinate(0,2), new Coordinate(1,2), new Coordinate(2,2),
            };

            yield return new object[]
            {
                new Coordinate(0,0), new Coordinate(1,1), new Coordinate(2,2),
            };

            yield return new object[]
            {
                new Coordinate(2,0), new Coordinate(1,1), new Coordinate(0,2),
            };

        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}