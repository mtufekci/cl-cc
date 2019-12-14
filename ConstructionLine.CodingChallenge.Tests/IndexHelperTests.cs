using System.Collections.Generic;
using ConstructionLine.CodingChallenge.Tests.SampleData;
using FluentAssertions;
using Xunit;

namespace ConstructionLine.CodingChallenge.Tests
{
    public class IndexHelperTests
    {
        private IIndexHelper _indexHelper;

    
        public IndexHelperTests()
        {
            _indexHelper = new IndexHelper();
        }
        
        [Theory]
        [ClassData(typeof(IndexHelperTestDataGenerator))]
        public void TestForMultiple(Dictionary<(Color Color, Size Size), List<Shirt>> indexShirts,
            SearchOptions searchOptions, 
            int expectedCount)
        {
            var result = _indexHelper.GetIndexesBySearchOptions(indexShirts, searchOptions);

            result.Should().HaveCount(expectedCount);
        }
    }
}