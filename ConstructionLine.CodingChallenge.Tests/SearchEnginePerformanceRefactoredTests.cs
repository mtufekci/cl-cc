using System;
using System.Collections.Generic;
using System.Diagnostics;
using ConstructionLine.CodingChallenge.Tests.SampleData;
using NUnit.Framework;

namespace ConstructionLine.CodingChallenge.Tests
{
    public class SearchEnginePerformanceRefactoredTests : SearchEngineTestsBase
    {
        [TestCase(50000)]
        [TestCase(100000)]
        [TestCase(500000)]
        public void PerformanceTest(int numberOfShirts)
        {
            var shirts = Given_NumberShirts(numberOfShirts);

            var searchEngine = new SearchEngine(shirts, new ShirtIndexer(), new IndexHelper(), new SearchResultMapper());
           
            var sw = new Stopwatch();
            sw.Start();

            var options = Given_SearchOptions_With_Only_Color_Red_Size_Small();

            var results = When_Search_Engine_Did_Search(searchEngine, options);

            sw.Stop();
            Console.WriteLine($"Test fixture finished in {sw.ElapsedMilliseconds} milliseconds");

            AssertResults(results.Shirts, options);
            AssertSizeCounts(results.Shirts, options, results.SizeCounts);
            AssertColorCounts(results.Shirts, options, results.ColorCounts);
        }

        private static SearchResults When_Search_Engine_Did_Search(SearchEngine searchEngine, SearchOptions options)
        {
            var results = searchEngine.Search(options);
            return results;
        }

        private static SearchOptions Given_SearchOptions_With_Only_Color_Red_Size_Small()
        {
            var options = new SearchOptions
            {
                Colors = new List<Color> {Color.Red},
                Sizes = new List<Size> {Size.Small}
            };
            return options;
        }

        private static List<Shirt> Given_NumberShirts(int numberOfShirts)
        {
            var dataBuilder = new SampleDataBuilder(numberOfShirts);

            var shirts = dataBuilder.CreateShirts();
            return shirts;
        }
    }
}