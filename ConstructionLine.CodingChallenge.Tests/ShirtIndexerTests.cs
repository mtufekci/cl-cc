using System.Collections.Generic;
using ConstructionLine.CodingChallenge.Tests.SampleData;
using FluentAssertions;
using Xunit;

namespace ConstructionLine.CodingChallenge.Tests
{
    public class ShirtIndexerTests
    {
        private ShirtIndexer _shirtIndex;
        
        public ShirtIndexerTests()
        {
            _shirtIndex = new ShirtIndexer();
        }
        
        [Theory]
        [ClassData(typeof(ShirtIndexerTestDataGenerator))]
        public void IndexDictionaryShouldContain(List<Shirt> shirts)
        {
            var result = _shirtIndex.IndexShirts(shirts);
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
            result.Should().ContainKey((Color.Black, Size.Medium));
            result.Should().ContainKey((Color.Red, Size.Small));
            result.Should().ContainKey((Color.Blue, Size.Medium));
            result.Should().ContainKey((Color.White, Size.Large));
            result.Should().NotContainKey((Color.White, Size.Small));
            result.Should().NotContainKey((Color.Red, Size.Medium));
        }        
        
        [Theory]
        [ClassData(typeof(ShirtIndexerTestDataGenerator))]
        public void IndexDictionaryNotShouldContain(List<Shirt> shirts)
        {
            var result = _shirtIndex.IndexShirts(shirts);
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
            result.Should().NotContainKey((Color.White, Size.Small));
            result.Should().NotContainKey((Color.Red, Size.Medium));
            result.Should().NotContainKey((Color.Black, Size.Small));
        }    
        
        
        [Theory]
        [ClassData(typeof(ShirtIndexerTestDataGenerator))]
        public void IndexDictionaryShouldHaveCorrectNumberOfShirts(List<Shirt> shirts)
        {
            var result = _shirtIndex.IndexShirts(shirts);
            result[(Color.Black, Size.Medium)].Should().HaveCount(100);
            result[(Color.Red, Size.Small)].Should().HaveCount(30);
            result[(Color.Blue, Size.Medium)].Should().HaveCount(2);
            result[(Color.White, Size.Large)].Should().HaveCount(5);
        }
    }
}