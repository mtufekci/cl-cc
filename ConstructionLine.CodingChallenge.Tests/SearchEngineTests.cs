using System;
using System.Collections.Generic;
using AutoFixture.NUnit3;
using NUnit.Framework;

namespace ConstructionLine.CodingChallenge.Tests
{
    [TestFixture]
    public class SearchEngineTests : SearchEngineTestsBase
    {
        private List<Shirt> _shirts;

        [Test]
        public void Test()
        {
            var shirts = new List<Shirt>
            {
                new Shirt(Guid.NewGuid(), "Red - Small", Size.Small, Color.Red),
                new Shirt(Guid.NewGuid(), "Black - Medium", Size.Medium, Color.Black),
                new Shirt(Guid.NewGuid(), "Blue - Large", Size.Large, Color.Blue),
            };

            var searchEngine = Given_SearchEngine(shirts);

            var searchOptions = new SearchOptions
            {
                Colors = new List<Color> {Color.Red},
                Sizes = new List<Size> {Size.Small}
            };

            var results = searchEngine.Search(searchOptions);

            AssertResults(results.Shirts, searchOptions);
            AssertSizeCounts(shirts, searchOptions, results.SizeCounts);
            AssertColorCounts(shirts, searchOptions, results.ColorCounts);
        }
    
        [Test]
        public void TestRefactored()
        {
            _shirts = Given_Shirts();

            var searchEngine = Given_SearchEngine(_shirts);

            var searchOptions =  new SearchOptions
            {
                Colors = new List<Color> {Color.Red},
                Sizes = new List<Size> {Size.Small}
            };

            var results = When_SearchEngine_Does_Search(searchEngine, searchOptions);

            Then_Should_Return_Correct_Results(results, searchOptions);
            Then_Should_Return_Number_Of_Shirts_For_Each_Size(results, searchOptions);
            Then_Should_Return_Number_Of_Shirts_For_Each_Color(results, searchOptions);
        }
        
        [Test]
        public void TestForAll()
        {
            _shirts = Given_Shirts();

            var searchEngine = Given_SearchEngine(_shirts);

            var searchOptions =  new SearchOptions
            {
                Colors = Color.All,
                Sizes = Size.All
            };

            var results = When_SearchEngine_Does_Search(searchEngine, searchOptions);

            Then_Should_Return_Correct_Results(results, searchOptions);
            Then_Should_Return_Number_Of_Shirts_For_Each_Size(results, searchOptions);
            Then_Should_Return_Number_Of_Shirts_For_Each_Color(results, searchOptions);
        }

        private static SearchResults When_SearchEngine_Does_Search(SearchEngine searchEngine, SearchOptions searchOptions)
        {
            var results = searchEngine.Search(searchOptions);
            return results;
        }

        private static SearchEngine Given_SearchEngine(List<Shirt> shirts)
        {
            var searchEngine = new SearchEngine(shirts, new ShirtIndexer(), new IndexHelper(), new SearchResultMapper());

            return searchEngine;
        }

        private static List<Shirt> Given_Shirts()
        {
            var shirts = new List<Shirt>
            {
                new Shirt(Guid.NewGuid(), "Red - Small", Size.Small, Color.Red),
                new Shirt(Guid.NewGuid(), "Black - Medium", Size.Medium, Color.Black),
                new Shirt(Guid.NewGuid(), "Blue - Large", Size.Large, Color.Blue),
            };
            return shirts;
        }

        private void Then_Should_Return_Number_Of_Shirts_For_Each_Size(SearchResults results,
            SearchOptions searchOptions)
        {
            AssertSizeCounts(_shirts, searchOptions, results.SizeCounts);
        }        
        private void Then_Should_Return_Number_Of_Shirts_For_Each_Color(SearchResults results,
            SearchOptions searchOptions)
        {
            AssertColorCounts(_shirts, searchOptions, results.ColorCounts);
        }

        private void Then_Should_Return_Correct_Results(SearchResults results, SearchOptions searchOptions)
        {
            AssertResults(_shirts, searchOptions);
        }
    }
}
