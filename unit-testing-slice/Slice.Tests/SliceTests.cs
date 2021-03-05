using System;
using System.Collections.Generic;
using Xunit;
using Slice.Exercise;

namespace Slice.Exercise.Tests
{
    public class SliceToTests
    {
        Slice slice = new Slice();

        [Theory]
        [InlineData("","")]
        [InlineData("","e")]
        [InlineData("abcdefg","")]
        // Add_SingleNumber_ReturnsSameNumber
        public void SliceTo_EmptyStrings_ThrowsArgumentException(string word, string target)
        {
            Assert.Throws<ArgumentException>(() => slice.SliceTo(word, target));
        }

        [Fact]
        public void SliceTo_StringAbcdefgAndStringE_ReturnStringAbcde()
        {
            Assert.Equal("abcde", slice.SliceTo("abcdefg", "e"));
        }

        [Fact]
        public void SliceTo_StringWordAndInvalidStringTarget_ReturnSameStringWord()
        {
            Assert.Equal("abcdefg", slice.SliceTo("abcdefg", "j"));
        }
    }

    public class SliceUntilTests
    {
        Slice slice = new Slice();

        [Theory]
        [InlineData("","")]
        [InlineData("","e")]
        [InlineData("abcdefg","")]
        public void SliceUntil_EmptyStrings_ThrowsArgumentException(string word, string target)
        {
            Assert.Throws<ArgumentException>(() => slice.SliceUntil(word, target));
        }

        [Fact]
        public void SliceUntil_StringAbcdefgAndStringE_ReturnStringAbcd()
        {
            Assert.Equal("abcd", slice.SliceUntil("abcdefg", "e"));
        }

        [Fact]
        public void SliceUntil_StringWordAndInvalidStringTarget_ReturnSameStringWord()
        {
            Assert.Equal("abcdefg", slice.SliceUntil("abcdefg", "j"));
        }
    }

    public class SliceAfterTests
    {
        Slice slice = new Slice();

        [Theory]
        [InlineData("","")]
        [InlineData("","e")]
        [InlineData("abcdefg","")]
        public void SliceAfter_EmptyStrings_ThrowsArgumentException(string word, string target)
        {
            Assert.Throws<ArgumentException>(() => slice.SliceAfter(word, target));
        }

        [Fact]
        public void SliceAfter_StringAbcdefgAndStringE_ReturnStringAbcd()
        {
            Assert.Equal("efg", slice.SliceAfter("abcdefg", "e"));
        }

        [Fact]
        public void SliceAfter_StringWordAndInvalidStringTarget_ReturnSameStringWord()
        {
            Assert.Equal("abcdefg", slice.SliceAfter("abcdefg", "j"));
        }
    }

    public class SliceBetweenTests
    {
        Slice slice = new Slice();

        [Theory]
        [InlineData("","", "")]
        [InlineData("","e", "")]
        [InlineData("","", "e")]
        [InlineData("","b", "e")]
        [InlineData("abcdefg","", "e")]
        [InlineData("abcdefg","e", "")]
        [InlineData("abcdefg","", "")]
        public void SliceBetween_EmptyStrings_ThrowsArgumentException(string word, string start, string end)
        {
            Assert.Throws<ArgumentException>(() => slice.SliceBetween(word, start, end));
        }

        [Fact]
        public void SliceBetween_StringAbcdefgAndStringE_ReturnStringBcde()
        {
            Assert.Equal("bcde", slice.SliceBetween("abcdefg", "b", "e"));
        }

        [Theory]
        [InlineData("abcdefg", "j", "m")]
        [InlineData("abcdefg", "b", "m")]
        [InlineData("abcdefg", "m", "e")]
        public void SliceBetween_StringWordAndInvalidStringStartEnd_ReturnSameStringWord(string word, string start, string end)
        {            
            Assert.Equal("abcdefg", slice.SliceBetween(word, start, end));
        }
    }

    public class SliceAllBetweenTests
    {
        Slice slice = new Slice();

        [Theory]
        [InlineData("","", "")]
        [InlineData("","e", "")]
        [InlineData("","", "e")]
        [InlineData("","b", "e")]
        [InlineData("abcdefg","", "e")]
        [InlineData("abcdefg","e", "")]
        [InlineData("abcdefg","", "")]
        public void SliceAllBetween_EmptyStrings_ThrowsArgumentException(string word, string start, string end)
        {
            Assert.Throws<ArgumentException>(() => slice.AllSlicesBetween(word, start, end));
        }

        [Fact]
        public void SliceAllBetween_StringAbcdefgStringBAndStringE_ReturnArrayStringBcdeAndStringBe()
        {
            var expected = new string[] { "bcde", "be" };

            Assert.Equal(expected, slice.AllSlicesBetween("abcdefgabefg", "b", "e"));
        }

        [Theory]
        [InlineData("abcdefgabefg", "j", "m")]
        [InlineData("abcdefgabefg", "b", "m")]
        [InlineData("abcdefgabefg", "m", "e")]
        public void SliceAllBetween_StringWordAndInvalidStringStartEnd_ReturnEmptyArray(string word, string start, string end)
        {
            var expected = new string[] {};

            Assert.Equal(expected, slice.AllSlicesBetween(word, start, end));
        }
    }
}